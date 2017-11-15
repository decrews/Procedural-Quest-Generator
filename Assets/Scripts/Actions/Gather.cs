using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : Action {

	public Gather(string item) {
		this.actionText = "Gather " + item;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}