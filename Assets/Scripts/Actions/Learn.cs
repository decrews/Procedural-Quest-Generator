using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : Action {

	public Learn(NPCData about) {
		this.actionText = "Learn about " + about.name;
		this.subActions = new List<Action>();
		Initialize (about);
	}

	public Learn(EnemyData about) {
		this.actionText = "Learn about " + about.name;
		this.subActions = new List<Action>();
		Initialize (about);
	}

	public void Initialize(NPCData about) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "kill", "loot", "use" });
		patterns.Add(new List<string> { "listen" });

		List<string> pattern = patterns [Random.Range (0, patterns.Count)];

		this.subActions = qg.assignActions (pattern);
	}

	public void Initialize(EnemyData about) {
		QuestGenerator qg = QuestGenerator.Instance ();

		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "kill", "loot", "use" });
		patterns.Add(new List<string> { "listen" });

		List<string> pattern = patterns [Random.Range (0, patterns.Count)];

		this.subActions = qg.assignActions (pattern);
	}
}