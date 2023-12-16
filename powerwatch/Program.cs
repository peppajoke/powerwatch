using System;

class Program
{
    private static HeroPicker _picker;

    static void Main(string[] args)
    {
        Initialize();

        var listener = new SpeechListener();
        listener.Listen();
    
        var quit = false;

        while (!quit)
        {
            var commandsStrings = Console.ReadLine().ToUpper().Split(' ');

            if (commandsStrings.Count() == 0)
            {
                continue;
            }

            var firstCommandString = commandsStrings[0];

            var command = GetCommandFromString(firstCommandString);

            switch(command)
            {
                case Command.ResetHeroPools:
                    _picker.ResetHeroPools();
                    _picker.PrintRecommendations();
                    break;
                case Command.LockHeroForPlayer:
                    string playerName;
                    List<string> heroes;
                    try 
                    {
                        playerName = commandsStrings[1];
                        heroes = commandsStrings[2].Split(',').ToList();
                    }
                    catch(IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Missing inputs. Example command: lock jack dva,hanzo");
                        break;
                    }
                    _picker.LockPlayer(playerName, heroes);
                    _picker.PrintRecommendations();
                    break;
                case Command.ResetEnemyTeam:
                    _picker.SetEnemyTeam();
                    _picker.PrintRecommendations();
                    break;
                case Command.ChangePlayerRole:
                    string roleName;
                    try 
                    {
                        playerName = commandsStrings[1];
                        roleName = commandsStrings[2];
                    }
                    catch(IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Missing inputs. Example command: changerole jack dps");
                        break;
                    }

                    _picker.SetPlayerRole(playerName, roleName);                    
                    _picker.PrintRecommendations();
                    break;
                case Command.HardReset:
                    Console.Clear();
                    Initialize();
                    break;
                case Command.List:
                    Console.WriteLine("Sorry, I haven't coded this one yet.");
                    break;
                case Command.UnlockPlayer:
                    try 
                    {
                        playerName = commandsStrings[1];
                    }
                    catch(IndexOutOfRangeException ex)
                    {
                        Console.WriteLine("Missing inputs. Example command: unlock jack");
                        break;
                    }
                    _picker.UnlockPlayer(playerName);
                    _picker.PrintRecommendations();
                    break;
                case Command.Help:
                default:
                    Console.WriteLine("resetpools -- Reset player pools back to their proficiencies.");
                    Console.WriteLine("lock <player name> <comma separated hero list> -- Forces the player into playing the hero list provided.");
                    Console.WriteLine("enemy -- Redefine the enemy composition.");
                    Console.WriteLine("changerole <player name> <new role> -- Changes the desired role for the player.");
                    Console.WriteLine("reset -- Forgets everything and reboots the app.");
                    break;
            }
        }
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

    private static void Initialize()
    {
        _picker = new HeroPicker();
        _picker.Play();
    }

    public enum Command
    {
        ResetHeroPools, LockHeroForPlayer, ResetEnemyTeam, ChangePlayerRole, HardReset, None, List, Help, UnlockPlayer
    }

    private static Command GetCommandFromString(string command)
    {
        switch(command)
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
            case "HELP":
                return Command.Help;
            default:
                Console.WriteLine("Command not found.");
                return Command.None;
        }
    }
}