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
	private float[] probabilityArray = {0.25f, 0.2f, 0.05f, 0.25f, 0.1f, 0.1f, 0.05f};
	private string[] eventTagArray = {"COMBAT", "WEATHER", "SHARK", "SHOP", "SUPPLY", "TREASURE", "CREWMATE"};

	
	
	/* Holds a reference to each possible spawn point on sea.
	*  Spawn points are arranged with 11 columns and 7 rows.
	*  In other words:  there are 11 elements in each of the 7 rows.
	* 
	*  They are stored in a one-dimensional array however.
	*  To access the element in the 5th element in the 6th row
	*  you would access element ((11 * 7) + 5) - 1 ( -1 to account for zero based indexing)
	*/
	public GameObject[] eventSpawnPoints;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
		for (int i = 0; i < 77; i++)
		{
			eventSpawnPoints[i].GetComponent<EventTrigger>().thisEvent = getEvent(i);
		}
    }
	
	private string getEvent(int index)
	{
		//  Roll to see if an event occurs
		if (Random.Range(0.0f, 1.0f) > EVENT_PROBABILITY)
		{
			return "NONE";
		}
		
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
