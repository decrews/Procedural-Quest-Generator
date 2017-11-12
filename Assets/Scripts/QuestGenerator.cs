// QuestGenerator.cs
// Used for generating quests by generating a tree of actions.  
// Each action can have subactions which are selcted randomly from a list.
// This is a recursive process that terminates when atomic actions are selected

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator {

	List<List<string>> questTemplates;

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
		List<string> quest2 = new List<string> { "goto", "steal", "report" };
		List<string> quest3 = new List<string> { "learn", "steal", "report" };

		// Put templates into a list that can be randomly selected from
		questTemplates = new List<List<string>> { quest1, quest2, quest3 };
	}


	public Quest GetQuest() {
		// Gather data about the game state

		List<Action> rootQuests = new List<Action> ();
		List<string> selectedTemplate = questTemplates [Random.Range (0, questTemplates.Count)];

		foreach (string act in selectedTemplate) {
			if (act == "get") {
				rootQuests.Add (new Get ());
			} else if (act == "goto") {
				rootQuests.Add (new Goto ());
			} else if (act == "use") {
				rootQuests.Add (new Use ());
			} else if (act == "steal") {
				rootQuests.Add (new Steal ());
			} else if (act == "learn") {
				rootQuests.Add (new Learn ());
			} else if (act == "report") {
				rootQuests.Add (new Report ());
			}
		}
			
		Subquest root = new Subquest(rootQuests);
		Quest quest = new Quest (root);

		return quest;
	}

	/*
	public Subquest GetSubquest() {
		Subquest sub = new Subquest(quests[Random.Range(0, quests.Count)]);
		return sub;
	}
	*/	
}
