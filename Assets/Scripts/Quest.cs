using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {
	public string name;
	public string description;

	public Action root;

	public Quest(Action root) {
		this.root = root;

		this.name = "Cool quest";
		this.description = "All quests have the same description";
	}
}
