// QuestGenerator.cs
// Used for generating quests by generating a tree of actions.  
// Each action can have subactions which are selcted randomly from a list.
// This is a recursive process that terminates when atomic actions are selected

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator : MonoBehaviour {
	// Rules for each action
	List<Goto> gotoRules;
	List<Learn> learnRules;
	List<Get> getRules;
	List<Gather> gatherRules;
	List<Kill> killRules;
	List<Report> reportRules;
	List<Loot> lootRules;
	List<Use> useRules;
	List<Steal> stealRules;
	List<Listen> listenRules;

	// Quest seeds
	List<List<Action>> quests;

	void Start () {
		// Fill the list of rules for fulfilling each action type
		// These will eventually be put into scriptable objects
		SetGotoRules();
		SetLearnRules ();
		SetGetRules();
		SetGatherRules();
		SetKillRules();
		SetReportRules();
		SetLootRules();
		SetUseRules();
		SetStealRules();
		SetListenRules();

		// Quest where the player must get an item, go to someone, and use it on them
		List<Action> quest1 = new List<Action> { new Get(), new Goto(), new Use() };

		// Quest where the player needs to go to an NPC, steal something, and then report in.
		List<Action> quest2 = new List<Action> { new Goto(), new Steal(), new Report() };

		// Put quests into a list that can be randomly selected from
		quests = new List<List<Action>> { quest1, quest2 };

		Action blah = GetQuest();

		// Render the quest nodes to the UI
		QuestRender qr = GetComponent<QuestRender> ();
		qr.DisplayQuest (blah);

	}


	// Generates and returns a quest
	Action GetQuest() {
		// Here I will gather game state information and workout what 
		// npcs and items make sense to build a quest around

		// Get a random subquest seed
		Subquest quest = new Subquest(quests[Random.Range(0, quests.Count)]);
		AddActions (quest);
		return quest;
	}
		

	// Sets the subactions for a node from their respective list based on type
	void AddActions(Action root) {
		for (var i = 0; i < root.GetSubactions().Count; i++) {
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

			AddActions (root.GetSubactions()[i]);
		}
	}

	/*

	These functions are used to fill the list of possible rules for each subaction

	*/

	void SetGotoRules() {

		List<Action> subRules1 = new List<Action> ();   			// No subactions, player already knows where to go
		List<Action> subRules2 = new List<Action> { new Learn () }; // Learn the location first

		gotoRules = new List<Goto> { new Goto(subRules1), new Goto(subRules2) };
	}


	void SetLearnRules() {

		List<Action> subRules1 = new List<Action> { new Kill (), new Loot (), new Use () };
		List<Action> subRules2 = new List<Action> { new Goto (), new Listen () };

		learnRules = new List<Learn> { new Learn(subRules1), new Learn(subRules2) };
	}


	void SetGetRules() {


		List<Action> subRules1 = new List<Action> { new Kill () };
		List<Action> subRules2 = new List<Action> { new Steal () };
		List<Action> subRules3 = new List<Action> { new Goto (), new Gather () };

		getRules = new List<Get> { new Get(subRules1), new Get(subRules2), new Get(subRules3) };
	}


	void SetGatherRules() {

		gatherRules = new List<Gather> { new Gather () };
	}


	void SetKillRules() {

		List<Action> subRules1 = new List<Action> { new Goto () };
		List<Action> subRules2 = new List<Action> { new Goto (), new Listen ()};
	
		killRules = new List<Kill> { new Kill (), new Kill (subRules1), new Kill (subRules2) };
	}


	void SetReportRules() {

		List<Action> subRules1 = new List<Action> { new Goto () };

		reportRules = new List<Report> { new Report (subRules1) };
	}


	void SetLootRules() {
		lootRules = new List<Loot> { new Loot() };
	}


	void SetUseRules() {
		useRules = new List<Use> { new Use () };
	}		


	void SetStealRules() {
		
		List<Action> subRules1 = new List<Action> { new Goto () };

		stealRules = new List<Steal> { new Steal(), new Steal (subRules1) };
	}


	void SetListenRules() {
		listenRules = new List<Listen> () { new Listen () };
	}

}
