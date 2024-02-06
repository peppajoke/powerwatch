using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class HeroWinRateRanker
{
    private WebFetcher _webFetcher;
    private List<HeroInfo> _rankedHeroes;

    public HeroWinRateRanker()
    {
        _webFetcher = new WebFetcher();
        setRankedHeroes();
    }


    public int GetScoreForHero(HeroName hero)
    {
        int totalHeroes = _rankedHeroes.Count;

        // Find the index of the hero in the ordered list
        int heroIndex = _rankedHeroes.FindIndex(heroInfo => heroInfo.HeroName.ToString() == hero.ToString());

        if (heroIndex >= 0)
        {
            // Calculate the percentile based on the position in the ordered list
            double percentile = (double)heroIndex / totalHeroes;

            // Map the percentile to a score in the range [0, 5]
            int score = (int)(50 * (1 - percentile));

            return score;
        }

        // If the hero is not found, return a default score (e.g., -1)
        return -1;
    }

    private void setRankedHeroes()
    {
        _rankedHeroes = new List<HeroInfo>();

        // Define the pattern using regular expression
        string pattern = @"/heroes/(\w+).*?<span>(\d+\.\d+)<span class=""text-sm ml-\[1px\]"">%</span>.*?<span>(\d+\.\d+)<span class=""text-sm ml-\[1px\]"">%</span></span>";

        string heroPageContent = _webFetcher.GetTopWinRatePage();

        // Match the pattern in the input string
        MatchCollection matches = Regex.Matches(heroPageContent, pattern, RegexOptions.Singleline);

        // Extract the matched hero names and the second decimal values
        foreach (Match match in matches)
        {
            if (match.Groups.Count == 4)
            {
                string heroNameString = match.Groups[1].Value.ToUpper();
                string winRateValue = match.Groups[3].Value;

                if (Enum.TryParse<HeroName>(heroNameString, out HeroName heroName))
                {
                    _rankedHeroes.Add(new HeroInfo(heroName, Convert.ToDouble(winRateValue)));
                }
                else
                {
                    switch(heroNameString)
                    {
                        case "SOLDIER":
                            _rankedHeroes.Add(new HeroInfo(HeroName.SOLDIER76, Convert.ToDouble(winRateValue)));
                            break;
                        case "JUNKER":
                            _rankedHeroes.Add(new HeroInfo(HeroName.JUNKERQUEEN, Convert.ToDouble(winRateValue)));
                            break;
                        case "TORBJORN":
                            _rankedHeroes.Add(new HeroInfo(HeroName.TORB, Convert.ToDouble(winRateValue)));
                            break;
                        case "WRECKING":
                            _rankedHeroes.Add(new HeroInfo(HeroName.WRECKINGBALL, Convert.ToDouble(winRateValue)));
                            break;
                        default:
                            Console.WriteLine($"Unknown hero: {heroNameString}");
                            break;
                            
                    }
                }
            }
        }

        // Order the list based on win rate values
        _rankedHeroes = _rankedHeroes.OrderByDescending(heroInfo => heroInfo.WinRate).ToList();
    }

    public class HeroInfo
    {
        public HeroName HeroName { get; }
        public double WinRate { get; }

        public HeroInfo(HeroName heroName, double winRate)
        {
            HeroName = heroName;
            WinRate = winRate;
        }
    }
}
