using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QuestGenerator qg = QuestGenerator.Instance ();

		Quest blah = qg.GetQuest();

		// Render the quest nodes to the UI
		QuestRender qr = GetComponent<QuestRender> ();
		qr.DisplayQuest (blah);

		// Read the quest and display the step
		QuestReader qReader = GetComponent<QuestReader> ();
		qReader.ReadQuest (blah);
	}
}
