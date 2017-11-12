using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : Action {

	public Learn() {
		this.subActions = new List<Action>();
		Initialize ();
	}

	public override void Initialize() {
		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "kill", "loot", "use" });
		patterns.Add(new List<string> { "goto", "listen" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "kill") {
				subActions.Add (new Kill ());
			} else if (act == "loot") {
				subActions.Add (new Loot ());
			} else if (act == "listen") {
				subActions.Add (new Listen ());
			} else if (act == "goto") {
				subActions.Add (new Goto ());
			} else if (act == "use") {
				subActions.Add (new Use ());
			}
		}
	}
}