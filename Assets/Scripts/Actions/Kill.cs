using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : Action {

	public Kill(string enemy) {
		this.actionText = "Kill " + enemy;
		this.subActions = new List<Action>();
		Initialize (enemy);
	}

	public void Initialize(string enemy) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "listen" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "listen") {
				subActions.Add (new Listen ("how to kill " + enemy));
			} else if (act == "goto") {
				subActions.Add (new Goto (qg.GetLocation()));
			}
		}
	}
}
