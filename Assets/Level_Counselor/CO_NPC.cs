using UnityEngine;
using System.Collections;

public class CO_NPC 
{

	private string[] NPCDialogue = new string[4];

	public CO_NPC()
	{
		NPCDialogue[0] = "This Metroid paired with my head. It says it loves me, and that I am the only one for it. I'm having fun, but I don't want anything serious. What should I do?";
	}

	public string GetDialogue(int choice)
	{
		return NPCDialogue[choice];
	}

	
	// may eventually require functions/data for...
	// displaying associated art
}
