using UnityEngine;
using UnityEditor;

public class LocationDataAsset {
	[MenuItem("Assets/Create/QuestGenerator/LocationData")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<LocationData> ();
	}
}
