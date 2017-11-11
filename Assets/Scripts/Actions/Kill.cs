using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : Action {

	public Kill(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Kill() {
		this.subActions = new List<Action>();
	}

	public override void Initialize() {
		List<Action> subRules1 = new List<Action> { new Goto () };
		List<Action> subRules2 = new List<Action> { new Goto (), new Listen ()};

		List<List<Action>> rules = new List<List<Action>> { subRules2, subRules1 };
		this.subActions = rules [Random.Range (0, rules.Count)];
	}
}
