using UnityEngine;
using UnityEditor;

public class SeedDataAsset {
	[MenuItem("Assets/Create/QuestGenerator/SeedData")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<SeedData> ();
	}
}
