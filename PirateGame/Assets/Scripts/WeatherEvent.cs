using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEvent : MonoBehaviour
{
	public GameObject menu;
	public GameObject eventText;
	public GameObject optionText;
	
	
	public void startEvent()
	{
		// TODO:  weather event code
		menu.gameObject.SetActive(true);
	}
}
