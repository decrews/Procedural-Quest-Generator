using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subquest : Action {

	public Subquest(List<Action> subActions) {
		actionText = "Subquest Complete";
		this.subActions = subActions;
	}

	public Subquest() {
		actionText = "Subquest Complete";
		this.subActions = new List<Action>();
	}

	public void Initialize() {

	}
}
