using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

class HeroPicker
{
    private static readonly List<HeroPool> PlayerProficiencies = new List<HeroPool>
    {
        new HeroPool("JACK", new List<HeroName> { HeroName.MEI, HeroName.REAPER, HeroName.MAUGA, HeroName.HANZO, HeroName.DVA, HeroName.KIRIKO, HeroName.SOJOURN, HeroName.PHARAH, HeroName.REINHARDT, HeroName.SIGMA }),
        new HeroPool("JUSTIN", new List<HeroName> { HeroName.MOIRA, HeroName.PHARAH, HeroName.ZENYATTA, HeroName.BASTION, HeroName.TORB, HeroName.SOJOURN, HeroName.JUNKRAT, HeroName.ORISA, HeroName.REINHARDT, HeroName.SIGMA }),
        new HeroPool("LAUREN", new List<HeroName> { HeroName.MERCY, HeroName.ZARYA, HeroName.LUCIO, HeroName.MOIRA, HeroName.ORISA, HeroName.REINHARDT, HeroName.ROADHOG, HeroName.LIFEWEAVER, HeroName.TORB }),
        new HeroPool("PHIL", new List<HeroName> { HeroName.MOIRA, HeroName.JUNKERQUEEN, HeroName.BASTION, HeroName.CASSIDY, HeroName.REAPER, HeroName.ILLARI, HeroName.RAMATTRA, HeroName.DVA, HeroName.REINHARDT, HeroName.ASHE, HeroName.ORISA, HeroName.WINSTON, HeroName.ANA, HeroName.BAPTISTE }),
        new HeroPool("MATT", new List<HeroName> { HeroName.DVA, HeroName.GENJI, HeroName.BASTION, HeroName.HANZO, HeroName.REAPER, HeroName.SOLDIER76, HeroName.REINHARDT })
    };

    private Dictionary<string, int> _proficiencyPreference = new Dictionary<string, int>()
    {
        { "JACK", 1 },
        { "JUSTIN", 2 },
        { "LAUREN", 2 },
        { "PHIL", 3 },
        { "MATT", 3 }
    };

    private Dictionary<string, HeroPool> HeroPools;
    private Map _map = Map.NONE;
    private TeamSide _side = TeamSide.NEUTRAL;

    private HeroWinRateRanker _ranker;

    private Dictionary<string, RoleName> _players = new Dictionary<string, RoleName>();
    private List<HeroName> _enemyTeam;

    private const int SCORE_MOD = 45;

    public void SetPlayers()
    {
        _players = new Dictionary<string, RoleName>();
        Console.Write("Enter the number of players in your team: ");
        
        // Keep asking for input until a valid integer is provided
        int playerCount;
        while (!int.TryParse(Console.ReadLine(), out playerCount))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            Console.Write("Enter the number of players in your team: ");
        }

