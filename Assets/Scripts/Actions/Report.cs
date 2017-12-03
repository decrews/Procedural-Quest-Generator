using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : Action {
	
	public Report(NPCData npc) {
		this.actionText = "Report to " + npc.name;
		this.subActions = new List<Action>();
		Initialize (npc);
	}

	public void Initialize(NPCData npc) {

	}
}