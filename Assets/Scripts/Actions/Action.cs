// Action.cs
// Abstract action that will the basis for each action that
// the player needs to perform to complete the quest.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action {
	public List<Action> subActions;
	public string actionText = "Text";
	public bool completed = false;

	public string GetText() {
		return actionText;
	}

	public List<Action> GetSubactions() {
		return subActions;
	}
}