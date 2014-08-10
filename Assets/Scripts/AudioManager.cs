using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	public static AudioManager _instance;

	void Start()
	{
		_instance = this;
	}

	public void Play(string name,bool loop)
	{
		AudioClip clip = AudioContainer._instance.GetAudio (name);
		GameObject obj = new GameObject (name);
		AudioSource source = obj.AddComponent<AudioSource> ();
		source.clip = clip;
		source.Play ();
		if (loop)
		source.loop = true;
		else
		StartCoroutine (DestroyGameObject(obj,clip.length));
	}

	IEnumerator DestroyGameObject(GameObject obj,float time)
	{
		yield return new WaitForSeconds(time);
		Destroy (obj);
	}
}
