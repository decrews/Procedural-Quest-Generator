// QuestGenerator.cs
// Used for generating quests by generating a tree of actions.  
// Each action can have subactions which are selcted randomly from a list.
// This is a recursive process that terminates when atomic actions are selected

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour {

	// Quest seeds
	List<List<Action>> quests;

	void Start () {
		// Quest where the player must get an item, go to someone, and use it on them
		List<Action> quest1 = new List<Action> { new Get(), new Goto(), new Use() };

		// Quest where the player needs to go to an NPC, steal something, and then report in.
		List<Action> quest2 = new List<Action> { new Goto(), new Steal(), new Report() };

		// Put quests into a list that can be randomly selected from
		quests = new List<List<Action>> { quest1, quest2 };

		Quest blah = GetQuest();

		// Render the quest nodes to the UI
		QuestRender qr = GetComponent<QuestRender> ();
		qr.DisplayQuest (blah);

	}


	// Generates and returns a quest
	Quest GetQuest() {
		// Here I will gather game state information and workout what 
		// npcs and items make sense to build a quest around

		// Get a random subquest seed
		Subquest root = new Subquest(quests[Random.Range(0, quests.Count)]);
		Quest quest = new Quest (root);
		AddActions (quest.root);
		return quest;
	}
		

	// Sets the subactions for a node from their respective list based on type
	void AddActions(Action root) {
		for (var i = 0; i < root.GetSubactions().Count; i++) {
			root.GetSubactions () [i].Initialize ();
			/*
			if (root.GetSubactions()[i].GetType() == typeof(Kill)) {
				root.GetSubactions()[i] = killRules[Random.Range(0, killRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Goto)) {
				root.GetSubactions()[i] = gotoRules[Random.Range(0, gotoRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Learn)) {
				root.GetSubactions()[i] = learnRules[Random.Range(0, learnRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Get)) {
				root.GetSubactions()[i] = getRules[Random.Range(0, getRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Gather)) {
				root.GetSubactions()[i] = gatherRules[Random.Range(0, gatherRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Report)) {
				root.GetSubactions()[i] = reportRules[Random.Range(0, reportRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Loot)) {
				root.GetSubactions()[i] = lootRules[Random.Range(0, lootRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Use)) {
				root.GetSubactions()[i] = useRules[Random.Range(0, useRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Steal)) {
				root.GetSubactions()[i] = stealRules[Random.Range(0, stealRules.Count)];
			} else if (root.GetSubactions()[i].GetType() == typeof(Listen)) {
				root.GetSubactions()[i] = listenRules[Random.Range(0, listenRules.Count)];
			}
			*/
			AddActions (root.GetSubactions()[i]);
		}
	}
}
