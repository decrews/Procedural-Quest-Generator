using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Prints the steps of a quest to the Console
public class QuestReader : MonoBehaviour {

	[SerializeField]
	private GameObject text;
	private int stepCount = 0;

	public void ReadQuest(Quest quest) {

		Debug.Log ("Quest Name: " + quest.name);
		Debug.Log ("Quest Description: " + quest.description);

		ReadSubactions (quest.root);

	}


	public void ReadSubactions(Action action) {
		if (action.subActions.Count == 0) {
			Debug.Log (action.actionText);
			text.GetComponent<Text> ().text += "\n" + stepCount + ": " + action.actionText;
			stepCount++;
		} else {
			foreach (Action a in action.subActions) {
				ReadSubactions (a);
			}
			Debug.Log (action.actionText);
			text.GetComponent<Text> ().text += "\n" + stepCount + ": " + action.actionText;
			stepCount++;
		}
	}
}
