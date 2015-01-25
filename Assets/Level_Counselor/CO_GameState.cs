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


	private CO_SpriteChanger changer;

	public void DisplayNPCDialogue()
	{

	}


	public void ResolvePlayerChoice(int choice)
	{
		changer = GetComponent<CO_SpriteChanger>();
		if (megaman.GetOutcome(choice) == true)
		{
			// end the game in the success state
			Debug.Log ("You won!");
			changer.ChangeSprite(true);
		}
		else
		{
			// end the game in the fail state
			Debug.Log ("You lost!");
			changer.ChangeSprite(false);
		}
	}



}
