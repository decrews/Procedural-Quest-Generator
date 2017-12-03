using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : Action {

	public Kill(EnemyData enemy) {
		this.actionText = "Kill " + enemy.name;
		this.subActions = new List<Action>();
		Initialize (enemy);
	}

	public void Initialize(EnemyData enemy) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "listen" });
		patterns.Add (new List<string> { });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "listen") {
				subActions.Add (new Listen (enemy));
			}
		}
	}
}
