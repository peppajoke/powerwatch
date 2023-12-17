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
