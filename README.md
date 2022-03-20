# Mega-Shooter-Fantasy

## Group Members
```
Ufuk Özkul 
Serhat Yokuşoğlu
Tolgay Atınç Uzun 
```

## Project Summary/Explanation
The game project will be based on a first-person, role-playing 3D game. The game has various facilities including skills, weapons, armors, melodies, stories, NPCs, character stats, story changing decisions. The mega shooter fantasy project has 2 parts; those are algorithm background and gameplay mechanics.

## Algorithm backgrounds
These algorithms will include more rendering based approaches for optimization as well as mathematical calculations and all NPCs decisions. In addition to that game supports A* search algorithm for path finding. To make the inventory system more lightweight, it will implement a heap priority queue. Also, to enable enemies to make rational decisions, enemies have a minimax algorithm where enemies try to minimize the player's advantage when player is trying to maximize his advantage in zero sum games.
## Gameplay mechanics
These mechanics will be implemented. Similar to the player, each enemy will have specific characteristics and stats such as level, health, attributes etc. Through this way, then the world will be more dynamic, lively, and present challenges to the player. Also, the game has a day-night loop that affects the gameplay style of the player. In day time, light type spells and enemies will gain buff, same way in night time dark type spells and enemies will gain buff. In the menu, the player will have numerous functionalities such as starting a new game, saving and loading, manipulating quality settings. In the options menu, sensitivity setting and master volume control, quality, screen resolution options can be found.

## Story
The main player was an astronaut that was sent into an exploration mission. In his exploration mission, he found an ancient technological portal. He wanted to inspect the portal, but he realized that the force field of the portal was too powerful. Not being able to escape the force field, he enters the portal. When he opened his eyes, he realized he was in a totally different world. Initially, he finds a wise creature there. This creature will guide the player in his quest for returning home safely. This world was devastated by a big war and the technological advancements were lost. He will be fighting the monsters that populate the planet. Even if he hates working with these monsters, he must choose a side. The clans which will be chosen at the campaign menu. With the survival elements, the main task is to find the mechanism that will send him to homeland. The base will be attacked. The menu and sound system will work together with the simplistic storyline.

# Project Tasks

## Random event system
An event can occur with certain probability after every game tick. The events will be predefined and decided in later stages.
## AI behavior(NPC)
NPC that gives rational decisions such as attack, block, dodge, chase and speak. 
NPCs are going to use A* algorithm to find path in minimap. Shortest path between the character and enemies will be calculated. This solves AI being stuck in some places. 
## Minimap
Player’s position is tracked with the bird's eye view and shown. Mission icons will be displayed here, too.
## Menu layout (canvas)
Players can adjust the volume, mouse sensitivity and graphics from the game menu.
## Skill tree, skills
After leveling up, players can choose the available skills from the skills tree. 
## Inventory system and User Interface 
Player can carry items with limited count and access those items anywhere also player can store items in chests
## NPC voices, animations
NPCs can interact with the player. NPCs have various types of sounds that are suitable for the current situation like attacking, hurting, dying and chatting.
## World design
Game world has various types of objects such as trees, stones, collectible resources and much more. Also, it has day-night routine, TBA
## Weapons, armors: magic, physical damage and resistance
The player can use different types of weapons to change the dealing damage type. There are 2 types of damage which are physical and magical. Armor decreases the taken physical damage and magical resistance decreases the taken magical damage.
## Melodies
Role playing experience increased with the different types of music.
## Character class
Common functionality will be gathered under this class. Damaging environment as well as specific damage criteria such as critical damage system Hero can deal 2x damage with a change
Game has different player types which affects the gameplay of the player. There are 4 types of characters which are sorcerer, assassin, and heavy. Sorcerers deal extra magical damage; assassins have increased speed and heavy class has more health points.
## Level up system
After killing enemies or completing the mission, players gain experience and use those experience points to level up the controlled hero.
## Character stats
Players can increase the stats of the hero and make it stronger. Stats are strength, agility, intelligence, endurance and luck. Details include, stamina, health, and mana which are calculated according to the stats. These will challenge the player as choices might lead to weaker or stronger character builds. Stamina limits the movement, health limits the durability and mana is used for casting spells.
Players can regenerate stamina, health and mana to maximum. 

## Story changing actions
Decisions that are offered from NPCs can change the future story of the game. In the game there are 2 sides: dark and light. Players must choose 1 side and battle with the other side.
## Stealth mechanic
If the player gets closer to the enemy without crouching, the enemy senses the movement of the player. If the player can approach the enemy without detection, a critical hit can be made. Otherwise, the enemy will see and attack the player as expected.
## Shop, coin mechanic
The player can buy or sell items to shopkeepers. Exchange of gold with weapons and armors are possible.
Mine system to obtain coin, mission system
The player can earn coins by working in a mine.  
## Day, night system, night vision
Enemies and the player will acquire time dependent skills. Some enemies will be stronger during the night. 
## Craft - loot mechanic
Collected items can be combined together to craft better items. 
## Farming mechanic 
The player can grow fruits or vegetables to earn coins by selling them or power up the controlled hero with the harvested orchard. 
## Drone system (extra camera view)
The player can explore the hidden areas with small drones.
These drones can act as turrets which automatically shoot enemies in a certain range.
## Map
Players can see the full game world with birds eye.
## Achievement system
Specific actions will be recorded in the game. By using them, completion of predeclared missions will be checked, awards will be given to the player.
## Projectile mechanic
Some items will have ranged attacks. Using different kinds of items, the projectile speed can be changed.
## Waypoint system
The player can change its position to a predefined area. So, the player does not have to spend it’s time just running continuously on the map.
## Backpack, weight, speed mechanics
Items that are carried in the backpack affect the movement speed of the controlled hero.
## Pet system
The player can adopt a pet to gain passive skills.
## Autopilot, auto run
Controlled hero can go to the target position without any command from the user. In that way we are aiming for a more comfortable game for the users.
## Random NPC stats generation & Boss fight system
Some enemies are stronger than normal enemies, it will make the game more competitive. Also, the prize of killing the bosses is more valuable for the game. Moreover, bosses are an essential part of the game since if you want to continue the journey, you have to kill the bosses. 
## Check point, save system
The player can save the current progress of the game after reaching specific points. If the player dies, he/she can continue the game on the activated points. 
## Collector
It collects and stores the resources in the world.
## Vehicle system
The player can use different types of vehicles to travel along the map. Also this system can be used for fast travel on the map.
## Telescope system
A player can zoom in/out into a certain distance with a gadget which is placed in the world.
## Easter eggs
Game has hidden fun facts. If the player finds these easter eggs, it can earn different types of guns or skills. So, these eggs have trivial effects on the game process. 