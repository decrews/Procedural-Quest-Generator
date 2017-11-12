using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goto : Action {
	
	public Goto() {
		this.subActions = new List<Action>();
		Initialize ();
	}

	public override void Initialize() {
		
	}
}
