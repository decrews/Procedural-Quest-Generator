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
}