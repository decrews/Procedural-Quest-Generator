using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : Action {

	public Learn(string about) {
		this.actionText = "Acquire " + about;
		this.subActions = new List<Action>();
		Initialize (about);
	}

	public void Initialize(string about) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "kill", "loot", "use" });
		patterns.Add(new List<string> { "listen" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "kill") {
				subActions.Add (new Kill (qg.GetEnemy()));
			} else if (act == "loot") {
				subActions.Add (new Loot (qg.GetItem()));
			} else if (act == "listen") {
				subActions.Add (new Listen ("learn about " + about));
			} else if (act == "goto") {
				subActions.Add (new Goto (qg.GetLocation()));
			} else if (act == "use") {
				subActions.Add (new Use (qg.GetItem()));
			}
		}
	}
}