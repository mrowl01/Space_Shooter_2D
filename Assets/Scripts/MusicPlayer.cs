using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
	static MusicPlayer myMusic = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;

	AudioSource music ; 

	void Start () 
	{
		

		if (myMusic != null && myMusic == this) 
		{
			Destroy (gameObject);
		} 
		else if ( myMusic == null) 
		{
			myMusic = this; 
			GameObject. DontDestroyOnLoad (gameObject);
			music = GetComponent<AudioSource> ();
		
		}
		
	}

	void OnLevelWasLoaded (int level)
	{
		if (level == 0) {
			myMusic.music.clip = startClip;	}
		if (level == 1) {
			myMusic.music.clip = gameClip;
		}
		if (level == 2) {
			myMusic.music.clip = endClip;
		}
		myMusic.music.loop = true;
		myMusic.music.Play ();
	}

	void Update ()
	{
		
	}
}
