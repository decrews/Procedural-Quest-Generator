using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : Action {
	
	public Report(string npc) {
		this.actionText = "Report to " + npc;
		this.subActions = new List<Action>();
		Initialize (npc);
	}

	public void Initialize(string npc) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "goto" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "goto") {
				subActions.Add (new Goto (qg.GetLocation()));
			}
		}
	}
}