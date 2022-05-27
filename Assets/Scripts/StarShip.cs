using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StarShip : MonoBehaviour
{
	public static StarShip Instance = null;

	public StarSystem currentSystem;
	public UIDocument journeyInfoPanel;
	public int currentYear = 0;
	public int maximumPassengers = 5000;
	public int currentPassengers;
	public Button okButton;
	public GameEvent updateUniverse;

	public Crew crew;

	public List<Journey> journeys = new List<Journey>();

	float starShipSpeed = 2f;

	
	// Initialize the singleton instance.
	private void Start()
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
		
		journeyInfoPanel.rootVisualElement.visible = false;

		okButton = journeyInfoPanel.rootVisualElement.Q<Button>("okButton");
		okButton.clickable.clicked += OkButton;

		updateUniverse.Raise();
	}

	private void OkButton()
	{
		journeyInfoPanel.rootVisualElement.visible = false;
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

		updateUniverse.Raise();
	}

	private void JourneyToDestination(int years)
	{
		Journey journey = new Journey();
		journey.yearStarted = currentYear;
		journey.length = years;
		journey.journeyNumber = journeys.Count;

		for (int i = 0; i < years; i++)
		{
			crew.CalculateTravelYear(journey);
		}

		journeys.Add(journey);
		journey.journeyNumber = journeys.Count;
		currentPassengers = crew.crewTotal;

		PopulateJourneyInfoPanel(journey);
		journeyInfoPanel.rootVisualElement.visible = true;
	}

	private void PopulateJourneyInfoPanel(Journey journey)
	{
		if (currentPassengers > 0)
		{
			journeyInfoPanel.rootVisualElement.Q<Label>("JourneyName").text = "Journey #" + journey.journeyNumber;
			journeyInfoPanel.rootVisualElement.Q<Label>("JourneyDescription").text = "Length: " + journey.length + " years." + "\n"
				+ "Total Deaths: " + journey.totalDeaths + "\n"
				+ "Total Births: " + journey.totalBirths + "\n"
				+ "\n"
				+ "Remaining crew: " + currentPassengers;
		}
		else
			journeyInfoPanel.rootVisualElement.Q<Label>("JourneyDescription").text = "All passengers have perished." + "\n"
				+ "\n"
				+ "You lasted for " + journey.journeyNumber + " journeys." + "\n"
				+ "\n"
				+ "GAME OVER";
	}

	private void PrintJourney(Journey journey)
	{
		Debug.Log("Start year: " + journey.yearStarted);
		Debug.Log("Length: " + journey.length);
		Debug.Log("Total births: " + journey.totalBirths);
		Debug.Log("Total deaths: " + journey.totalDeaths);
	}
}