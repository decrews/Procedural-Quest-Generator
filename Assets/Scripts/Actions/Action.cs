// Action.cs
// Abstract action that will the basis for each action that
// the player needs to perform to complete the quest.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action {
	public List<Action> subActions;
	protected string actionText = "Text";

	public string GetText() {
		return actionText;
	}

	public List<Action> GetSubactions() {
		return subActions;
	}

	// Used to initialize a set of actions without parameters
	public void GenerateSubactions() {
		foreach (Action act in subActions) {
			act.Initialize ();
		}
	}

	public abstract void Initialize ();
}