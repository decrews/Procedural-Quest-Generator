using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : Action {

	public Gather(ItemData item) {
		this.actionText = "Gather " + item.name;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}