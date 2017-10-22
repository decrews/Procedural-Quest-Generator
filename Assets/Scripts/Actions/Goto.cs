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
}
