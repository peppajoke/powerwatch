using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static HeroPicker _picker;

    static void Main(string[] args)
    {
        Initialize();

        var listener = new SpeechListener();
        listener.Listen();

        while (true)
        {
            var commandsStrings = Console.ReadLine()?.ToUpper().Split(' ');

            if (commandsStrings == null || commandsStrings.Length == 0)
            {
                continue;
            }

            var firstCommandString = commandsStrings[0];
            var command = GetCommandFromString(firstCommandString);

            switch (command)
            {
                case Command.ResetHeroPools:
                    ResetHeroPools();
                    break;
                case Command.LockHeroForPlayer:
                    LockHeroForPlayer(commandsStrings);
                    break;
                case Command.ResetEnemyTeam:
                    ResetEnemyTeam();
                    break;
                case Command.ChangePlayerRole:
                    ChangePlayerRole(commandsStrings);
                    break;
                case Command.HardReset:
                    HardReset();
                    break;
                case Command.List:
                    Console.WriteLine("Sorry, I haven't coded this one yet.");
                    break;
                case Command.UnlockPlayer:
                    UnlockPlayer(commandsStrings);
                    break;
                case Command.Map:
                    SetMap(commandsStrings);
                    break;
                case Command.Help:
                default:
                    DisplayHelp();
                    break;
            }
        }
    }

    private static void ResetHeroPools()
    {
        _picker.ResetHeroPools();
        _picker.PrintRecommendations();
    }

    private static void LockHeroForPlayer(string[] commandsStrings)
    {
        string playerName;
        List<string> heroes;
        try
        {
            playerName = commandsStrings[1];
            heroes = commandsStrings[2].Split(',').ToList();
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Missing inputs. Example command: lock jack dva,hanzo");
            return;
        }
        _picker.LockPlayer(playerName, heroes);
        _picker.PrintRecommendations();
    }

    private static void ResetEnemyTeam()
    {
        _picker.SetEnemyTeam();
        _picker.PrintRecommendations();
    }

    private static void ChangePlayerRole(string[] commandsStrings)
    {
        string playerName;
        string roleName;
        try
        {
            playerName = commandsStrings[1];
            roleName = commandsStrings[2];
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Missing inputs. Example command: changerole jack dps");
            return;
        }

        _picker.SetPlayerRole(playerName, roleName);
        _picker.PrintRecommendations();
    }

    private static void HardReset()
    {
        Console.Clear();
        Initialize();
    }

    private static void UnlockPlayer(string[] commandsStrings)
    {
        string playerName;
        try
        {
            playerName = commandsStrings[1];
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Missing inputs. Example command: unlock jack");
            return;
        }
        _picker.UnlockPlayer(playerName);
        _picker.PrintRecommendations();
    }

    private static void SetMap(string[] commandsStrings)
    {
        Map map;
        try
        {
            var mapString = commandsStrings[1];
            if (Enum.TryParse(mapString, out map))
            {
                Console.WriteLine(mapString);
                _picker.SetMap(map);
            }
            else
            {
                Console.WriteLine("Map not found.");
            }
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Missing inputs. Example command: map oasis");
        }
        _picker.PrintRecommendations();
    }

    private static void DisplayHelp()
    {
        Console.WriteLine("resetpools -- Reset player pools back to their proficiencies.");
        Console.WriteLine("lock <player name> <comma separated hero list> -- Forces the player into playing the hero list provided.");
        Console.WriteLine("enemy -- Redefine the enemy composition.");
        Console.WriteLine("changerole <player name> <new role> -- Changes the desired role for the player.");
        Console.WriteLine("map <map name> -- Changes the map.");
        Console.WriteLine("reset -- Forgets everything and reboots the app.");
    }

    private static void Initialize()
    {
        _picker = new HeroPicker();
        _picker.Play();
    }

    private enum EntityType
    {
        Players, Heroes, HeroPools, EnemyTeam, Roles
    }

    public static void SwapEnemyTeam(List<HeroName> newTeam)
    {
        _picker.SetEnemyTeam(newTeam);
        _picker.PrintRecommendations();
    }

    public static void AddFoe(HeroName foe)
    {
        _picker.AddFoe(foe);
        _picker.PrintRecommendations();
    }

    public enum Command
    {
        ResetHeroPools, LockHeroForPlayer, ResetEnemyTeam, ChangePlayerRole, HardReset, None, List, Help, UnlockPlayer, Map
    }

    private static Command GetCommandFromString(string command)
    {
        switch (command)
        {
            case "RESETPOOLS":
                return Command.ResetHeroPools;
            case "LOCK":
                return Command.LockHeroForPlayer;
            case "ENEMY":
                return Command.ResetEnemyTeam;
            case "CHANGEROLE":
                return Command.ChangePlayerRole;
            case "RESET":
                return Command.HardReset;
            case "LIST":
                return Command.List;
            case "UNLOCK":
                return Command.UnlockPlayer;
            case "MAP":
                return Command.Map;
            case "HELP":
                return Command.Help;
            default:
                Console.WriteLine("Command not found.");
                return Command.None;
        }
    }
}
