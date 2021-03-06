using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuNavigation : MonoBehaviour
{
	public GameObject gameSetupMenu;
	
	public GameObject mainMenu;
	
	public GameObject crewRoster;
	public GameObject captain;
	
	public InputField captainNameText;
	public InputField shipNameText;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void playButton()
	{
		gameSetupMenu.SetActive(true);
		mainMenu.SetActive(false);
	}
	
	public void backButton()
	{
		gameSetupMenu.SetActive(false);
		mainMenu.SetActive(true);
	}
	
	public void loadGame()
	{
		captain.GetComponent<NonCombatPlayerStats>().crewmateName = captainNameText.text;
		captain.GetComponent<NonCombatPlayerStats>().shipName = shipNameText.text;
		captain.GetComponent<NonCombatPlayerStats>().sailing = new Stat(10);
		captain.GetComponent<NonCombatPlayerStats>().diplomacy = new Stat(10);
		
		DontDestroyOnLoad(crewRoster);
		SceneManager.LoadScene(1);
	}
	
	
}
