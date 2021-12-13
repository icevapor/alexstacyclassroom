using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEvent : MonoBehaviour
{
	public GameObject menu;
	public GameObject eventText;
	public GameObject optionText;
	
	// These arrays are associated.  If you're adding a new event--add it here.
	// Add your event tag and probability at the same index.
	// The balance of the game is based on the probability array summing to 1.0,
	// if you plan on making a change, be sure to discuss it.
	private float[] probabilityArray = {0.33f, 0.33f, 0.34f};
	private string[] eventTagArray = {"STORM", "CALM SEAS", "FOG"};

	public void startEvent()
	{
		string weather = rollWeatherEvent();
		switch (weather)
		{
			case "STORM":
				storm();
				break;
			case "CALM SEAS":
				storm();
				break;
			case "FOG":
				storm();
				break;
			default:
				break;
		}
	}
	
	private void storm()
	{
	}
	
	private void fog()
	{
	}
	
	private void calmSeas()
	{
	}
	
	private string rollWeatherEvent()
	{
		float roll = Random.Range(0.0f, 1.0f);
		
		/*
		* This loop calculates the event based on the probabilities in the probabilityArray.
		* It loops through a range of the probabilities and checks if the roll is between a
		* certain bound to determine what event is chosen.
		*/
		float currentCummulativeProbability = 0.0f;
		for (int i = 0; i < probabilityArray.Length; i++)
		{
			float lowerBound = currentCummulativeProbability;
			currentCummulativeProbability = probabilityArray[i] + currentCummulativeProbability;
			if (roll >= lowerBound && roll <= currentCummulativeProbability)
			{
				return eventTagArray[i];
			}
		}
		
		// failsafe
		return null;
	}

}
