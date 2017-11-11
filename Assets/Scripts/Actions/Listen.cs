using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listen : Action {
	
	public Listen(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Listen() {
		this.subActions = new List<Action>();
	}

	public override void Initialize() {
		List<Action> subRules1 = new List<Action> {};

		List<List<Action>> rules = new List<List<Action>> { subRules1 };
		this.subActions = rules [Random.Range (0, rules.Count)];
	}
}
