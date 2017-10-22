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
}