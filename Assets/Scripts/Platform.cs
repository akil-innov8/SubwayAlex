using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour 
{
	public GameObject cube;
	// Use this for initialization
	void Start () 
	{

	}


	public void SetCoins()
	{
		Coins[] coins = transform.GetComponentsInChildren<Coins> ();
		foreach(Coins coin in coins)
			coin.gameObject.SetActive(true);
	}

	void OnCollisionExit(Collision col)
	{
		if(col.gameObject.tag==Tags.player)
		{
			StartCoroutine(RemovePlatform());
		}
	}

	IEnumerator RemovePlatform()
	{
		yield return new WaitForSeconds (1);
		PlatformManager._instance.RemovePlatform ();
	}


	[ContextMenu("Coins")]
	void CreateCoins()
	{
		float noOfcubesToBeCreated = ((transform.localScale.z / cube.transform.localScale.z)/2);
		GameObject[] objs = new GameObject[(int)noOfcubesToBeCreated];
		for(int i=0;i<noOfcubesToBeCreated;i++)
		{
			GameObject obj = Instantiate (cube) as GameObject;
			objs[i] = obj;
			obj.name = (i+1).ToString();
			obj.transform.parent = transform;
			obj.AddComponent<Coins>();
		}
		for(int i=0;i<noOfcubesToBeCreated;i++)
		{
			Vector3 previousPosition = Vector3.zero;
			Vector3 currentPosition = Vector3.zero;
			if(i>0)
			{
				previousPosition = objs[i-1].transform.position;
				currentPosition = new Vector3(previousPosition.x,previousPosition.y,(previousPosition.z+1));
				objs[i].transform.position = new Vector3(currentPosition.x,currentPosition.y,currentPosition.z+cube.transform.localScale.z);
			}
			else
			{
				currentPosition = new Vector3(transform.position.x,transform.position.y+cube.transform.localScale.y/2,(transform.position.z-transform.localScale.z/2));
				objs[i].transform.position = new Vector3(currentPosition.x,currentPosition.y,currentPosition.z+cube.transform.localScale.z);
			}
		}
	}
}
