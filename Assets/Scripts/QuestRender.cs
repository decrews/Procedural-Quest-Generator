// QuestRender.cs
// Displays a tree on a Canvas.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestRender : MonoBehaviour {

	// UI Element used to represent nodes
	public GameObject nodeGraphic;


	// Recursively displays all children
	void DisplayChildren (Action root, Vector3 pos, float depth) {
		Debug.Log (root.GetType ());

		// child count
		float cc = root.GetSubactions ().Count;

		float i = -1;
		foreach (Action child in root.GetSubactions()) {
			i++;

			// Create visual and set transform
			GameObject nodeVisual = Instantiate (nodeGraphic, transform.position, Quaternion.identity);
			nodeVisual.transform.SetParent (this.transform);

			// Set the position of the node based on it's parent position and the depth of the tree
			nodeVisual.transform.position = new Vector3 (pos.x + (i - (cc-1f)*0.5f) * (150/(depth)), 
				pos.y - (100f/depth), 
				pos.z);

			// Reduce the size of the nodes each level by dividing by tree depth
			nodeVisual.transform.localScale = new Vector3 (nodeVisual.transform.localScale.x / (depth), 
				nodeVisual.transform.localScale.y / (depth), nodeVisual.transform.localScale.z);

			// Set the text 
			nodeVisual.GetComponentInChildren<Text> ().text = child.ToString();

			// Display the children of each child until the leaves are reached
			DisplayChildren (child, nodeVisual.transform.position, depth+0.7f);
		}
	}


	// Used to display an entire quest
	public void DisplayQuest(Quest quest) {
		Action root = quest.root;
		GameObject nodeVisual = Instantiate (nodeGraphic, transform.position, Quaternion.identity);
		nodeVisual.transform.SetParent (this.transform);
		nodeVisual.transform.position = new Vector3 (Camera.main.pixelWidth / 2, Camera.main.pixelHeight - 50, 0);
		nodeVisual.GetComponentInChildren<Text> ().text = root.GetText ();

		DisplayChildren (root, nodeVisual.transform.position, 2);
	}
}
