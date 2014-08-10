using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour 
{
	public int noOfPlatformsOnScreen;
	public List<Transform> unusedPlatforms=new List<Transform>();
	public List<Transform> usedPlatforms = new List<Transform>();
	public static PlatformManager _instance;
	// Use this for initialization
	void Start () 
	{
		_instance = this;
		InitialSpawn ();
	}


	Transform ChooseARandomPlatform(List<Transform> list)
	{
		int random = Random.Range (0,list.Count);
		return list [random];
	}

	void SwapPlatform(Transform platform,List<Transform> from,List<Transform> to)
	{
		from.Remove (platform);
		to.Add (platform);
	}


	[ContextMenu("Add to list")]
	void PregameOperations()
	{
		foreach(Transform platform in transform)
		{
			unusedPlatforms.Add(platform);
		}
	}


	void InitialSpawn()
	{
		Transform platform = ChooseARandomPlatform (unusedPlatforms);
		////////
		platform.name = "0";
		SwapPlatform (platform, unusedPlatforms, usedPlatforms);
		platform.position = new Vector3 (0,0,0);
		SpawnPlatforms ();
		StartCoroutine (PlatformInspector());
	}

	void SpawnPlatforms()
	{
		int currentIndex = usedPlatforms.Count;
		for(int i=currentIndex;i<noOfPlatformsOnScreen;i++)
		{
			Transform platform = ChooseARandomPlatform(unusedPlatforms);
			///////
			platform.name = i.ToString();
			SwapPlatform(platform,unusedPlatforms,usedPlatforms);
			Platform script = platform.GetComponent<Platform>();
			script.SetCoins();
			platform.position = new Vector3(usedPlatforms[i-1].position.x,usedPlatforms[i-1].position.y,usedPlatforms[i-1].position.z+usedPlatforms[i-1].collider.bounds.extents.z*2);
		}
	}

	[ContextMenu("Remove")]
	public void RemovePlatform()
	{
		Transform platform = usedPlatforms [0];
		SwapPlatform (platform, usedPlatforms, unusedPlatforms);
		platform.position = transform.position;
		//////
		platform.name = "Platform";
	}

	IEnumerator PlatformInspector()
	{
		while(true)
		{
			if(usedPlatforms.Count<noOfPlatformsOnScreen)
				SpawnPlatforms();
			yield return null;
		}
	}
}
