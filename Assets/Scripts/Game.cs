using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public NPCData[] npcs;
	public LocationData[] locations;
	public EnemyData[] enemies;
	public ItemData[] items;

	public SeedData[] knowledgeSeeds;
	public SeedData[] comfortSeeds;
	public SeedData[] justiceSeeds;

	// Use this for initialization
	void Start () {
		QuestGenerator qg = QuestGenerator.Instance ();

		Quest example;
		int questType = Random.Range (0, 3);  // Example quest type

		if (questType == 0) {
			// Generate a knowledge quest
			example = qg.GetQuest ("knowledge", 8);
		} else if (questType == 1) {
			// Generate a comfort quest
			example = qg.GetQuest("comfort", 8);
		} else {
			// Generate a justice quest
			example = qg.GetQuest("justice", 8);
		}

		// Render the quest nodes to the UI
		QuestRender qr = GetComponent<QuestRender> ();
		qr.DisplayQuest (example);

		// Read the quest and display the step
		QuestReader qReader = GetComponent<QuestReader> ();
		qReader.ReadQuest (example);
	}
}
