using System.Collections;

public class CO_Megaman
{
	// Data storage for all of the dialogue choices for the character.
	
	private string[] dialogue = new string[4];


	
	// Data storage for all of the outcomes of the character's dialoge.
	// Make sure the outcome's index corresponds with the index of the desired dialogue choice.
	
	private bool[] outcome = new bool[4];

	public CO_Megaman()
	{

	dialogue[0] = "This is the first choice";
	dialogue[1] = "This is the second choice";
	dialogue[2] = "Third choice.";
	dialogue[3] = "Fourth choice.";

	outcome[0] = false;
	outcome[1] = true;
	outcome[2] = false;
	outcome[3] = true;
	}
	
	// Retrieves a specific line of dialogue.
	
	public string GetDialogue (int diag_choice)
	{
		return dialogue[diag_choice];
	}
	
	
	// Retrieves the outcome (pass/fail) of the provided dialogue choice.
	//
	
	public bool GetOutcome (int outcome_choice)
	{
		return outcome[outcome_choice];
	}




}
