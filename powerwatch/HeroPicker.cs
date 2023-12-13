using System;
using System.Collections.Generic;
using System.Linq;
class HeroPicker
{
    class Hero
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public List<string> Counters { get; set; }
    }

    class PlayerProficiency
    {
        public string Name { get; set; }
        public List<string> Characters { get; set; }
    }

    static List<Hero> Heroes = new List<Hero>
    {
        new Hero { Name = "Doomfist", Role = "Tank", Counters = new List<string> { "Wrecking Ball", "Sombra", "Pharah", "Lucio", "Ana" } },
        new Hero { Name = "DVA", Role = "Tank", Counters = new List<string> { "Zarya", "Reinhardt", "Winston", "Ramattra", "Symmetra", "Bridgitte" } },
        new Hero { Name = "Junker Queen", Role = "Tank", Counters = new List<string> { "Pharah", "Echo", "Kiriko", "Baptiste" } },
        new Hero { Name = "Mauga", Role = "Tank", Counters = new List<string> { "Sigma", "DVA", "Zarya", "Mei", "Sombra", "Ana" } },
        new Hero { Name = "Orisa", Role = "Tank", Counters = new List<string> { "Wrecking Ball", "Genji", "Tracer", "Sombra", "Reaper", "Echo" } },
        new Hero { Name = "Ramattra", Role = "Tank", Counters = new List<string> { "Roadhog", "Reaper", "Tracer", "Genji", "Echo", "Pharah" } },
        new Hero { Name = "Reinhardt", Role = "Tank", Counters = new List<string> { "Tracer", "Genji", "Pharah", "Echo", "Reaper", "Bastion", "Junkrat" } },
        new Hero { Name = "Roadhog", Role = "Tank", Counters = new List<string> { "Junker Queen", "Reaper", "Ana" } },
        new Hero { Name = "Sigma", Role = "Tank", Counters = new List<string> { "Sojourn", "Widowmaker", "Hanzo", "Lucio", "Baptiste", "Kiriko" } },
        new Hero { Name = "Winston", Role = "Tank", Counters = new List<string> { "Roadhog", "Reaper", "Mei", "Bastion" } },
        new Hero { Name = "Wrecking Ball", Role = "Tank", Counters = new List<string> { "Sombra", "Junkrat", "Mei", "Brigitte" } },
        new Hero { Name = "Zarya", Role = "Tank", Counters = new List<string> { "DVA", "Kiriko", "Baptiste", "Zenyatta", "Lucio" } },
        new Hero { Name = "Ashe", Role = "DPS", Counters = new List<string> { "Genji", "Tracer", "Echo", "Soldier", "Cassidy" } },
        new Hero { Name = "Bastion", Role = "DPS", Counters = new List<string> { "Zarya", "Roadhog", "Wrecking Ball", "Junkrat", "Pharah", "Genji", "Tracer", "Ana" } },
        new Hero { Name = "Cassidy", Role = "DPS", Counters = new List<string> { "Reinhardt", "Winston", "Genji", "Cassidy" } },
        new Hero { Name = "Echo", Role = "DPS", Counters = new List<string> { "Winston", "Orisa", "Ashe", "Cassidy", "Soldier", "Widowmaker" } },
        new Hero { Name = "Genji", Role = "DPS", Counters = new List<string> { "Winston", "Zarya", "Symmetra", "Mei", "Moira" } },
        new Hero { Name = "Hanzo", Role = "DPS", Counters = new List<string> { "DVA", "Wrecking Ball", "Tracer", "Pharah", "Genji", "Lucio" } },
        new Hero { Name = "Junkrat", Role = "DPS", Counters = new List<string> { "Zarya", "Wrecking Ball", "Cassidy", "Soldier", "Genji", "Pharah", "Echo", "Tracer", "Lucio" } },
        new Hero { Name = "Mei", Role = "DPS", Counters = new List<string> { "Sombra", "Pharah", "Echo", "Soldier", "Ashe", "Widowmaker" } },
        new Hero { Name = "Pharah", Role = "DPS", Counters = new List<string> { "DVA", "Soldier", "Cassidy", "Ashe", "Widowmaker" } },
        new Hero { Name = "Reaper", Role = "DPS", Counters = new List<string> { "Pharah", "Echo", "Junkrat", "Widowmaker", "Ana" } },
        new Hero { Name = "Sojourn", Role = "DPS", Counters = new List<string> { "Winston", "Genji", "Tracer", "Lucio" } },
        new Hero { Name = "Soldier 76", Role = "DPS", Counters = new List<string> { "Roadhog", "Ashe", "Cassidy", "Genji", "Junkrat" } },
        new Hero { Name = "Sombra", Role = "DPS", Counters = new List<string> { "Winston", "Pharah", "Junkrat", "Hanzo", "Mei", "Kiriko", "Ana" } },
        new Hero { Name = "Symmetra", Role = "DPS", Counters = new List<string> { "Winston", "Pharah", "Junkrat", "Echo" } },
        new Hero { Name = "Torbjorn", Role = "DPS", Counters = new List<string> { "Pharah", "Junkrat", "Echo", "Sombra" } },
        new Hero { Name = "Tracer", Role = "DPS", Counters = new List<string> { "Winston", "Symmetra", "Torbjorn", "Mei", "Moira" } },
        new Hero { Name = "Widowmaker", Role = "DPS", Counters = new List<string> { "Genji", "Tracer", "Ashe", "Zenyatta" } },
        new Hero { Name = "Ana", Role = "Healer", Counters = new List<string> { "Orisa", "Winston", "Ramattra", "Doomfist", "Echo", "Pharah", "Tracer" } },
        new Hero { Name = "Baptiste", Role = "Healer", Counters = new List<string> { "Genji", "Tracer", "Hanzo", "Echo", "Pharah", "Widowmaker", "Sombra", "Cassidy", "Ashe", "Lucio" } },
        new Hero { Name = "Brigitte", Role = "Healer", Counters = new List<string> { "Pharah", "Echo", "Junkrat" } },
        new Hero { Name = "Illari", Role = "Healer", Counters = new List<string> { "Orisa", "Zarya", "DVA", "Cassidy", "Genji", "Mei", "Ana" } },
        new Hero { Name = "Kiriko", Role = "Healer", Counters = new List<string> { "Roadhog", "Tracer", "Sombra", "Genji", "Mei", "Ana" } },
        new Hero { Name = "Lifeweaver", Role = "Healer", Counters = new List<string> { "Sombra", "Soldier" } },
        new Hero { Name = "Lucio", Role = "Healer", Counters = new List<string> { "Winston", "Roadhog", "Soldier", "Cassidy", "Ashe", "Widowmaker", "Symmetra", "Torbjorn", "Mei", "Moira" } },
        new Hero { Name = "Mercy", Role = "Healer", Counters = new List<string> { "Winston", "Roadhog", "Echo", "Cassidy", "Widowmaker", "Genji", "Tracer" } },
        new Hero { Name = "Moira", Role = "Healer", Counters = new List<string> { "Roadhog", "Zarya", "Echo", "Widowmaker", "Junkrat", "Mei", "Ashe", "Pharah", "Ana" } },
        new Hero { Name = "Zenyatta", Role = "Healer", Counters = new List<string> { "Junkrat", "Pharah", "Cassidy", "Widowmaker", "Ashe", "Hanzo", "Tracer", "Genji", "Kiriko", "Zenyatta" } }
    };

    static List<PlayerProficiency> PlayerProficiencies = new List<PlayerProficiency>
    {
        new PlayerProficiency { Name = "Jack", Characters = new List<string> { "Hanzo", "DVA", "Kiriko", "Sojourn", "Pharah", "Reinhardt" } },
        new PlayerProficiency { Name = "Justin", Characters = new List<string> { "Moira", "Pharah", "Zenyatta", "Bastion", "Torbjorn", "Sojourn", "Junkrat", "Orisa", "Reinhardt", "Sigma"} },
        new PlayerProficiency { Name = "Lauren", Characters = new List<string> { "Mercy", "Zarya", "Lucio", "Moira", "Orissa", "Reinhardt", "Roadhog", "Lifeweaver", "Torbjorn" } },
        new PlayerProficiency { Name = "Phil", Characters = new List<string> { "Moira", "Junkerqueen", "Bastion", "Cassidy", "Reaper", "Illari", "Ramattra", "DVA", "Reinhardt", "Ashe", "Orisa", "Winston", "Ana", "Baptiste" } }
    };
    
    public void Play()
    {
        Console.Write("Enter the number of players in your team: ");
        int playerCount = int.Parse(Console.ReadLine());

        Dictionary<string, string> players = new Dictionary<string, string>();

        for (int i = 1; i <= playerCount; i++)
        {
            Console.Write($"Enter Player {i} name: ");
            string playerName = Console.ReadLine();

            Console.Write($"Enter Player {i} role (Tank, Healer, DPS): ");
            string playerRole = Console.ReadLine();

            players.Add(playerName, playerRole);
        }

        Console.Write("Enter the enemy team composition (comma-separated): ");
        string enemyTeamInput = Console.ReadLine();
        string[] enemyTeam = enemyTeamInput.Split(';');

        List<PlayerProficiency> playerProficiencies = PlayerProficiencies;

        // Display recommendations for each player
        foreach (var player in players)
        {
            string playerName = player.Key;
            string playerRole = player.Value;

            Console.WriteLine($"\nRecommended Hero for {playerName} ({playerRole}):");

            // Filter heroes based on player proficiency
            var availableHeroes = Heroes
                .Where(hero => playerProficiencies
                    .Any(proficiency => proficiency.Name == playerName && proficiency.Characters.Contains(hero.Name) && hero.Role == playerRole))
                .ToList();

            var enemyHeroes = Heroes.Where(x => enemyTeamInput.Contains(x.Name));

            // Fetch enemy hero objects
            // Sort Available heroes by amount of counters across the team

            var heroRecommendations = new List<RankedHero>();

            foreach (var hero in availableHeroes)
            {
                var counterCount = GetCounterCount(hero, enemyHeroes);
                if (counterCount > 0)
                {
                    heroRecommendations.Add(new RankedHero() {Hero=hero, Rank=counterCount});
                }
            }

            var finalRecs = heroRecommendations.OrderByDescending(x => x.Rank);

            // Display the recommended hero
            if (finalRecs.Any())
            {
                foreach(var rankedHero in finalRecs)
                {
                    Console.WriteLine(rankedHero.Hero.Name);
                }
            }
            else
            {
                Console.WriteLine("No suitable hero found.");
            }
        }
    }

    private int GetCounterCount(Hero playerHero, IEnumerable<Hero> enemyHeroes)
    {
        var counterCount = 0;
        foreach (var enemyHero in enemyHeroes)
        {
            if (enemyHero.Counters.Contains(playerHero.Name))
            {
                counterCount++;
            }
        }

        //todo, do the reverse as well, demote counts for counters OF the player hero
        return counterCount;
    }

    class RankedHero
    {
        public Hero Hero;
        public int Rank;

    }
}