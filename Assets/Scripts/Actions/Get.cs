using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get : Action {

	public Get(ItemData item) {
		this.actionText = "Acquire " + item.name;
		this.subActions = new List<Action>();
		Initialize (item);
	}

	public void Initialize(ItemData item) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "kill" });
		patterns.Add(new List<string> { "steal" });
		patterns.Add(new List<string> { "learn" , "steal" });
		patterns.Add(new List<string> { "gather" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "kill") {
				subActions.Add (new Kill (qg.GetEnemy(item)));
			} else if (act == "steal") {
				subActions.Add (new Steal (item, qg.GetEnemy(item)));
			} else if (act == "learn") {
				subActions.Add (new Learn (qg.GetEnemy(item)));
			} else if (act == "goto") {
				subActions.Add (new Goto (qg.GetLocation()));
			} else if (act == "gather") {
				subActions.Add (new Gather (item));
			}
		}
	}
}