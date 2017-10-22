using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Use : Action {
	
	public Use(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Use() {
		this.subActions = new List<Action>();
	}
}