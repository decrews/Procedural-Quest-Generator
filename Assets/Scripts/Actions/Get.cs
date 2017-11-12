using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get : Action {

	public Get() {
		this.subActions = new List<Action>();
		Initialize ();
	}

	public override void Initialize() {
		List<List<string>> patterns = new List<List<string>> ();
		patterns.Add(new List<string> { "kill" });
		patterns.Add(new List<string> { "steal" });
		patterns.Add(new List<string> { "learn" , "steal" });
		patterns.Add(new List<string> { "goto", "gather" });

		foreach (string act in patterns [Random.Range (0, patterns.Count)]) {
			if (act == "kill") {
				subActions.Add (new Kill ());
			} else if (act == "steal") {
				subActions.Add (new Steal ());
			} else if (act == "learn") {
				subActions.Add (new Learn ());
			} else if (act == "goto") {
				subActions.Add (new Goto ());
			} else if (act == "gather") {
				subActions.Add (new Gather ());
			}
		}
	}
}