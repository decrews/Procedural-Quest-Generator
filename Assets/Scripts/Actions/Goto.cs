using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goto : Action {
	
	public Goto(NPCData npc) {
		this.actionText = "Go to " + npc.location.name;
		this.subActions = new List<Action>();
		Initialize (npc);
	}

	public Goto(EnemyData enemy) {
		this.actionText = "Go to " + enemy.location.name;
		this.subActions = new List<Action>();
		Initialize (enemy);
	}

	public Goto(LocationData location) {
		this.actionText = "Go to " + location.name;
		this.subActions = new List<Action>();
	}


	public void Initialize(EnemyData enemy) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "learn" });
		patterns.Add(new List<string> { });


		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "learn") {
				subActions.Add (new Learn (enemy));
			}
		}
	}

	public void Initialize(NPCData npc) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "learn" });
		patterns.Add(new List<string> { });


		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "learn") {
				subActions.Add (new Learn (npc));
			}
		}
	}
}
