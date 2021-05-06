# Guild

Problem description

Your task is to create a repository which stores players by creating the classes described below.

First, write a C# class __Player__ with the following properties:
- __Name: string__
- __Class: string__
- __Rank: string – "Trial" by default__
- __Description: string – "n/a" by default__

The class __constructor__ should receive __name__ and __class__. Override the __ToString()__ method in the following format:

__"Player {Name}: {Class}<br>
Rank: {Rank}<br>
Description: {Description}"__

Next, write a C# class __Guild__ that has __a roster__ (a collection which stores the entity __Player__). All entities inside the repository have the __same properties__. Also, the __Guild__ class should have those __properties__:

- __Name: string__
- __Capacity: int__

The class __constructor__ should receive __name__ and __capacity__, also it should initialize the __roster__ with a new instance of the collection. Implement the following features:

- Field __roster - collection__ that holds added __players__
- Method __AddPlayer(Player player)__ - adds an entity to the roster if there is room for it
- Method __RemovePlayer(string name)__ - removes a player by given name, if such exists, and returns bool
- Method __PromotePlayer(string name)__ - promote (set his rank to "Member") the first player with the given name. If the player is already a "Member", do nothing.
- Method __DemotePlayer(string name)__- demote (set his rank to "Trial") the first player with the given name. If the player is already a "Trial",  do nothing.
- Method __KickPlayersByClass(string class)__ - removes all the players by the given class and returns all players from that class as an array
- Getter __Count__ - returns the number of players
- __Report()__ - returns a string in the following format:	

__"Players in the guild: {guildName}<br>
{Player1}<br>
{Player2}<br>
(…)"__

## Constraints
- The names of the players will be always __unique__.
- You will always have a player added before receiving methods manipulating the Guild's players.

## Examples
This is an example how the Guild class is intended to be used. 

```c#
//Initialize the repository (guild)
Guild guild = new Guild("Weekend Raiders", 20);
//Initialize entity
Player player = new Player("Mark", "Rogue");
//Print player
Console.WriteLine(player); //Player Mark: Rogue
                           //Rank: Trial
                           //Description: n/a

//Add player
guild.AddPlayer(player);
Console.WriteLine(guild.Count); //1
Console.WriteLine(guild.RemovePlayer("Gosho")); //False

Player firstPlayer = new Player("Pep", "Warrior");
Player secondPlayer = new Player("Lizzy", "Priest");
Player thirdPlayer = new Player("Mike", "Rogue");
Player fourthPlayer = new Player("Marlin", "Mage");

//Add description to player
secondPlayer.Description = "Best healer EU";

//Add players
guild.AddPlayer(firstPlayer);
guild.AddPlayer(secondPlayer);
guild.AddPlayer(thirdPlayer);
guild.AddPlayer(fourthPlayer);

//Promote player
guild.PromotePlayer("Lizzy");

//RemovePlayer
Console.WriteLine(guild.RemovePlayer("Pep")); //True

Player[] kickedPlayers = guild.KickPlayersByClass("Rogue");
Console.WriteLine(string.Join(", ", kickedPlayers.Select(p => p.Name))); //Mark, Mike

Console.WriteLine(guild.Report());
//Players in the guild: Weekend Raiders
//Player Lizzy: Priest
//Rank: Member
//Description: Best healer EU
//Player Marlin: Mage
//Rank: Trial
//Description: n/a
```
