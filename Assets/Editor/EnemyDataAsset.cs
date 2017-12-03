using UnityEngine;
using UnityEditor;

public class EnemyDataAsset {
	[MenuItem("Assets/Create/QuestGenerator/EnemyData")]
	public static void CreateAsset ()
	{
		ScriptableObjectUtility.CreateAsset<EnemyData> ();
	}
}
