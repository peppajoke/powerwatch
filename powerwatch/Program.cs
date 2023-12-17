class Program
{
    private static HeroPicker _picker;

    static void Main()
    {
        Initialize();

        var listener = new SpeechListener();
        listener.Listen();

        while (true)
        {
            var commandsStrings = Console.ReadLine()?.ToUpper().Split(' ') ?? Array.Empty<string>();

            if (commandsStrings.Length == 0)
                continue;

            var command = GetCommandFromString(commandsStrings[0]);

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
                case Command.Side:
                    SetSide(commandsStrings);
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
        try
        {
            var playerName = commandsStrings[1];
            var heroes = commandsStrings[2].Split(',').ToList();
            _picker.LockPlayer(playerName, heroes);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Missing inputs. Example command: lock jack dva,hanzo");
            return;
        }

        _picker.PrintRecommendations();
    }

    private static void ResetEnemyTeam()
    {
        _picker.SetEnemyTeam();
        _picker.PrintRecommendations();
    }

    private static void ChangePlayerRole(string[] commandsStrings)
    {
        try
        {
            var playerName = commandsStrings[1];
            var roleName = commandsStrings[2];
            _picker.SetPlayerRole(playerName, roleName);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Missing inputs. Example command: changerole jack dps");
            return;
        }

        _picker.PrintRecommendations();
    }

    private static void HardReset()
    {
        Console.Clear();
        Initialize();
    }

    private static void UnlockPlayer(string[] commandsStrings)
    {
        try
        {
            var playerName = commandsStrings[1];
            _picker.UnlockPlayer(playerName);
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Missing inputs. Example command: unlock jack");
            return;
        }

        _picker.PrintRecommendations();
    }

    private static void SetMap(string[] commandsStrings)
    {
        try
        {
            var mapString = commandsStrings[1];
            if (Enum.TryParse(mapString, out Map map))
                _picker.SetMap(map);
            else
                Console.WriteLine("Map not found.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Missing inputs. Example command: map oasis");
        }

        _picker.PrintRecommendations();
    }

    private static void SetSide(string[] commandsStrings)
    {
        try
        {
            var mapString = commandsStrings[1];
            if (Enum.TryParse(mapString, out TeamSide side))
                _picker.SetTeamSide(side);
            else
                Console.WriteLine("Side not found.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Missing inputs. Example command: side attack");
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
        Console.WriteLine("side <side> -- Changes the team side.");
        Console.WriteLine("reset -- Forgets everything and reboots the app.");
    }

    private static void Initialize()
    {
        _picker = new HeroPicker();
        _picker.Play();
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
        ResetHeroPools, LockHeroForPlayer, ResetEnemyTeam, ChangePlayerRole, HardReset, None, List, Help, UnlockPlayer, Map, Side
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
            case "SIDE":
                return Command.Side;
            default:
                Console.WriteLine("Command not found.");
                return Command.None;
        }
    }
}
