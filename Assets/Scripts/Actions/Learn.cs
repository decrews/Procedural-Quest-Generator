using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Learn : Action {

	public Learn(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Learn() {
		this.subActions = new List<Action>();
	}

	public override void Initialize() {
		List<Action> subRules1 = new List<Action> { new Kill (), new Loot (), new Use () };
		List<Action> subRules2 = new List<Action> { new Goto (), new Listen () };

		List<List<Action>> rules = new List<List<Action>> { subRules1, subRules2 };
		this.subActions = rules [Random.Range (0, rules.Count)];
	}
}