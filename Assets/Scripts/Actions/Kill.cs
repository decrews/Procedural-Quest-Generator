using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : Action {

	public Kill() {
		this.subActions = new List<Action>();
		Initialize ();
	}

	public override void Initialize() {
		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "goto" });
		patterns.Add(new List<string> { "goto", "listen" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "listen") {
				subActions.Add (new Listen ());
			} else if (act == "goto") {
				subActions.Add (new Goto ());
			}
		}
	}
}
