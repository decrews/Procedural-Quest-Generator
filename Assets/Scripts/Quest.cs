using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {
	public string name;
	public string description;
	public string motivation;

	public Action root;

	public Quest(Action root) {
		this.root = root;

		this.name = "Cool quest";
		this.description = "All quests have the same description";
	}

	public int GetDepth() {
		int depth = 0;
		depth = childDepth (this.root, depth);
		return depth;
	}

	public int childDepth(Action root, int depth) {
		depth++;

		foreach (Action child in root.GetSubactions()) {
			int subDepth = childDepth (child, depth);
			if (subDepth > depth) {
				depth = subDepth;
			}
		}
		return depth;
	}
}
