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
}
