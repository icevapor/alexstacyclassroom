using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MiniMapController : MonoBehaviour
{
	/*
	* Static map icon GameObjects must be added to the array
	* and set to inactive to start.  This script ensures
	* they are activated at the beginning of the game. 
	* We do this to reduce clutter in the scene editor--potentially
	* an obsolete script after development.
	*/
	public GameObject[] mapIcons;

    void Start()
    {
        for (int i = 0; i < mapIcons.Length; i++)
		{
			mapIcons[i].SetActive(true);
		}
    }
}
