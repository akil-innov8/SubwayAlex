using UnityEngine;
using System.Collections;

public class CoinsManager : MonoBehaviour 
{
	public float score;

	public int coinValue;


	public static CoinsManager _instance;

	void Start()
	{
		_instance = this;
	}

	public void OnCoinCollected()
	{
		score += coinValue;
	}
}
