using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance = null;

	public AudioSource effectsPlayer;
	public AudioSource musicPlayer;

	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of AudioManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set AudioManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}

	public void Play(AudioClip clipToPlay)
	{
		effectsPlayer.PlayOneShot(clipToPlay);
	}
}
