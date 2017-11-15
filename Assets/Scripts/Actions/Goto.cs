using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goto : Action {
	
	public Goto(string location) {
		this.actionText = "Go to " + location;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}
