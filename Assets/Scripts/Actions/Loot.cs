using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Action {
	
	public Loot(ItemData item) {
		actionText = "Loot " + item.name;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}
