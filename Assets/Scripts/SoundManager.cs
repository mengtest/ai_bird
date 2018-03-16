﻿using UnityEngine;
using System.Collections;

public enum SoundType
{
	Plus = 1,
	Death,
	Hit,
	Fly,
	Max
}

public class SoundManager : MonoBehaviour 
{
	private static SoundManager instance;
	private AudioSource _audio;
	[SerializeField] private Camera    mainCamera;
	[SerializeField] private AudioClip death;
	[SerializeField] private AudioClip hit;
	[SerializeField] private AudioClip plus;
	[SerializeField] private AudioClip fly;

	void Awake () 
	{ 
		instance = this; 
		transform.position = mainCamera.transform.position;
	}

	public static void PlaySound(SoundType type)
	{
		if(instance._audio == null)
		{
			instance._audio = instance.GetComponent<AudioSource>();
		}

		if(instance._audio.isPlaying) instance._audio.Stop();

		AudioClip aClip = null;

		switch(type)
		{
		case SoundType.Death: aClip = instance.death; break;
		case SoundType.Plus:  aClip = instance.plus; break;
		case SoundType.Hit:   aClip = instance.hit; break;
		case SoundType.Fly:   aClip = instance.fly; break;
		default : break;
		}

		if(aClip != null)
			instance._audio.PlayOneShot(aClip);
	}
}