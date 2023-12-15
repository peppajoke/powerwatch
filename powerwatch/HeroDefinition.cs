public class HeroDefinition
{
    public static List<Hero> Heroes = new List<Hero>
    {
        new Hero { PlayedHero = HeroName.DOOMFIST, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.WRECKINGBALL, HeroName.SOMBRA, HeroName.PHARAH, HeroName.LUCIO, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.DVA, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.ZARYA, HeroName.REINHARDT, HeroName.WINSTON, HeroName.RAMATTRA, HeroName.SYMMETRA, HeroName.BRIGITTE } },
        new Hero { PlayedHero = HeroName.JUNKERQUEEN, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.PHARAH, HeroName.ECHO, HeroName.KIRIKO, HeroName.BAPTISTE } },
        new Hero { PlayedHero = HeroName.MAUGA, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.SIGMA, HeroName.DVA, HeroName.ZARYA, HeroName.MEI, HeroName.SOMBRA, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.ORISA, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.WRECKINGBALL, HeroName.GENJI, HeroName.TRACER, HeroName.SOMBRA, HeroName.REAPER, HeroName.ECHO } },
        new Hero { PlayedHero = HeroName.RAMATTRA, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.ROADHOG, HeroName.REAPER, HeroName.TRACER, HeroName.GENJI, HeroName.ECHO, HeroName.PHARAH } },
        new Hero { PlayedHero = HeroName.REINHARDT, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.TRACER, HeroName.GENJI, HeroName.PHARAH, HeroName.ECHO, HeroName.REAPER, HeroName.BASTION, HeroName.JUNKRAT } },
        new Hero { PlayedHero = HeroName.ROADHOG, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.JUNKERQUEEN, HeroName.REAPER, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.SIGMA, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.SOJOURN, HeroName.WIDOWMAKER, HeroName.HANZO, HeroName.LUCIO, HeroName.BAPTISTE, HeroName.KIRIKO } },
        new Hero { PlayedHero = HeroName.WINSTON, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.ROADHOG, HeroName.REAPER, HeroName.MEI, HeroName.BASTION } },
        new Hero { PlayedHero = HeroName.WRECKINGBALL, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.SOMBRA, HeroName.JUNKRAT, HeroName.MEI, HeroName.BRIGITTE } },
        new Hero { PlayedHero = HeroName.ZARYA, Role = RoleName.TANK, Counters = new List<HeroName> { HeroName.KIRIKO, HeroName.BAPTISTE, HeroName.ZENYATTA, HeroName.LUCIO } },
        new Hero { PlayedHero = HeroName.ASHE, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.GENJI, HeroName.TRACER, HeroName.ECHO, HeroName.SOLDIER76, HeroName.CASSIDY } },
        new Hero { PlayedHero = HeroName.BASTION, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.ZARYA, HeroName.ROADHOG, HeroName.WRECKINGBALL, HeroName.JUNKRAT, HeroName.PHARAH, HeroName.GENJI, HeroName.TRACER, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.CASSIDY, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.REINHARDT, HeroName.WINSTON, HeroName.GENJI, HeroName.CASSIDY } },
        new Hero { PlayedHero = HeroName.ECHO, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.ORISA, HeroName.ASHE, HeroName.CASSIDY, HeroName.SOLDIER76, HeroName.WIDOWMAKER } },
        new Hero { PlayedHero = HeroName.GENJI, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.ZARYA, HeroName.SYMMETRA, HeroName.MEI, HeroName.MOIRA } },
        new Hero { PlayedHero = HeroName.HANZO, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.DVA, HeroName.WRECKINGBALL, HeroName.TRACER, HeroName.PHARAH, HeroName.GENJI, HeroName.LUCIO } },
        new Hero { PlayedHero = HeroName.JUNKRAT, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.ZARYA, HeroName.WRECKINGBALL, HeroName.CASSIDY, HeroName.SOLDIER76, HeroName.GENJI, HeroName.PHARAH, HeroName.ECHO, HeroName.TRACER, HeroName.LUCIO } },
        new Hero { PlayedHero = HeroName.MEI, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.SOMBRA, HeroName.PHARAH, HeroName.ECHO, HeroName.SOLDIER76, HeroName.ASHE, HeroName.WIDOWMAKER } },
        new Hero { PlayedHero = HeroName.PHARAH, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.DVA, HeroName.SOLDIER76, HeroName.CASSIDY, HeroName.ASHE, HeroName.WIDOWMAKER } },
        new Hero { PlayedHero = HeroName.REAPER, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.PHARAH, HeroName.ECHO, HeroName.JUNKRAT, HeroName.WIDOWMAKER, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.SOJOURN, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.GENJI, HeroName.TRACER, HeroName.LUCIO } },
        new Hero { PlayedHero = HeroName.SOLDIER76, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.ROADHOG, HeroName.ASHE, HeroName.CASSIDY, HeroName.GENJI, HeroName.JUNKRAT } },
        new Hero { PlayedHero = HeroName.SOMBRA, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.PHARAH, HeroName.JUNKRAT, HeroName.HANZO, HeroName.MEI, HeroName.KIRIKO, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.SYMMETRA, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.PHARAH, HeroName.JUNKRAT, HeroName.ECHO } },
        new Hero { PlayedHero = HeroName.TORBJORN, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.PHARAH, HeroName.JUNKRAT, HeroName.ECHO, HeroName.SOMBRA } },
        new Hero { PlayedHero = HeroName.TRACER, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.SYMMETRA, HeroName.TORBJORN, HeroName.MEI, HeroName.MOIRA } },
        new Hero { PlayedHero = HeroName.WIDOWMAKER, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.GENJI, HeroName.TRACER, HeroName.ASHE, HeroName.ZENYATTA } },
        new Hero { PlayedHero = HeroName.ANA, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ORISA, HeroName.WINSTON, HeroName.RAMATTRA, HeroName.DOOMFIST, HeroName.ECHO, HeroName.PHARAH, HeroName.TRACER } },
        new Hero { PlayedHero = HeroName.BAPTISTE, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.GENJI, HeroName.TRACER, HeroName.HANZO, HeroName.ECHO, HeroName.PHARAH, HeroName.WIDOWMAKER, HeroName.SOMBRA, HeroName.CASSIDY, HeroName.ASHE, HeroName.LUCIO } },
        new Hero { PlayedHero = HeroName.BRIGITTE, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.PHARAH, HeroName.ECHO, HeroName.JUNKRAT } },
        new Hero { PlayedHero = HeroName.ILLARI, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ORISA, HeroName.ZARYA, HeroName.DVA, HeroName.CASSIDY, HeroName.GENJI, HeroName.MEI, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.KIRIKO, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ROADHOG, HeroName.TRACER, HeroName.SOMBRA, HeroName.GENJI, HeroName.MEI, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.LIFEWEAVER, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.SOMBRA, HeroName.SOLDIER76 } },
        new Hero { PlayedHero = HeroName.LUCIO, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.ROADHOG, HeroName.SOLDIER76, HeroName.CASSIDY, HeroName.ASHE, HeroName.WIDOWMAKER, HeroName.SYMMETRA, HeroName.TORBJORN, HeroName.MEI, HeroName.MOIRA } },
        new Hero { PlayedHero = HeroName.MERCY, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.ROADHOG, HeroName.ECHO, HeroName.CASSIDY, HeroName.WIDOWMAKER, HeroName.GENJI, HeroName.TRACER } },
        new Hero { PlayedHero = HeroName.MOIRA, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ROADHOG, HeroName.ZARYA, HeroName.ECHO, HeroName.WIDOWMAKER, HeroName.JUNKRAT, HeroName.MEI, HeroName.ASHE, HeroName.PHARAH, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.ZENYATTA, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.JUNKRAT, HeroName.PHARAH, HeroName.CASSIDY, HeroName.WIDOWMAKER, HeroName.ASHE, HeroName.HANZO, HeroName.TRACER, HeroName.GENJI, HeroName.KIRIKO, HeroName.ZENYATTA } }
    };

    public static Hero GetHeroFromName(HeroName name)
    {
        return Heroes.First(x => x.PlayedHero == name);
    }

    public static List<List<HeroName>> Synergies = new List<List<HeroName>>() 
    {
        new List<HeroName> () {HeroName.TRACER, HeroName.LUCIO},
        //new List<Hero> () {HeroName.TRACER, HeroName.DVA},
        //new List<Hero> () {HeroName.RAMATTRA, HeroName.ANA},
    };

    public static List<HeroName> EveryHero()
    {
        return new List<HeroName>(Enum.GetValues(typeof(HeroName)) as HeroName[]);
    }

    public enum RoleName
    {
        TANK,
        DPS,
        HEALER
    }

    public enum HeroName
    {
        DOOMFIST,
        DVA,
        JUNKERQUEEN,
        MAUGA,
        ORISA,
        RAMATTRA,
        REINHARDT,
        ROADHOG,
        SIGMA,
        WINSTON,
        WRECKINGBALL,
        ZARYA,
        ASHE,
        BASTION,
        CASSIDY,
        ECHO,
        GENJI,
        HANZO,
        JUNKRAT,
        MEI,
        PHARAH,
        REAPER,
        SOJOURN,
        SOLDIER76,
        SOMBRA,
        SYMMETRA,
        TORBJORN,
        TRACER,
        WIDOWMAKER,
        ANA,
        BAPTISTE,
        BRIGITTE,
        ILLARI,
        KIRIKO,
        LIFEWEAVER,
        LUCIO,
        MERCY,
        MOIRA,
        ZENYATTA
    }
}