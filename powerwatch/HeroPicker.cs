using System;
using System.Collections.Generic;
using System.Linq;
class HeroPicker
{
    static List<HeroPool> PlayerProficiencies = new List<HeroPool>
    {
        new HeroPool ( "JACK", new List<HeroName> { HeroName.HANZO, HeroName.DVA, HeroName.KIRIKO, HeroName.SOJOURN, HeroName.PHARAH, HeroName.REINHARDT } ),
        new HeroPool ( "JUSTIN", new List<HeroName> { HeroName.MOIRA, HeroName.PHARAH, HeroName.ZENYATTA, HeroName.BASTION, HeroName.TORB, HeroName.SOJOURN, HeroName.JUNKRAT, HeroName.ORISA, HeroName.REINHARDT, HeroName.SIGMA} ),
        new HeroPool ( "LAUREN", new List<HeroName> { HeroName.MERCY, HeroName.ZARYA, HeroName.LUCIO, HeroName.MOIRA, HeroName.ORISA, HeroName.REINHARDT, HeroName.ROADHOG, HeroName.LIFEWEAVER, HeroName.TORB } ),
        new HeroPool ( "PHIL", new List<HeroName> { HeroName.MOIRA, HeroName.JUNKERQUEEN, HeroName.BASTION, HeroName.CASSIDY, HeroName.REAPER, HeroName.ILLARI, HeroName.RAMATTRA, HeroName.DVA, HeroName.REINHARDT, HeroName.ASHE, HeroName.ORISA, HeroName.WINSTON, HeroName.ANA, HeroName.BAPTISTE } )
    };

    static Dictionary<string, HeroPool> HeroPools;
    
    private Dictionary<string, RoleName> _players = new Dictionary<string, RoleName>();
    private List<HeroName> _enemyTeam;

