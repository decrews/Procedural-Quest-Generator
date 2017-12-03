using UnityEngine;
using UnityEditor;

public class NPCDataAsset {
	[MenuItem("Assets/Create/QuestGenerator/NPCData")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<NPCData> ();
	}
}
