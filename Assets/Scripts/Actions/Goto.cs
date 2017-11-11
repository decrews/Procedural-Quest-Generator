using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goto : Action {
	
	public Goto(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Goto() {
		this.subActions = new List<Action>();
	}

	public override void Initialize() {
		List<Action> subRules1 = new List<Action> ();   			// No subactions, player already knows where to go
		List<Action> subRules2 = new List<Action> { new Learn () }; // Learn the location first

		List<List<Action>> rules = new List<List<Action>> { subRules2, subRules1 };
		this.subActions = rules [Random.Range (0, rules.Count)];
	}
}
