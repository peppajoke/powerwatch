![Build Status](https://github.com/peppajoke/powerwatch/actions/workflows/dotnet.yml/badge.svg)

# powerwatch

**Automation to make you suck less at Overwatch.**

This program will ingest information about your team, roles, hero proficiencies, and your enemy team. It will then come up with some suggestions on what heroes you should be playing so you can kick some ass.

Before runtime, fill in your team's hero proficiencies in HeroPicker.cs under PlayerProficiencies. Eventually, I'll move this to a cleaner place.

`dotnet run`

It will ask you to describe your team. Player names and roles.

After the initial run, use these commands to change state and get new recommendations:

`resetpools` -- Reset player pools back to their proficiencies, overriding any locks. Does not reset role selections.

`lock [player name] [comma separated hero list]` -- This is for Phil. Forces the player into playing the hero list provided.

`enemy` -- Redefine the enemy composition.

`map [map name]` -- Sets the map.

`side [side]` -- Sets the team side. attack, defend, or neutral

`changerole [player name] [new role]` -- Changes the desired role for the player.

`reset` -- Forgets everything and reboots the app.

Most commands will give you a new sheet of recommendations automatically, after you run them.

**Using voice to change enemies while playing**

Since it's tough to type in enemy teams during play, if you have a mic set up and are running this app in windows, you can speak to the app to update the enemy team.


`enemy` -- initiates an enemy list redo. After saying this, speak the names of 5 heroes, and it will update your enemy list, producing new recommendations.

`foe reset` -- deletes the current enemy team

`add foe` -- adds an enemy hero. You must say the name of the hero afterwards

# How does powerwatch decide what heroes to recommend?
There are several datapoints that powerwatch will use to make recommendations. Each are scored and applied before making a final set of recommendations to your team.

1. Player proficiency weights. In the [HeroPicker class](https://github.com/peppajoke/powerwatch/blob/main/powerwatch/HeroPicker.cs#L8), you can specify your players, which heroes they are comfortable playing, as well as a "proficiency preference", which tells powerwatch how highly to weight your preferred heroes. A 0 value would mean you're open to playing and hero, and a 10 value would mean you really want to try and just stick to your proficient characters.
2. Hero counters. Many heroes are generally considered to be strong counter choices, for example, Reinhardt is generally considered to be an optimal choice against DVA, due to his shield. Powerwatch will apply all known counters to the enemy team, this is a big part of its recommendations. These counters have been manually collected from forums and articles, and placed into the data inside of the algorithm since this information is very scattered over the many years of Overwatch's lifecycle.
3. Hero synergies. Many heroes work well together on the same team. For example, Lucio and Tracer both have incredible movement abilities and when paired, the enemy team has a really hard time hitting either of them, making them a synergy. Powerwatch will try its best to give you team recommendations that exploit any possible synergy.
4. Competitive statistics. When powerwatch is initialized, it will connect to [overbuff](https://www.overbuff.com/heroes?platform=pc&timeWindow=month) to fetch the most current competitive statistics, basically telling it generally, which heroes are most successful right now. This data point serves as a tie breaker mostly, if there are two equal recommendations, it will pick the one that has a statistically competitive advantage.

# Enemy specific recommendations
By default, powerwatch will give you a recommendation based on the entire enemy team. However, it will also print out team recommendations for each individual enemy hero, in case one in particular is giving your team trouble. For example, if there's a Widowmaker taking out your team consistently, you can follow the Widowmaker counter recommendation, so that your entire team can shift into a composition that can handle Widowmaker.
