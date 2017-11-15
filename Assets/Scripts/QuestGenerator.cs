// QuestGenerator.cs
// Used for generating quests by generating a tree of actions.  
// Each action can have subactions which are selcted randomly from a list.
// This is a recursive process that terminates when atomic actions are selected

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator {

	List<List<string>> questTemplates;

	// lists of available npcs, enemies, and locations to generate quests with
	List<string> items;
	List<string> locations;
	List<string> npcs;
	List<string> enemies;

	private static QuestGenerator instance;
	public static QuestGenerator Instance() {
		if (instance == null) {
			instance = new QuestGenerator ();
		}

		return instance;
	}

	private QuestGenerator() {
		// Templates for each roots of the quest chain.
		List<string> quest1 = new List<string> { "get", "goto", "use" };
		List<string> quest2 = new List<string> { "steal", "report" };
		List<string> quest3 = new List<string> { "learn", "steal", "report" };

		// Put templates into a list that can be randomly selected from
		questTemplates = new List<List<string>> { quest1, quest2, quest3 };
	}


	public Quest GetQuest() {

		// Populate the lists of available items, locations, and npcs
		Populate ();

		List<Action> rootQuests = new List<Action> ();
		List<string> selectedTemplate = questTemplates [Random.Range (0, questTemplates.Count)];

		foreach (string act in selectedTemplate) {
			if (act == "get") {
				rootQuests.Add (new Get (GetItem()));
			} else if (act == "goto") {
				rootQuests.Add (new Goto (GetLocation()));
			} else if (act == "use") {
				rootQuests.Add (new Use (GetItem()));
			} else if (act == "steal") {
				rootQuests.Add (new Steal (GetItem(), GetEnemy()));
			} else if (act == "learn") {
				rootQuests.Add (new Learn (GetItem()));
			} else if (act == "report") {
				rootQuests.Add (new Report (GetFriendlyNPC()));
			}
		}
			
		Subquest root = new Subquest(rootQuests);
		Quest quest = new Quest (root);

		return quest;
	}


	// Will populate the quest generator with available locations, items, and npcs for quests
	// Right now it just fills the lists with random things from World of Warcraft
	private void Populate() {
		items = new List<string> { "Warglaive of Azzinoth", "Sulfuras", "Thunderfury", "Shadowmourne", "Silk Cloth",
			"Iron Ore" };
		ShuffleStrings (items);

		enemies = new List<string> { "Spider", "Bear", "Basilisk", "Kobold", "Lich", "Fel Orc", "Naga",
			"Abomination", "Wolf" };
		ShuffleStrings (enemies);

		npcs = new List<string> { "Thrall", "Vol'jin", "Sylvanas", "Cairne", "Lor'themar", "Saurfang", "Durotan", "Drek'Thar" };
		ShuffleStrings (npcs);

		locations = new List<string> { "Undercity", "Tarren Mill", "Grom'gol", "Razor Hill", "Bloodvenom Post", "Stormwind",
			"Ironforge", "Darnasus", "Orgrimmar" };
		ShuffleStrings (locations);
	}


	 // These functions will be how the quest generator accesses the game state to determine how to populate
	 // the items, locations, and npcs of the quests.

	public string GetLocation() {
		string loc = locations [0];
		locations.RemoveAt (0);
		return loc;
	}

	public string GetFriendlyNPC() {
		string npc = npcs [0];
		npcs.RemoveAt (0);
		return npc;
	}

	public string GetEnemy() {
		string enemy = enemies [0];
		enemies.RemoveAt (0);
		return enemy;
	}

	public string GetItem() {
		string item = items [0];
		items.RemoveAt (0);
		return item;
	}


	//https://stackoverflow.com/questions/273313/randomize-a-listt  
	public static void ShuffleStrings(List<string> list) {  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = Random.Range(0, (n + 1));  
			string value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}
}
