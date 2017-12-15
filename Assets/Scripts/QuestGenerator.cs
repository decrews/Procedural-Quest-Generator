// QuestGenerator.cs
// Used for generating quests by generating a tree of actions.  
// Each action can have subactions which are selcted randomly from a list.
// This is a recursive process that terminates when atomic actions are selected

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGenerator {

	// Reference to the game object which contains the game state
	Game gm;

	// Local copies of all data
	List<LocationData> locData;
	List<NPCData> npcData;
	List<EnemyData> enemyData;
	List<ItemData> itemData;

	private static QuestGenerator instance;
	public static QuestGenerator Instance() {
		if (instance == null) {
			instance = new QuestGenerator ();
		}

		return instance;
	}


	private QuestGenerator() {
		gm = GameObject.Find ("Canvas").GetComponent<Game>();
	}


	public Quest GetQuest(string motive, int minimumComplexity) {
		int failCatch = 0;
		Subquest root = GetActions (motive);
		Quest quest = new Quest (root);

		while (quest.GetDepth () < minimumComplexity || quest.GetDepth() > 20) {
			if (failCatch > 100) {
				Debug.Log ("Can't find path, breaking out!");
				break;
			}


			quest = new Quest(GetActions (motive));
			failCatch++;
		}

		quest.motivation = motive;
		quest.description = root.actionText;
		// Will add quest metadata here, such as text, title, etc...

		return quest;
	}


	// Gets appropriate actions for the subquest based on motive
	public Subquest GetActions(string motive) {

		// Load the lists of available npcs, enemies, locations, and items.
		locData = new List<LocationData> (gm.locations);
		npcData = new List<NPCData>(gm.npcs);
		enemyData = new List<EnemyData>(gm.enemies);
		itemData = new List<ItemData>(gm.items);

		SeedData seed;
		if (motive == "knowledge") {
			seed = gm.knowledgeSeeds [Random.Range (0, gm.knowledgeSeeds.Length)];
		} else if (motive == "comfort") {
			seed = gm.comfortSeeds [Random.Range (0, gm.comfortSeeds.Length)];
		} else if (motive == "justice") {
			seed = gm.justiceSeeds [Random.Range (0, gm.justiceSeeds.Length)];
		} else {
			throw new System.NotImplementedException ();
		}

		List<Action> rootActions = assignActions (new List<string>(seed.actions));

		Subquest root = new Subquest(rootActions);

		// Set the subqest action text
		root.actionText = seed.description;

		return root;
	}


	// Turns a string action plan into a list of Actions with appropriate data
	public List<Action> assignActions(List<string> actions) {
		// Reverse the list so that the plan can be made regressively
		List<string> reversedActions = new List<string>(actions);
		reversedActions.Reverse ();

		NPCData reportingTo = null;
		EnemyData enemyAttacking = null;
		ItemData itemAcquired = null;
		ItemData itemUsed = null;

		List<Action> rootActions = new List<Action> ();

		foreach (string act in reversedActions) {
			if (act == "get") {
				if (itemUsed != null) {
					rootActions.Add (new Get (itemUsed));
					itemUsed = null;
				} else {
					rootActions.Add (new Get (GetItem()));
				}
			} 

			else if (act == "goto") {
				if (reportingTo != null) {
					// An npc was selected to report to, go to them
					rootActions.Add (new Goto (reportingTo));
					reportingTo = null;

				} else if (enemyAttacking != null) {
					// An enemy was selected to attack get it's location
					rootActions.Add(new Goto(enemyAttacking));
					enemyAttacking = null;
				} else {
					// Default to a random location
					rootActions.Add (new Goto (GetLocation ()));	
				}
			} 

			else if (act == "use") {
				itemUsed = GetItem ();
				rootActions.Add (new Use (itemUsed));
			} 

			else if (act == "steal") {
				rootActions.Add (new Steal (GetItem(), GetEnemy()));
			} 

			else if (act == "learn") {
				rootActions.Add (new Learn (GetFriendlyNPC()));
			} 

			else if (act == "report") {
				reportingTo = GetFriendlyNPC ();
				rootActions.Add (new Report (reportingTo));
			} 

			else if (act == "kill") {
				enemyAttacking = GetEnemy ();
				rootActions.Add (new Kill (enemyAttacking));
			} 

			else if (act == "listen") {
				rootActions.Add (new Listen (GetFriendlyNPC()));
			}
		}

		// Reverse the rootActions list which was built backwards
		rootActions.Reverse();

		return rootActions;
	}

	/*

	Methods for getting NPCs

	*/

	// Get a random location
	public LocationData GetLocation() {
		int index = Random.Range (0, locData.Count-1);
		LocationData location = locData [index];
		locData.RemoveAt (index);
		return location;
	}


	/*

	Methods for getting NPCs

	*/

	// Get a random NPC;
	public NPCData GetFriendlyNPC() {
		int index = Random.Range (0, npcData.Count-1);
		NPCData npc = npcData [index];
		npcData.RemoveAt (index);
		return npc;
	}

	/*

	Methods for getting Enemies

	*/

	// Get a random enemy
	public EnemyData GetEnemy() {
		int index = Random.Range (0, enemyData.Count-1);
		EnemyData enemy = enemyData [index];
		enemyData.RemoveAt (index);
		return enemy;
	}


	// Get an enemy with a specific item
	public EnemyData GetEnemy(ItemData item) {
		EnemyData enemy = null;

		// Search all enemies for one that has this loot
		foreach (EnemyData e in enemyData) {
			foreach (ItemData i in e.loot) {
				if (i.name == item.name) {
					enemy = e;
				}
			}
		}

		// If an enemy is found that contains that on it's loot table, return that
		// otherwise get a random enemy as a fallback
		if (enemy != null) {
			return enemy;
		} else {
			return GetEnemy (); 
		}
	}


	/*

	Methods for getting Items

	*/

	// Get a random item
	public ItemData GetItem() {
		int index = Random.Range (0, itemData.Count-1);
		ItemData item = itemData [index];
		itemData.RemoveAt (index);
		return item;
	}
}
