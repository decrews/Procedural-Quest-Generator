using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listen : Action {
	
	public Listen(NPCData npc) {
		this.actionText = "Listen to: " + npc.name;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public Listen(EnemyData enemy) {
		this.actionText = "Listen for how to kill: " + enemy.name;
		this.subActions = new List<Action>();
		Initialize ();
	}

	public void Initialize() {
		
	}
}
