using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : Action {
	
	public Steal(ItemData item, EnemyData enemy) {
		actionText = "Steal " + item.name + " from " + enemy.name;
		this.subActions = new List<Action>();
		Initialize (item, enemy);
	}

	public void Initialize(ItemData item, EnemyData enemy) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "goto" });
		patterns.Add(new List<string> {});

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "goto") {
				subActions.Add (new Goto (enemy.location));
			}
		}
	}
}