using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get : Action {

	public Get(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Get() {
		this.subActions = new List<Action>();
	}

	public override void Initialize() {

		List<List<Action>> rules = new List<List<Action>> ();
		rules.Add(new List<Action> { new Kill () });
		rules.Add(new List<Action> { new Steal () });
		rules.Add(new List<Action> { new Goto (), new Gather () });

		this.subActions = rules [Random.Range (0, rules.Count)];
	}
}