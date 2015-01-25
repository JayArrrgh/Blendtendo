using UnityEngine;
using System.Collections;

public class CO_NPC 
{

	private string[] NPCDialogue = new string[4];

	public CO_NPC()
	{
		NPCDialogue[0] = "This Metroid has coupled with my head. I don't think that it is really in love with me, and I am certainly not in love with it. What should I do?";
	}

	public string GetDialogue(int choice)
	{
		return NPCDialogue[choice];
	}

	
	// may eventually require functions/data for...
	// displaying associated art
}
