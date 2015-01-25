using UnityEngine;
using System.Collections;

public class CO_NPC 
{

	private string[] NPCDialogue = new string[4];

	public CO_NPC()
	{
		NPCDialogue[0] = "I got issues, doc. My brudda used ta feed my goldfish Goldfish crackas. I'm messed up man.";
	}

	public string GetDialogue(int choice)
	{
		return NPCDialogue[choice];
	}

	
	// will eventually require functions/data for...
	// displaying associated art
}
