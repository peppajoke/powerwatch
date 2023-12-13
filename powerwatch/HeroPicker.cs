using System;
using System.Collections.Generic;
using System.Linq;
class HeroPicker
{
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
            var availableHeroes = HeroDefinition.Heroes
                .Where(hero => playerProficiencies
                    .Any(proficiency => proficiency.Name == playerName && proficiency.Characters.Contains(hero.Name) && hero.Role == playerRole))
                .ToList();

            var enemyHeroes = HeroDefinition.Heroes.Where(x => enemyTeamInput.Contains(x.Name));

            // Fetch enemy hero objects
            // Sort Available heroes by amount of counters across the team

            var heroRecommendations = new List<RankedHero>();

            foreach (var hero in availableHeroes)
            {
                var counterCount = GetCounterCount(hero, enemyHeroes);
                if (counterCount > 0)
                {
                    heroRecommendations.Add(new RankedHero() {Hero=hero, RankScore=counterCount});
                }
            }

            var finalRecs = heroRecommendations.OrderByDescending(x => x.RankScore);

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
}