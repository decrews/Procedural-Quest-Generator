using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : Action {

	public Gather(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Gather() {
		this.subActions = new List<Action>();
	}
}