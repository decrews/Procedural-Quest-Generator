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
}
