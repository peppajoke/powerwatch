using System;
using System.Collections.Generic;
using System.Linq;
class HeroPicker
{
    static List<HeroPool> PlayerProficiencies = new List<HeroPool>
    {
        new HeroPool ("JACK", new List<HeroDefinition.HeroName> { HeroDefinition.HeroName.HANZO, HeroDefinition.HeroName.DVA, HeroDefinition.HeroName.KIRIKO, HeroDefinition.HeroName.SOJOURN, HeroDefinition.HeroName.PHARAH, HeroDefinition.HeroName.REINHARDT } ),
        new HeroPool ( "JUSTIN", new List<HeroDefinition.HeroName> { HeroDefinition.HeroName.MOIRA, HeroDefinition.HeroName.PHARAH, HeroDefinition.HeroName.ZENYATTA, HeroDefinition.HeroName.BASTION, HeroDefinition.HeroName.TORBJORN, HeroDefinition.HeroName.SOJOURN, HeroDefinition.HeroName.JUNKRAT, HeroDefinition.HeroName.ORISA, HeroDefinition.HeroName.REINHARDT, HeroDefinition.HeroName.SIGMA} ),
        new HeroPool ( "LAUREN", new List<HeroDefinition.HeroName> { HeroDefinition.HeroName.MERCY, HeroDefinition.HeroName.ZARYA, HeroDefinition.HeroName.LUCIO, HeroDefinition.HeroName.MOIRA, HeroDefinition.HeroName.ORISA, HeroDefinition.HeroName.REINHARDT, HeroDefinition.HeroName.ROADHOG, HeroDefinition.HeroName.LIFEWEAVER, HeroDefinition.HeroName.TORBJORN } ),
        new HeroPool ( "PHIL", new List<HeroDefinition.HeroName> { HeroDefinition.HeroName.MOIRA, HeroDefinition.HeroName.JUNKERQUEEN, HeroDefinition.HeroName.BASTION, HeroDefinition.HeroName.CASSIDY, HeroDefinition.HeroName.REAPER, HeroDefinition.HeroName.ILLARI, HeroDefinition.HeroName.RAMATTRA, HeroDefinition.HeroName.DVA, HeroDefinition.HeroName.REINHARDT, HeroDefinition.HeroName.ASHE, HeroDefinition.HeroName.ORISA, HeroDefinition.HeroName.WINSTON, HeroDefinition.HeroName.ANA, HeroDefinition.HeroName.BAPTISTE } )
    };

    static Dictionary<string, HeroPool> HeroPools;
    
    private Dictionary<string, HeroDefinition.RoleName> _players = new Dictionary<string, HeroDefinition.RoleName>();
    private List<HeroDefinition.HeroName> _enemyTeam;

    public void SetPlayers()
    {
        _players = new Dictionary<string, HeroDefinition.RoleName>();
        Console.Write("Enter the number of players in your team: ");
        int playerCount = int.Parse(Console.ReadLine());

        for (int i = 1; i <= playerCount; i++)
        {
            Console.Write($"Enter Player {i} name: ");
            string playerName = Console.ReadLine().ToUpper();

            Console.Write($"Enter Player {i} role (Tank, Healer, DPS): ");
            string playerRoleName = Console.ReadLine().ToUpper();
            
            if (Enum.TryParse<HeroDefinition.RoleName>(playerRoleName, out HeroDefinition.RoleName role))
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

        if (Enum.TryParse<HeroDefinition.RoleName>(roleName, out HeroDefinition.RoleName role))
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
        _enemyTeam = new List<HeroDefinition.HeroName>();
        Console.Write("Enter the enemy team composition (comma-separated): ");
        string enemyTeamInput = Console.ReadLine().ToUpper();
        foreach (var heroString in enemyTeamInput.Split(','))
        {
            if (Enum.TryParse<HeroDefinition.HeroName>(heroString, out HeroDefinition.HeroName heroName))
            {
                _enemyTeam.Add(heroName);
            }
            else
            {
                Console.WriteLine($"Unknown hero: {heroString}");
            }
        }

    }

    public void ResetHeroPools()
    {
        HeroPools = PlayerProficiencies.ToDictionary(x => x.PlayerName);
        
        foreach(var player in _players)
        {
            if (!HeroPools.ContainsKey(player.Key))
            {
                HeroPools.Add(player.Key, new HeroPool(player.Key, new List<HeroDefinition.HeroName>()));
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
        var allowedHeroes = new List<HeroDefinition.HeroName>();
        foreach (var heroString in heroes)
        {
            if (Enum.TryParse<HeroDefinition.HeroName>(heroString, out HeroDefinition.HeroName heroName))
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
        // Display recommendations for each player
        foreach (var player in _players)
        {
            string playerName = player.Key;
            HeroDefinition.RoleName playerRole = player.Value;

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

            var finalRecs = heroRecommendations.OrderByDescending(x => x.RankScore);
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
                //counterScore--;
            }

        }
        return counterScore;
    }
}