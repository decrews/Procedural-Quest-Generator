using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Prints the steps of a quest to the Console
public class QuestReader : MonoBehaviour {

	[SerializeField]
	private GameObject text;
	private int stepCount = 0;
	private string indent = "      ";


	public void ReadQuest(Quest quest) {
		text.GetComponent<Text> ().text += "Motivation: " + quest.motivation;
		text.GetComponent<Text> ().text += "\n\n Description: " + quest.description + "\n";

		ReadSubactions (quest.root, 0);
	}

	public void ReadSubactions(Action action, int depth) {
		// Start a new line for the quest step
		text.GetComponent<Text> ().text += "\n";

		// Indent based on the depth of the tree
		for (int i = 0; i < depth; i++) {
			text.GetComponent<Text> ().text += indent;
		}

		if (action.subActions.Count == 0) {
			text.GetComponent<Text> ().text += action.actionText;
			stepCount++;
		} else {
			text.GetComponent<Text> ().text += action.actionText;
			foreach (Action a in action.subActions) {
				ReadSubactions (a, depth+1);
			}
			stepCount++;
		}
	}
}
