using UnityEngine;
using System.Collections;

public class CO_GameState : MonoBehaviour 
{
	public CO_Megaman megaman = new CO_Megaman();

	// NPC talks
	// Your choices appear
	// you make choice
	// game result
	
	// load assets (NPC art, dialogue)
	// type NPC dialogue
	// display player choices
	// player makes choice
	// other dialogue disappears
	// game result


	public void DisplayNPCDialogue()
	{

	}


	public void ResolvePlayerChoice(int choice)
	{
		if (megaman.GetOutcome(choice) == true)
		{
			// end the game in the success state
			Debug.Log ("You won!");

		}
		else
		{
			// end the game in the fail state
			Debug.Log ("You lost!");
		}
	}



}
