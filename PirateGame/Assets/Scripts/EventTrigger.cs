using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
	public string thisEvent;
	public GameObject eventController;
	
	
	public SpriteRenderer spriteRenderer;
    public Sprite[] eventSpriteArray;
	public Sprite[] fogOfWarSpriteArray;
	
	
	// Used for updating adjacent squares
	public GameObject[] eventArray;
	public int arrayIndex;
	
    // Start is called before the first frame update
    void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
		//spriteRenderer.sprite = fogOfWarSpriteArray[Random.Range(0, 4)];
    }
	
	void OnTriggerEnter2D (Collider2D collider)
    {			
		if (collider.tag == "Player")
		{
			Debug.Log("Player triggered "+thisEvent+" event.");
			
			switch (thisEvent)
			{
				case "COMBAT":
					ChangeSprite(0);
					break;
				case "WEATHER":
					ChangeSprite(1);
					eventController.GetComponent<EventController>().generateEvent(1);
					break;
				case "SHARK":
					ChangeSprite(2);
					break;
				case "SHOP":
					ChangeSprite(3);
					break;
				case "SUPPLY":
					ChangeSprite(4);
					break;
				case "TREASURE":
					ChangeSprite(5);
					break;
				case "CREWMATE":
					ChangeSprite(-1);
					break;
				case "KRAKEN":
					ChangeSprite(6);
					break;
				default:
					ChangeSprite(-1);
					break;
			}			
		} 
    }
	
	/* ChangeSprite is used to switch to the appropriate sprite for what direction the player is moving in
	* 
	* param:  int x - int variable corresponding to index in eventeventSpriteArray
	*/
    private void ChangeSprite(int x)
    {
		if (x == -1)
		{
			spriteRenderer.sprite = null;
			return;
		}
        spriteRenderer.sprite = eventSpriteArray[x];
    }
}
