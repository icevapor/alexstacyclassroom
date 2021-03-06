using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
	// Probability of an event occuring at any given event space.  Currently 77 total event spaces.
	public float EVENT_PROBABILITY = 0.10f;
	
	// These arrays are associated.  If you're adding a new event--add it here.
	// Add your event tag and probability at the same index.
	// The balance of the game is based on the probability array summing to 1.0,
	// if you plan on making a change, be sure to discuss it.
	private float[] probabilityArray = {0.2f, 0.2f, 0.05f, 0.25f, 0.1f, 0.1f, 0.05f, 0.05f};
	private string[] eventTagArray = {"COMBAT", "WEATHER", "SHARK", "SHOP", "SUPPLY", "TREASURE", "CREWMATE", "KRAKEN"};
	
	//debug variable, remove later
	public int totalEvents = 0;

	
	
	/* Holds a reference to each possible spawn point on sea.
	*  Spawn points are arranged with 11 columns and 7 rows.
	*  In other words:  there are 11 elements in each of the 7 rows.
	* 
	*  They are stored in a one-dimensional array however.
	*  To access the element in the 5th element in the 6th row
	*  you would access element ((11 * 7) + 5) - 1 ( -1 to account for zero based indexing)
	*/
	public GameObject[] eventSpawnPoints;
	
	/* All code neccesary for execution of events
	*  goes in this array.  Ensure indexing for each event
	*  matches eventTagArray and probabilityArray.
	*/
	public GameObject[] eventScripts;
	
	/*
	* Generates an event.
	* 
	* @param:  index - index that corrolates to event to be executed
	*				   this index should match probabilityArray and
	*				   eventTagArray's indexing.
	*/
	public void generateEvent(int index)
	{
		switch (index)
		{
			case 1: // WEATHER
				eventScripts[index].GetComponent<WeatherEvent>().startEvent();
				break;
			default:
				break;
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < 77; i++)
		{
			eventSpawnPoints[i].GetComponent<EventTrigger>().thisEvent = getEvent(i);
			eventSpawnPoints[i].GetComponent<EventTrigger>().arrayIndex = i;
		}
    }
	
	private string getEvent(int index)
	{
		//  Roll to see if an event occurs
		if (Random.Range(0.0f, 1.0f) < (1.0f - (EVENT_PROBABILITY * getProbabilityMultiplier(index)) ) )
		{
			return "NONE";
		}
		
		totalEvents++;
		
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
	
	/*
	* Gets a multiplier for the event probability
	* based on the position of the event tile.
	* Tiles towards to top and bottom of the map are weighted
	* heavier, along with tiles towards the right.
	*/
	private float getProbabilityMultiplier(int index)
	{
		float multiplier = 1.0f;
		
		if (index < 22)
		{
			multiplier += 1.0f;
		}
		if (index >= 66)
		{
			multiplier += 1.0f;
		}
		if ((index >= 33 && index <= 36) || (index >= 44 && index <= 47))
		{
			multiplier -= 1.0f;
		}
		if ( (index % 11) >= 5)
		{
			multiplier += 0.5f;
		}
		
		return multiplier;
	}
	
	
}
