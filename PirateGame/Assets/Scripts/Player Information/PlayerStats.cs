using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour
{
    // Heres our statblock that can be used for any character. Ship will probably only have health, hardiness, strength, and accuracy.
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
    //Strength is main stat of Swashbuckler, determines damage of Swashbuckler and cannonballs for the Ship.
    public Stat strength;
    //Accuracy is main stat of Musketeer, determines damage of Musketeer. Also  determines accuracy of all characters including ship.
    public Stat accuracy;
    //Spirit is main stat of Witch, determines how many spirit points the Witch has.
    public Stat spirit;
    //Knowledge is main stat of Doctor, determines potency of the Doctor's skills.
    public Stat knowledge;
    //Hardiness decreases damage taken, unsure if we should do percentage or flat damage decrease.
    public Stat hardiness;
    //Spirit Points (SP) determines how many spells your Witch can cast in an encounter. Higher level Witch spells cost more energy.
    public Stat spiritPoints;

    // Sets current health to max health when game initializes.
    void Awake()
    {
        currentHealth = maxHealth;
    }

    // Method that lowers currentHealth when something in the game causes damage.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        // Call death method here later
    }

    // Add death method here later
}
