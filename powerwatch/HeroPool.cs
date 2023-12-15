using System.Collections.Generic;
using System;

class HeroPool
{
    public HeroPool(string playerName, List<HeroDefinition.HeroName> characters = null)
    {
        PlayerName = playerName;
        Characters = characters ?? new List<HeroDefinition.HeroName>();
    }

    public string PlayerName { get; set; }
    private List<HeroDefinition.HeroName> Characters { get; set; }

    public List<HeroDefinition.HeroName> GetCharacters()
    {
        if (Characters.Any())
        {
            return Characters;
        }
        return HeroDefinition.EveryHero();
    }


}