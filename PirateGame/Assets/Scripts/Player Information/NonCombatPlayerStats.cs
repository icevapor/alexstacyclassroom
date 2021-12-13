using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonCombatPlayerStats: MonoBehaviour
{
	public string crewmateName;
	
	public string shipName;
	
	// Sailing determines ship speed and chance to avoid certain obstacle related events.  Main stat for Helmsman.
	public Stat sailing;
	
	public Stat diplomacy;
	
}
