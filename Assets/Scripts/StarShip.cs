using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarShip : MonoBehaviour
{
	public static StarShip Instance = null;

	public StarSystem currentSystem;
	public int currentYear = 0;

	public Crew crew;
	public int maximumPassengers = 5000;
	public int currentPassengers;

	float starShipSpeed = 2f;

	public List<Journey> journeys = new List<Journey>();
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of StarShip, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Set StarShip to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
		DontDestroyOnLoad(gameObject);

		crew = new Crew();
		currentPassengers = crew.crewTotal;
	}

	public int GetDate()
	{
		return currentYear;
	}

	public StarSystem GetLocation()
	{
		return currentSystem;
	}

	public float GetSpeed()
	{
		return starShipSpeed;
	}

	public void SetDestination(StarSystem destination)
	{
		float travelTime = Vector3.Distance(currentSystem.systemLocation, destination.systemLocation);
		travelTime = MathF.Round(travelTime);
		travelTime = travelTime / starShipSpeed;

		JourneyToDestination((int)travelTime);

		currentYear += (int)travelTime;
		currentSystem = destination;
	}

	private void JourneyToDestination(int years)
	{
		Journey journey = new Journey();

		int totalDeaths = 0;
		int totalBirths = 0;

		for (int i = 0; i < years; i++)
		{
			crew.CalculateTravelYear(journey);
		}

		journeys.Add(journey);
		currentPassengers = crew.crewTotal;

		/*
		Debug.Log("Total Deaths: " + totalDeaths);
		Debug.Log("Total Births: " + totalBirths);
		Debug.Log("Overall population change: " + (totalBirths - totalDeaths));
		*/
	}
}