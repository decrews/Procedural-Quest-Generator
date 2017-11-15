using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listen : Action {
	
	public Listen(string listenForWhat) {
		this.actionText = "Listen for: " + listenForWhat;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}