    public void SetPlayers()
    {
        _players = new Dictionary<string, RoleName>();
        Console.Write("Enter the number of players in your team: ");
        int playerCount = int.Parse(Console.ReadLine());

        for (int i = 1; i <= playerCount; i++)
        {
            Console.Write($"Enter Player {i} name: ");
            string playerName = Console.ReadLine().ToUpper();

            Console.Write($"Enter Player {i} role (Tank, Healer, DPS): ");
            string playerRoleName = Console.ReadLine().ToUpper();
            
            if (Enum.TryParse<RoleName>(playerRoleName, out RoleName role))
            {
                _players.Add(playerName, role);
            }
            else
            {
                Console.WriteLine($"Unknown role: {playerRoleName}");
            }

            
        }
        ResetHeroPools();
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

    public void ResetHeroPools()
    {
        HeroPools = PlayerProficiencies.ToDictionary(x => x.PlayerName);
        
        foreach(var player in _players)
        {
            if (!HeroPools.ContainsKey(player.Key))
            {
                HeroPools.Add(player.Key, new HeroPool(player.Key, new List<HeroName>()));
            }
        }
    }

    public void Play()
    {
        SetPlayers();
        SetEnemyTeam();
        PrintRecommendations();
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

        HeroPools[playerName] = new HeroPool ( playerName, allowedHeroes );
    }

    public void UnlockPlayer(string playerName)
    {
        HeroPools[playerName] = new HeroPool(playerName);
    }

    public void PrintRecommendations()
    {
        Console.WriteLine("======================");


        Console.Write("Enemy team:");
        foreach (var enemy in _enemyTeam)
        {
            Console.Write(enemy+",");
        }

        var recommendationsByPlayer = new Dictionary<string, List<RankedHero>>();

        // Display recommendations for each player
        foreach (var player in _players)
        {
            string playerName = player.Key;
            RoleName playerRole = player.Value;

            Console.WriteLine($"\nRecommended Hero for {playerName} ({playerRole}):");

            // Filter heroes based on player proficiency
            var availableHeroes = HeroDefinition.Heroes
                .Where(hero =>
                    HeroPools.Values.Any(proficiency =>
                        proficiency.PlayerName == playerName &&
                        proficiency.GetCharacters().Contains(hero.PlayedHero) &&
                        hero.Role == playerRole))
                .ToList();

            var enemyHeroes = HeroDefinition.Heroes.Where(x => _enemyTeam.Contains(x.PlayedHero));

            var heroRecommendations = new List<RankedHero>();

            foreach (var hero in availableHeroes)
            {
                var counterScore = GetCounterScore(hero, enemyHeroes);
                if (counterScore > 0)
                {
                    heroRecommendations.Add(new RankedHero() {Hero=hero, RankScore=counterScore});
                }
            }

            var finalRecs = heroRecommendations.OrderByDescending(x => x.RankScore).ToList();
            // Display the recommended hero
            if (finalRecs.Any())
            {
                foreach(var rankedHero in finalRecs)
                {
                    Console.Write(rankedHero.Hero.PlayedHero + " (+"+rankedHero.RankScore+"), ");
                }
            }
            else
            {
                Console.WriteLine("No suitable hero found.");
            }
            
            Console.WriteLine("");

            recommendationsByPlayer.Add(playerName, finalRecs);
        }
        PrintPerfectTeam(recommendationsByPlayer);
    }

    private void PrintPerfectTeam(Dictionary<string, List<RankedHero>> rankedRecommendations)
    {
        // backfill empty recs
        foreach (var kvp in rankedRecommendations)
        {
            string key = kvp.Key;
            List<RankedHero> heroes = kvp.Value;

            // Check if the list is empty, and backfill with the default list if needed
            if (heroes == null || heroes.Count == 0)
            {
                rankedRecommendations[key] = new List<RankedHero>();

                foreach(var heroName in HeroDefinition.EveryHero())
                {
                    rankedRecommendations[key].Add(new RankedHero() {PlayerName = key, Hero = HeroDefinition.GetHeroFromName(heroName), RankScore = 0 });
                }
            }
        }

        var allPossibleTeams = GetAllPossibleTeams(rankedRecommendations);

        int i = 0;

        foreach(var team in allPossibleTeams)
        {
            
        }
    }

    private int GetTeamScore(List<RankedHero> team)
    {
        var score = team.Sum(x => x.RankScore);
        // check for synergies, +1 for each

        var heroNames = team.Select(x => x.Hero.PlayedHero).ToList();

        // Flatten the list of synergies into a single list of unique hero names
        var synergyHeroNames = HeroDefinition.Synergies.SelectMany(synergy => synergy.Select(hero => hero)).Distinct();

        // Count the number of hero names in the team that are part of any synergy
        int numberOfSynergies = synergyHeroNames.Count(heroName => team.Any(hero => hero.Hero.PlayedHero == heroName));

        return score + (numberOfSynergies*10);
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
                    Hero = combination[i]
                });
            }
            result.Add(team);
        }

        return result;
    }

    private List<List<Hero>> GenerateHeroCombinations(List<List<RankedHero>> playerHeroLists)
    {
        var heroCombinations = new List<List<Hero>>();

        GenerateHeroCombinationsRecursive(playerHeroLists, new List<Hero>(), heroCombinations);

        return heroCombinations;
    }

    private void GenerateHeroCombinationsRecursive(List<List<RankedHero>> remainingPlayerHeroLists,
        List<Hero> currentCombination, List<List<Hero>> heroCombinations)
    {
        if (currentCombination.Count == remainingPlayerHeroLists.Count)
        {
            heroCombinations.Add(new List<Hero>(currentCombination));
            return;
        }

        var currentListIndex = currentCombination.Count;
        var currentHeroList = remainingPlayerHeroLists[currentListIndex];

        foreach (var rankedHero in currentHeroList)
        {
            if (!currentCombination.Any(hero => hero.PlayedHero == rankedHero.Hero.PlayedHero))
            {
                currentCombination.Add(rankedHero.Hero);
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
                counterScore++;
            }

            if (playerHero.Counters.Contains(enemyHero.PlayedHero))
            {
                counterScore--;
            }

        }
        return counterScore;
    }
}