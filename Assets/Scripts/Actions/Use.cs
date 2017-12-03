using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : Action {
	
	public Use(ItemData item) {
		actionText = "Use " + item.name;
		this.subActions = new List<Action>();
		Initialize (item);
	}

	public void Initialize(ItemData item) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> {});
		patterns.Add(new List<string> { "kill", "loot" });


		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "goto") {
				subActions.Add (new Goto (qg.GetLocation()));
			} else if (act == "loot") {
				subActions.Add (new Loot (item));
			} else if (act == "kill") {
				subActions.Add (new Kill (qg.GetEnemy(item)));
			}
		}
	}
}