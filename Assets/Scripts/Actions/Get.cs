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
}