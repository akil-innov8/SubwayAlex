using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAsset : Editor 
{
	[MenuItem("Utility/Create Asset")]
	static void Create()
	{
		var instance = ScriptableObject.CreateInstance<AudioContainer> ();
		AssetDatabase.CreateAsset (instance,"Assets/AudioContainer.asset");
		AssetDatabase.Refresh ();
	}
}
