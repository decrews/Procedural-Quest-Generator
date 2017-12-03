# Procedural Quest Generator
## Quest generator for C# / Unity

This project implements the quest generating algorithm described by Jonathon Doran and Ian Parberry in [A Prototype Quest Generator Based on a
Structural Analysis of Quests from Four MMORPGs](http://larc.unt.edu/ian/pubs/pcg2011.pdf).

The Unity project contains classes for generating quests, displaying the underlying tree structure to a Unity UI Canvas, and displaying the quest as a series of steps on a UI Canvas.  A general motive for the quest, such as "knowledge", can be provided to get a quest specific to a situation.

The generator creates a tree where each node is an Action the player must take to complete the quest.  Preorder traversal is the order the game should follow when presenting the player with the quest chain.  By traversing the tree in this way, the player is first presented with a quest at the root node and then needs to complete the children to finish the quest.

Data for the quests are gathered from scriptable objects.  Scriptable objects should contain data for NPCs, Locations, Enemies, and Items with fields for how they are related to each other.  This makes it easy to add data from inside Unity Editor without needing to load a script.

There are still some errors in the planning process and more variation in the planning is to be added later.
