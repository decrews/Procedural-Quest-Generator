using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defend : Action {
	
	public Defend(NPCData npc, string condition, int duration) {
		actionText = "Defend " + npc.name;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}
