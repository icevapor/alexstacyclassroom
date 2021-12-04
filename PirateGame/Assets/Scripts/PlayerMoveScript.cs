using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    Rigidbody2D rb2d;
	
    // moveSpeed determines player's velocity
    private float moveSpeed = 3;

    public const string EAST = "right";
    public const string WEST = "left";
    public const string NORTH = "up";
    public const string SOUTH = "down";
	
	public const string NORTH_EAST = "upright";
	public const string NORTH_WEST = "upleft";
	public const string SOUTH_EAST = "downright";
	public const string SOUTH_WEST = "downleft";

    string buttonPressed;
	
    public SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
	    
	/* ChangeSprite is used to switch to the appropriate sprite for what direction the player is moving in
	* 
	* param:  int x - int variable corresponding to index in spriteArray
	*/
    void ChangeSprite(int x)
    {
        spriteRenderer.sprite = spriteArray[x];
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            buttonPressed = NORTH_EAST;
        }
		else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
		{
			buttonPressed = SOUTH_EAST;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
		{
			buttonPressed = SOUTH_WEST;
		}
		else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
		{
			buttonPressed = NORTH_WEST;
		}
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            buttonPressed = EAST;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttonPressed = WEST;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            buttonPressed = NORTH;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            buttonPressed = SOUTH;
        }
        else
        {
            buttonPressed = null;
        }
    }

    private void FixedUpdate()
    {
		switch (buttonPressed)
		{
			case EAST:
				rb2d.velocity = new Vector2(moveSpeed, 0);
				ChangeSprite(0);
				break;
			case WEST:
				rb2d.velocity = new Vector2(-moveSpeed, 0);
				ChangeSprite(1);
				break;
			case NORTH:
				rb2d.velocity = new Vector2(0, moveSpeed);
				ChangeSprite(2);
				break;
			case SOUTH:
				rb2d.velocity = new Vector2(0, -moveSpeed);
				ChangeSprite(3);
				break;
			case NORTH_EAST:
				rb2d.velocity = new Vector2(moveSpeed / Mathf.Sqrt(2), moveSpeed / Mathf.Sqrt(2));
				break;
			case NORTH_WEST:
				rb2d.velocity = new Vector2(-moveSpeed / Mathf.Sqrt(2), moveSpeed / Mathf.Sqrt(2));
				break;
			case SOUTH_EAST:
				rb2d.velocity = new Vector2(moveSpeed / Mathf.Sqrt(2), -moveSpeed / Mathf.Sqrt(2));
				break;
			case SOUTH_WEST:
				rb2d.velocity = new Vector2(-moveSpeed / Mathf.Sqrt(2), -moveSpeed / Mathf.Sqrt(2));
				break;
			default:
				rb2d.velocity = new Vector2(0, 0);
				break;
		}
    }
}
