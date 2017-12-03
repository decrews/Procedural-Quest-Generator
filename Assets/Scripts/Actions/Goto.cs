using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goto : Action {
	
	public Goto(LocationData location) {
		this.actionText = "Go to " + location.name;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}
