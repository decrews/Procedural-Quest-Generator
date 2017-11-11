using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steal : Action {
	
	public Steal(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Steal() {
		this.subActions = new List<Action>();
	}

	public override void Initialize() {
		List<Action> subRules1 = new List<Action> { new Goto () };

		List<List<Action>> rules = new List<List<Action>> { subRules1 };
		this.subActions = rules [Random.Range (0, rules.Count)];
	}
}