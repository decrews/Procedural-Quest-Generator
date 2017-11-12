using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : Action {
	
	public Use() {
		this.subActions = new List<Action>();
		Initialize ();
	}

	public override void Initialize() {
		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "goto" });
		patterns.Add(new List<string> { "kill", "loot", "goto" });


		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "goto") {
				subActions.Add (new Goto ());
			} else if (act == "loot") {
				subActions.Add (new Loot ());
			} else if (act == "kill") {
				subActions.Add (new Kill ());
			}
		}
	}
}