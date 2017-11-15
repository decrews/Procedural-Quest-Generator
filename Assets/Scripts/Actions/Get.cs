using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get : Action {

	public Get(string item) {
		this.actionText = "Acquire " + item;
		this.subActions = new List<Action>();
		Initialize (item);
	}

	public void Initialize(string item) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "kill" });
		patterns.Add(new List<string> { "steal" });
		patterns.Add(new List<string> { "learn" , "steal" });
		patterns.Add(new List<string> { "gather" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "kill") {
				subActions.Add (new Kill (qg.GetEnemy()));
			} else if (act == "steal") {
				subActions.Add (new Steal (item, qg.GetEnemy()));
			} else if (act == "learn") {
				subActions.Add (new Learn (item));
			} else if (act == "goto") {
				subActions.Add (new Goto (qg.GetLocation()));
			} else if (act == "gather") {
				subActions.Add (new Gather (item));
			}
		}
	}
}