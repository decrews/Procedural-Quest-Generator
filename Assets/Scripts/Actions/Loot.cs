using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Action {
	
	public Loot(string item) {
		actionText = "Loot " + item;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}
