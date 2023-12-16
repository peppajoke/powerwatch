using System.Collections.Generic;
using System;

class HeroPool
{
    public HeroPool(string playerName, List<HeroName> characters = null)
    {
        PlayerName = playerName;
        Characters = characters ?? new List<HeroName>();
    }

    public string PlayerName { get; set; }
    private List<HeroName> Characters { get; set; }

    public List<HeroName> GetCharacters()
    {
        if (Characters.Any())
        {
            return Characters;
        }
        return HeroDefinition.EveryHero();
    }
}