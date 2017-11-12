using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listen : Action {
	
	public Listen() {
		this.subActions = new List<Action>();
		Initialize ();
	}

	public override void Initialize() {
		
	}
}
