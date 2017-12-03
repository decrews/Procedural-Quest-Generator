using UnityEngine;
using UnityEditor;

public class ItemDataAsset {
	[MenuItem("Assets/Create/QuestGenerator/ItemData")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<ItemData> ();
	}
}
