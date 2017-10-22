using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : Action {
	
	public Report(List<Action> subActions) {
		this.subActions = subActions;
	}

	public Report() {
		this.subActions = new List<Action>();
	}
}