        for (int i = 1; i <= playerCount; i++)
        {
            Console.Write($"Enter Player {i} name: ");
            string playerName = Console.ReadLine().ToUpper();

            Console.Write($"Enter Player {i} role (Tank, Healer, DPS): ");
            string playerRoleName = Console.ReadLine().ToUpper();

            // Keep asking for role input until a valid role is provided
            RoleName role;
            while (!Enum.TryParse<RoleName>(playerRoleName, out role))
            {
                Console.WriteLine($"Unknown role: {playerRoleName}");
                Console.Write($"Enter Player {i} role (Tank, Healer, DPS): ");
                playerRoleName = Console.ReadLine().ToUpper();
            }

            _players.Add(playerName, role);
        }
        ResetHeroPools();
    }

    public void SetMap(Map map)
    {
        _map = map;
    }

    public void SetTeamSide(TeamSide side)
    {
        _side = side;
    }

    public void SetPlayerRole(string playerName, string roleName)
    {
        if (!_players.ContainsKey(playerName))
        {
            Console.WriteLine("Player not found");
            return;
        }

        if (Enum.TryParse<RoleName>(roleName, out RoleName role))
        {
            _players[playerName] = role;
        }
        else
        {
            Console.WriteLine($"Unknown role: {roleName}");
        }
    }

    public void SetEnemyTeam()
    {
        _enemyTeam = new List<HeroName>();
        Console.Write("Enter the enemy team composition (comma-separated): ");
        string enemyTeamInput = Console.ReadLine().ToUpper();
        foreach (var heroString in enemyTeamInput.Split(','))
        {
            if (Enum.TryParse<HeroName>(heroString, out HeroName heroName))
            {
                _enemyTeam.Add(heroName);
            }
            else
            {
                Console.WriteLine($"Unknown hero: {heroString}");
            }
        }
    }

    public void SetEnemyTeam(List<HeroName> newTeam)
    {
        _enemyTeam = new List<HeroName>(newTeam);
    }

    public void AddFoe(HeroName foe)
    {
        _enemyTeam.Add(foe);
    }

    private bool IsProficient(string playerName, HeroName hero)
    {
        var match = PlayerProficiencies.FirstOrDefault(x => x.PlayerName == playerName);
        return match?.GetCharacters()?.Contains(hero) ?? false;
    }

    public void ResetHeroPools()
    {
        HeroPools = PlayerProficiencies.ToDictionary(x => x.PlayerName);

        foreach (var player in _players)
        {
            if (!HeroPools.ContainsKey(player.Key))
            {
                HeroPools.Add(player.Key, new HeroPool(player.Key, new List<HeroName>()));
            }
        }
    }

    public void Play()
    {
        _setRanker();
        SetPlayers();
        SetEnemyTeam();
        PrintRecommendations();
    }

    private void _setRanker()
    {
        _ranker = new HeroWinRateRanker();
    }

    public void LockPlayer(string playerName, List<string> heroes)
    {
        var allowedHeroes = new List<HeroName>();
        foreach (var heroString in heroes)
        {
            if (Enum.TryParse<HeroName>(heroString, out HeroName heroName))
            {
                allowedHeroes.Add(heroName);
            }
            else
            {
                Console.WriteLine($"Unknown hero: {heroString}");
            }
        }

        HeroPools[playerName] = new HeroPool(playerName, allowedHeroes);
    }

    public void UnlockPlayer(string playerName)
    {
        HeroPools[playerName] = new HeroPool(playerName);
    }

    private int GetHeroMapScore(HeroName hero, Map map)
    {
        if (HeroDefinition.HeroMapSynergies.TryGetValue(map, out var mapSynergies) && mapSynergies.Contains(hero))
        {
            return 2 * SCORE_MOD;
        }
        return 0;
    }

    private int GetHeroTeamSideScore(HeroName hero, TeamSide side)
    {
        if (HeroDefinition.HeroTeamSideTypeSynergies.TryGetValue(side, out var sideSynergies) && sideSynergies.Contains(hero))
        {
            return 2 * SCORE_MOD;
        }
        return 0;
    }


    public void PrintRecommendations()
    {
        Console.Clear();
        if (_map != Map.NONE)
        {
            Console.WriteLine("Map: " + _map.ToString());
        }
        if (_side != TeamSide.NEUTRAL)
        {
            Console.WriteLine(_side == TeamSide.ATTACK ? "Attacking": "Defending");
        }
        Console.Write("Enemy team:");
        foreach (var enemy in _enemyTeam)
        {
            Console.Write(enemy + ",");
        }

        var recommendationsByPlayer = new Dictionary<string, List<RankedHero>>();

        // Display recommendations for each player
        foreach (var player in _players)
        {
            string playerName = player.Key;
            RoleName playerRole = player.Value;

            Console.Write($"\n{playerName} ({playerRole}): ");

            // Filter heroes based on player proficiency
            var availableHeroes = HeroDefinition.Heroes
                .Where(hero =>
                    HeroPools.Values.Any(proficiency =>
                        proficiency.PlayerName == playerName &&
                        hero.Role == playerRole))
                .ToList();
            var enemyHeroes = HeroDefinition.Heroes.Where(x => _enemyTeam.Contains(x.PlayedHero));

            var heroRecommendations = new List<RankedHero>();

            foreach (var hero in availableHeroes)
            {
                var counterScore = GetCounterScore(hero, enemyHeroes);

                counterScore += GetHeroMapScore(hero.PlayedHero, _map);
                counterScore += GetHeroTeamSideScore(hero.PlayedHero, _side);

                if (IsProficient(playerName, hero.PlayedHero))
                {
                    var modifier = 1;
                    if (_proficiencyPreference.ContainsKey(playerName))
                    {
                        modifier = _proficiencyPreference[playerName];
                    }
                    counterScore += modifier * SCORE_MOD;
                }

                if (counterScore > -1)
                {
                    heroRecommendations.Add(new RankedHero() { Hero = hero, RankScore = counterScore });
                }
            }

            var finalRecs = heroRecommendations.OrderByDescending(x => x.RankScore).ToList();
            // Display the recommended hero
            if (finalRecs.Any())
            {
                int highestRankScore = finalRecs.Max(hero => hero.RankScore);
                foreach (var rankedHero in finalRecs.Where(hero => hero.RankScore == highestRankScore))
                {
                    Console.Write(rankedHero.Hero.PlayedHero + " (+" + rankedHero.RankScore + "), ");
                }
            }
            else
            {
                Console.WriteLine("No suitable hero found.");
            }

            recommendationsByPlayer.Add(playerName, finalRecs);
        }
        PrintPerfectTeam(recommendationsByPlayer);
    }

    private void PrintPerfectTeam(Dictionary<string, List<RankedHero>> rankedRecommendations)
    {
        // backfill empty recs
        foreach (var kvp in rankedRecommendations)
        {
            string playerName = kvp.Key;
            List<RankedHero> heroes = kvp.Value;
            var role = _players[playerName];

            // Check if the list is empty, and backfill with the default list if needed
            if (heroes == null || heroes.Count == 0)
            {
                rankedRecommendations[playerName] = new List<RankedHero>();

                foreach (var heroName in HeroDefinition.GetHeroesByRole(role))
                {
                    rankedRecommendations[playerName].Add(new RankedHero() { PlayerName = playerName, Hero = HeroDefinition.GetHeroFromName(heroName), RankScore = 0 });
                }
            }
        }

        var allPossibleTeams = GetAllPossibleTeams(rankedRecommendations);

        var highScore = -100;
        List<RankedHero> bestTeam = new List<RankedHero>();

        foreach (var team in allPossibleTeams)
        {
            var score = GetTeamScore(team);
            if (score > highScore)
            {
                bestTeam = team;
                highScore = score;
            }
        }

        Console.WriteLine("\n\nBest possible team (+ " + highScore + ")");
        foreach (var rankedHero in bestTeam)
        {
            Console.WriteLine(rankedHero.PlayerName + ": " + rankedHero.Hero.PlayedHero.ToString());
        }

        Console.WriteLine("\n\nPerfect counters");
        foreach (var enemy in _enemyTeam)
        {
            Console.Write("\n" + enemy.ToString() + ": ");
            var perfectCounter = GetPerfectCounterTeam(enemy, rankedRecommendations);
            foreach(var hero in perfectCounter)
            {
                Console.Write(hero.PlayerName + ": " + hero.Hero.PlayedHero + ", ");
            }
        }
        Console.WriteLine("");
    }

    private List<RankedHero> GetPerfectCounterTeam(HeroName enemy, Dictionary<string,List<RankedHero>> heroesByPlayer)
    {
        var enemyHeroes = HeroDefinition.Heroes.Where(x => x.PlayedHero == enemy);
        var teamRecommendations = new Dictionary<string, List<RankedHero>>();

        foreach (var player in _players)
        {
            string playerName = player.Key;
            RoleName playerRole = player.Value;

            var availableHeroes = heroesByPlayer[playerName];

            if (!availableHeroes.Any())
            {
                availableHeroes = HeroDefinition.GetHeroesByRole(playerRole).Select(x => new RankedHero() {Hero = new Hero() {PlayedHero = x}, PlayerName = playerName, RankScore = 1}).ToList();
            }

            var heroRecommendations = new List<RankedHero>();

            foreach (var hero in availableHeroes)
            {
                var counterScore = GetCounterScore(hero.Hero, enemyHeroes);
                var modifier = 1;
                if (_proficiencyPreference.ContainsKey(playerName))
                {
                    modifier = _proficiencyPreference[playerName];
                }
                counterScore += modifier * SCORE_MOD;

                if (counterScore > -1)
                {
                    heroRecommendations.Add(new RankedHero() { Hero = hero.Hero, RankScore = counterScore });
                }
            }

            var finalRecs = heroRecommendations.OrderByDescending(x => x.RankScore).ToList();
            teamRecommendations.Add(playerName, finalRecs);
        }

        var allPossibleTeams = GetAllPossibleTeams(teamRecommendations);

        var highScore = -100;
        List<RankedHero> bestTeam = new List<RankedHero>();

        foreach (var team in allPossibleTeams)
        {
            var score = team.Sum(x => x.RankScore);
            if (score > highScore)
            {
                bestTeam = team;
                highScore = score;
            }
        }

        return bestTeam;
    }

    private int GetTeamScore(List<RankedHero> team)
    {
        var score = team.Sum(x => x.RankScore);
        var heroNames = team.Select(x => x.Hero.PlayedHero).ToList();

        // Flatten the list of synergies into a single list of unique hero names
        var synergyHeroNames = HeroDefinition.Synergies.SelectMany(synergy => synergy).Distinct();

        // Count the number of complete synergies in the team
        int numberOfCompleteSynergies = HeroDefinition.Synergies.Count(synergy =>
        {
            // Check if all heroes in the synergy are present in the team
            return synergy.All(hero => heroNames.Contains(hero));
        });

        return score + (numberOfCompleteSynergies * SCORE_MOD);
    }   

    private List<List<RankedHero>> GetAllPossibleTeams(Dictionary<string, List<RankedHero>> rankedRecommendations)
    {
        var playerNames = rankedRecommendations.Keys.ToList();
        var heroCombinations = GenerateHeroCombinations(rankedRecommendations.Values.ToList());

        var result = new List<List<RankedHero>>();

        foreach (var combination in heroCombinations)
        {
            var team = new List<RankedHero>();
            for (var i = 0; i < playerNames.Count; i++)
            {
                team.Add(new RankedHero
                {
                    PlayerName = playerNames[i],
                    Hero = combination[i].Hero,
                    RankScore = combination[i].RankScore
                });
            }
            result.Add(team);
        }

        return result;
    }

    private List<List<RankedHero>> GenerateHeroCombinations(List<List<RankedHero>> playerHeroLists)
    {
        var heroCombinations = new List<List<RankedHero>>();

        GenerateHeroCombinationsRecursive(playerHeroLists, new List<RankedHero>(), heroCombinations);

        return heroCombinations;
    }

    private void GenerateHeroCombinationsRecursive(List<List<RankedHero>> remainingPlayerHeroLists,
        List<RankedHero> currentCombination, List<List<RankedHero>> heroCombinations)
    {
        if (currentCombination.Count == remainingPlayerHeroLists.Count)
        {
            heroCombinations.Add(new List<RankedHero>(currentCombination));
            return;
        }

        var currentListIndex = currentCombination.Count;
        var currentHeroList = remainingPlayerHeroLists[currentListIndex];

        foreach (var rankedHero in currentHeroList)
        {
            if (!currentCombination.Any(hero => hero.Hero.PlayedHero == rankedHero.Hero.PlayedHero))
            {
                currentCombination.Add(rankedHero);
                GenerateHeroCombinationsRecursive(remainingPlayerHeroLists, currentCombination, heroCombinations);
                currentCombination.RemoveAt(currentCombination.Count - 1);
            }
        }
    }

    private int GetCounterScore(Hero playerHero, IEnumerable<Hero> enemyHeroes)
    {
        var counterScore = 0;
        foreach (var enemyHero in enemyHeroes)
        {
            if (enemyHero.Counters.Contains(playerHero.PlayedHero))
            {
                counterScore+= SCORE_MOD;
            }

            if (playerHero.Counters.Contains(enemyHero.PlayedHero))
            {
                counterScore-= SCORE_MOD;
            }
        }

        var winRateBonus = _ranker.GetScoreForHero(playerHero.PlayedHero);

        return counterScore + winRateBonus;
    }
}
