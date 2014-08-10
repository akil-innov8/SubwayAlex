using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioContainer : ScriptableObject 
{
	static AudioContainer m_instance;

	public static AudioContainer _instance
	{
		get
		{
			if(m_instance==null)
			{
				m_instance = Resources.Load<AudioContainer>("AudioContainer");
			}
			return m_instance;
		}
	}

	public List<AudioClip> audioClips;

	public AudioClip GetAudio(string name)
	{
		foreach(AudioClip clip in audioClips)
		{
			if(clip.name==name)
			{
				return clip;
			}
		}
		return null;
	}
}
