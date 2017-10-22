# Procedural Quest Generator

A procedural quest generator for C# / Unity.  This project implements the quest generating algorithm described by Jonathon Doran and Ian Parberry in [A Prototype Quest Generator Based on a
Structural Analysis of Quests from Four MMORPGs](http://larc.unt.edu/ian/pubs/pcg2011.pdf).

The Unity project contains a class for generating quests and another for displaying the underlying tree structure to a Unity UI Canvas.

The generator creates a tree where each node is an Action the player must take to complete the quest.  Preorder traversal is the order the game should follow when presenting the player with the quest chain.  By traversing the tree in this way, the player is first presented with a quest at the root node and then needs to complete the children to finish the quest.

Right now the quests are only verbs, meaning it can describe a quest where the player must use an item to heal an NPC, but does not contain the name of the item or the NPC to heal.  I want to implement this along with some randomly selected text segments so that the summary of the quest is readable.
