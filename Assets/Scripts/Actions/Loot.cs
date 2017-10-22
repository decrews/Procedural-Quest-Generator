using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Action {
	
	public Loot(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Loot() {
		this.subActions = new List<Action>();
	}
}
