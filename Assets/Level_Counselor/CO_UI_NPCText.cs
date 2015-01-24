using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_NPCText : MonoBehaviour {

	Text text;

	public int NPCDialogueChoice;


	public CO_NPC npc = new CO_NPC();


	void Awake()
	{
		text = GetComponent<Text>();
	}



	void Update()
	{
		text.text = npc.GetDialogue(NPCDialogueChoice);
	}
}
