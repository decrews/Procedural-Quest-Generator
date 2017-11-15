using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : Action {
	
	public Steal(string item, string enemy) {
		actionText = "Steal " + item + " from " + enemy;
		this.subActions = new List<Action>();
		Initialize (item, enemy);
	}

	public void Initialize(string item, string enemy) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "goto" });
		patterns.Add(new List<string> {});

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "goto") {
				subActions.Add (new Goto (qg.GetLocation()));
			}
		}
	}
}