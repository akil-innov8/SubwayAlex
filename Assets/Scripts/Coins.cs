using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour 
{

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag==Tags.player)
		{
			OnCoinCollected(gameObject);
		}
	}

	void OnCoinCollected(GameObject obj)
	{
		obj.SetActive (false);
		CoinsManager._instance.OnCoinCollected ();
	}
}
