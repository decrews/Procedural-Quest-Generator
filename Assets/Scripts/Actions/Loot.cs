using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Action {
	
	public Loot() {
		this.subActions = new List<Action>();
		Initialize ();
	}

	public override void Initialize() {
		
	}
}
