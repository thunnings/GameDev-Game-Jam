using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : MonoBehaviour
{
	public static StarShip Instance = null;

	Vector3 starShipLocation = Vector3.zero;
	float starShipSpeed = 10f;
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);
	}

	public Vector3 GetLocation()
	{
		return starShipLocation;
	}
}
