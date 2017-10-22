using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subquest : Action {

	public Subquest(List<Action> subActions) {
		actionText = "Subquest";
		this.subActions = subActions;
	}

	public Subquest() {
		actionText = "Subquest";
		this.subActions = new List<Action>();
	}
}
