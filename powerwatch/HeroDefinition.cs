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
        new Hero { PlayedHero = HeroName.TORB, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.PHARAH, HeroName.JUNKRAT, HeroName.ECHO, HeroName.SOMBRA } },
        new Hero { PlayedHero = HeroName.TRACER, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.SYMMETRA, HeroName.TORB, HeroName.MEI, HeroName.MOIRA } },
        new Hero { PlayedHero = HeroName.WIDOWMAKER, Role = RoleName.DPS, Counters = new List<HeroName> { HeroName.GENJI, HeroName.TRACER, HeroName.ASHE, HeroName.ZENYATTA } },
        new Hero { PlayedHero = HeroName.ANA, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ORISA, HeroName.WINSTON, HeroName.RAMATTRA, HeroName.DOOMFIST, HeroName.ECHO, HeroName.PHARAH, HeroName.TRACER } },
        new Hero { PlayedHero = HeroName.BAPTISTE, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.GENJI, HeroName.TRACER, HeroName.HANZO, HeroName.ECHO, HeroName.PHARAH, HeroName.WIDOWMAKER, HeroName.SOMBRA, HeroName.CASSIDY, HeroName.ASHE, HeroName.LUCIO } },
        new Hero { PlayedHero = HeroName.BRIGITTE, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.PHARAH, HeroName.ECHO, HeroName.JUNKRAT } },
        new Hero { PlayedHero = HeroName.ILLARI, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ORISA, HeroName.ZARYA, HeroName.DVA, HeroName.CASSIDY, HeroName.GENJI, HeroName.MEI, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.KIRIKO, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ROADHOG, HeroName.TRACER, HeroName.SOMBRA, HeroName.GENJI, HeroName.MEI, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.LIFEWEAVER, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.SOMBRA, HeroName.SOLDIER76 } },
        new Hero { PlayedHero = HeroName.LUCIO, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.ROADHOG, HeroName.SOLDIER76, HeroName.CASSIDY, HeroName.ASHE, HeroName.WIDOWMAKER, HeroName.SYMMETRA, HeroName.TORB, HeroName.MEI, HeroName.MOIRA } },
        new Hero { PlayedHero = HeroName.MERCY, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.WINSTON, HeroName.ROADHOG, HeroName.ECHO, HeroName.CASSIDY, HeroName.WIDOWMAKER, HeroName.GENJI, HeroName.TRACER } },
        new Hero { PlayedHero = HeroName.MOIRA, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.ROADHOG, HeroName.ZARYA, HeroName.ECHO, HeroName.WIDOWMAKER, HeroName.JUNKRAT, HeroName.MEI, HeroName.ASHE, HeroName.PHARAH, HeroName.ANA } },
        new Hero { PlayedHero = HeroName.ZENYATTA, Role = RoleName.HEALER, Counters = new List<HeroName> { HeroName.JUNKRAT, HeroName.PHARAH, HeroName.CASSIDY, HeroName.WIDOWMAKER, HeroName.ASHE, HeroName.HANZO, HeroName.TRACER, HeroName.GENJI, HeroName.KIRIKO, HeroName.ZENYATTA } }
    };

    public static List<HeroName> GetHeroesByRole(RoleName role)
    {
        return Heroes.Where(x => x.Role == role).Select(x => x.PlayedHero).ToList();
    }

    public static Hero GetHeroFromName(HeroName name)
    {
        return Heroes.First(x => x.PlayedHero == name);
    }

    public static List<List<HeroName>> Synergies = new List<List<HeroName>>() 
    {
        new List<HeroName> () {HeroName.TRACER, HeroName.LUCIO},
        new List<HeroName> () {HeroName.MEI, HeroName.CASSIDY},
        new List<HeroName> () {HeroName.RAMATTRA, HeroName.ANA},
        new List<HeroName> () {HeroName.TRACER, HeroName.DVA},
        new List<HeroName> () {HeroName.SOLDIER76, HeroName.BAPTISTE},
        new List<HeroName> () {HeroName.ANA, HeroName.GENJI},
        new List<HeroName> () {HeroName.ZARYA, HeroName.REAPER},
        new List<HeroName> () {HeroName.ROADHOG, HeroName.ANA},
        new List<HeroName> () {HeroName.ROADHOG, HeroName.MERCY},
        new List<HeroName> () {HeroName.ANA, HeroName.REINHARDT},
        new List<HeroName> () {HeroName.KIRIKO, HeroName.REINHARDT},
        new List<HeroName> () {HeroName.BRIGITTE, HeroName.ZENYATTA},
        new List<HeroName> () {HeroName.HANZO, HeroName.ECHO},
        new List<HeroName> () {HeroName.REINHARDT, HeroName.LUCIO},
        new List<HeroName> () {HeroName.MERCY, HeroName.PHARAH},
        new List<HeroName> () {HeroName.MERCY, HeroName.ZENYATTA},
        new List<HeroName> () {HeroName.SOMBRA, HeroName.TRACER},
        new List<HeroName> () {HeroName.BRIGITTE, HeroName.REINHARDT},
        new List<HeroName> () {HeroName.BASTION, HeroName.SYMMETRA},
        new List<HeroName> () {HeroName.HANZO, HeroName.WIDOWMAKER},
        
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.BRIGITTE},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.BAPTISTE},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.KIRIKO},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.ANA},

        
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.REINHARDT},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.WRECKINGBALL},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.ZARYA},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.ASHE},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.BAPTISTE},
        new List<HeroName> () {HeroName.LIFEWEAVER, HeroName.MOIRA},

        new List<HeroName> () {HeroName.ILLARI, HeroName.ANA},
        new List<HeroName> () {HeroName.ILLARI, HeroName.BAPTISTE},
        new List<HeroName> () {HeroName.ILLARI, HeroName.MERCY},
        new List<HeroName> () {HeroName.ILLARI, HeroName.LUCIO},

        new List<HeroName> () {HeroName.ILLARI, HeroName.ORISA},
        new List<HeroName> () {HeroName.ILLARI, HeroName.WINSTON},
        new List<HeroName> () {HeroName.ILLARI, HeroName.WRECKINGBALL},

        new List<HeroName> () {HeroName.ILLARI, HeroName.TRACER},
        new List<HeroName> () {HeroName.ILLARI, HeroName.SOMBRA},
        new List<HeroName> () {HeroName.ILLARI, HeroName.CASSIDY},
        new List<HeroName> () {HeroName.ILLARI, HeroName.ASHE},

        
        new List<HeroName> () {HeroName.MAUGA, HeroName.BASTION},
        new List<HeroName> () {HeroName.MAUGA, HeroName.ILLARI},
        new List<HeroName> () {HeroName.MAUGA, HeroName.TORB},

        new List<HeroName> () {HeroName.MAUGA, HeroName.SOJOURN},
        new List<HeroName> () {HeroName.MAUGA, HeroName.HANZO},
        new List<HeroName> () {HeroName.MAUGA, HeroName.CASSIDY},
        new List<HeroName> () {HeroName.MAUGA, HeroName.SOLDIER76},
        new List<HeroName> () {HeroName.MAUGA, HeroName.MERCY},
        new List<HeroName> () {HeroName.MAUGA, HeroName.ZENYATTA},
        new List<HeroName> () {HeroName.MAUGA, HeroName.JUNKRAT},
        new List<HeroName> () {HeroName.MAUGA, HeroName.SOMBRA},
        new List<HeroName> () {HeroName.MAUGA, HeroName.ASHE},
        new List<HeroName> () {HeroName.MAUGA, HeroName.PHARAH}
    };

    public static List<HeroName> EveryHero()
    {
        return new List<HeroName>(Enum.GetValues(typeof(HeroName)) as HeroName[]);
    }

    private Dictionary<Map, MapType> _mapTypes = new Dictionary<Map, MapType>
    {
        { Map.CIRCUIT_ROYAL, MapType.ESCORT },
        { Map.DORADO, MapType.ESCORT },
        { Map.ROUTE66, MapType.ESCORT },
        { Map.JUNKERTOWN, MapType.ESCORT },
        { Map.RIALTO, MapType.ESCORT },
        { Map.HAVANA, MapType.ESCORT },
        { Map.GIBRALTAR, MapType.ESCORT },
        { Map.SHAMBALI, MapType.ESCORT },

        { Map.BLIZZARD_WORLD, MapType.HYBRID},
        { Map.NUMBANI, MapType.HYBRID},
        { Map.HOLLYWOOD, MapType.HYBRID},
        { Map.EICHENWALDE, MapType.HYBRID},
        { Map.KINGS_ROW, MapType.HYBRID},
        { Map.MIDTOWN, MapType.HYBRID},
        { Map.PARAISO, MapType.HYBRID},
        
        { Map.BUSAN, MapType.CONTROL},
        { Map.NEPAL, MapType.CONTROL},
        { Map.ILIOS, MapType.CONTROL},
        { Map.OASIS, MapType.CONTROL},
        { Map.LIJANG, MapType.CONTROL},
        { Map.ANTARTIC, MapType.CONTROL},
        { Map.SAMOA, MapType.CONTROL}, 
        
        { Map.COLOSSEO, MapType.PUSH},
        { Map.ESPERANCA, MapType.PUSH},
        { Map.NEW_QUEEN, MapType.PUSH},
    };

    private Dictionary<Map, List<HeroName>> HeroMapSynergies = new Dictionary<Map, List<HeroName>>
    {
        { Map.COLOSSEO, new List<HeroName> { HeroName.WINSTON } },
        { Map.ESPERANCA, new List<HeroName> { HeroName.WRECKINGBALL } },
        { Map.NEW_QUEEN, new List<HeroName> { HeroName.REINHARDT } },
        { Map.ILIOS, new List<HeroName> { HeroName.ROADHOG, HeroName.WINSTON, HeroName.TRACER, HeroName.ASHE, HeroName.BASTION, HeroName.BRIGITTE, HeroName.DVA, HeroName.DOOMFIST, HeroName.ILLARI, HeroName.JUNKERQUEEN, HeroName.JUNKRAT, HeroName.LUCIO, HeroName.MAUGA, HeroName.ORISA, HeroName.PHARAH, HeroName.REINHARDT, HeroName.ROADHOG, HeroName.SIGMA, HeroName.WINSTON, HeroName.WRECKINGBALL, HeroName.ZARYA, HeroName.ZENYATTA } },
        { Map.LIJANG, new List<HeroName> { HeroName.WINSTON, HeroName.SYMMETRA, HeroName.MERCY, HeroName.PHARAH, HeroName.GENJI, HeroName.PHARAH, HeroName.TRACER } },
        { Map.NEPAL, new List<HeroName> { HeroName.ROADHOG, HeroName.ZARYA, HeroName.ORISA, HeroName.MEI, HeroName.SYMMETRA, HeroName.PHARAH, HeroName.LUCIO, HeroName.WINSTON, HeroName.ROADHOG } },
        { Map.OASIS, new List<HeroName> { HeroName.WRECKINGBALL, HeroName.TRACER } },
        { Map.CIRCUIT_ROYAL, new List<HeroName> { HeroName.SIGMA, HeroName.ZARYA, HeroName.PHARAH, HeroName.ECHO, HeroName.SOLDIER76, HeroName.WIDOWMAKER, HeroName.ASHE, HeroName.HANZO  } },
        { Map.DORADO, new List<HeroName> { HeroName.REINHARDT, HeroName.ZARYA, HeroName.WIDOWMAKER, HeroName.HANZO, HeroName.CASSIDY, HeroName.TORB,  } },
        { Map.JUNKERTOWN, new List<HeroName> { HeroName.DVA, HeroName.WINSTON, HeroName.ROADHOG, HeroName.WIDOWMAKER } },
        { Map.ROUTE66, new List<HeroName> { HeroName.ORISA, HeroName.SIGMA, HeroName.BAPTISTE, HeroName.DVA, HeroName.PHARAH, HeroName.HANZO, HeroName.MEI, HeroName.SOMBRA } },
        { Map.GIBRALTAR, new List<HeroName> { HeroName.SIGMA, HeroName.WINSTON, HeroName.GENJI, HeroName.ASHE } },
        { Map.BLIZZARD_WORLD, new List<HeroName> { HeroName.ORISA, HeroName.WINSTON, HeroName.WRECKINGBALL } },
        { Map.EICHENWALDE, new List<HeroName> { HeroName.REINHARDT, HeroName.ZARYA, HeroName.SIGMA } },
        { Map.HOLLYWOOD, new List<HeroName> { HeroName.DVA, HeroName.ROADHOG } },
        { Map.KINGS_ROW, new List<HeroName> { HeroName.REINHARDT, HeroName.ORISA, HeroName.MEI } },
        { Map.MIDTOWN, new List<HeroName> { HeroName.ZARYA, HeroName.DVA, HeroName.SIGMA } },
        { Map.NUMBANI, new List<HeroName> { HeroName.ZARYA, HeroName.ORISA, HeroName.WINSTON, HeroName.DOOMFIST } },
        { Map.PARAISO, new List<HeroName> { HeroName.REINHARDT, HeroName.SIGMA, HeroName.ROADHOG, HeroName.ZARYA } },
        { Map.BUSAN, new List<HeroName> { HeroName.DVA, HeroName.WRECKINGBALL } },
        { Map.NEW_JUNK_CITY, new List<HeroName> { HeroName.REAPER, HeroName.SOMBRA, HeroName.JUNKRAT, HeroName.SOLDIER76, HeroName.GENJI, HeroName.TRACER, HeroName.LUCIO } },
        { Map.SURAVASA, new List<HeroName> { HeroName.REINHARDT, HeroName.MEI, HeroName.REAPER, HeroName.LUCIO, HeroName.BAPTISTE } },
        { Map.SAMOA, new List<HeroName> { HeroName.LUCIO } },
    };

    private Dictionary<TeamSide, List<HeroName>> HeroTeamSideTypeSynergies = new Dictionary<TeamSide, List<HeroName>>
    {
        { TeamSide.ATTACK , new List<HeroName> { HeroName.WINSTON, HeroName.DVA, HeroName.PHARAH, HeroName.TORB, HeroName.SYMMETRA } },
        { TeamSide.DEFEND , new List<HeroName> { HeroName.ZARYA, HeroName.ROADHOG, HeroName.ORISA, HeroName.REINHARDT, HeroName.SIGMA } },
    };

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
    TORB,
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

public enum RoleName
{
    TANK,
    DPS,
    HEALER
}

public enum Map
{
    NONE,
    CIRCUIT_ROYAL, DORADO, ROUTE66, JUNKERTOWN, RIALTO, HAVANA, GIBRALTAR, SHAMBALI,
    BLIZZARD_WORLD, NUMBANI, HOLLYWOOD, EICHENWALDE, KINGS_ROW, MIDTOWN, PARAISO,
    BUSAN, NEPAL, ILIOS, OASIS, LIJANG, ANTARTIC, SAMOA,
    COLOSSEO, ESPERANCA, NEW_QUEEN,
    NEW_JUNK_CITY, SURAVASA
}

public enum MapType
{
    ESCORT, HYBRID, CONTROL, PUSH, FLASHPOINT, NONE
}

public enum TeamSide
{
    ATTACK, DEFEND, NEUTRAL
}