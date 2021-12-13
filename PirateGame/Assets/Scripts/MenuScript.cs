using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
	public GameObject menu;
	public GameObject minimap;
	public GameObject inGameMenu;
	

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (!inGameMenu.activeSelf)
			{
				if (menu.activeSelf)
				{
					exitMenu();
				}
				else
				{
					openMenu();
				}
			}
			
		}	
    }
	
	public void exitMenu()
	{
		Time.timeScale = 1;
		menu.SetActive(false);
		minimap.SetActive(true);
	}
	
	public void openMenu()
	{
		menu.SetActive(true);
		minimap.SetActive(false);
		Time.timeScale = 0;
	}
	
	
}
