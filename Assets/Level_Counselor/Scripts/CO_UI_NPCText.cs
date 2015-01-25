using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_NPCText : MonoBehaviour {

	Text text;

	public int NPCDialogueChoice;

	public CO_NPC npc = new CO_NPC();

	private string diag;


	void Start()
	{
		text = GetComponent<Text>();
		diag = npc.GetDialogue(NPCDialogueChoice);

	}


	void Update()
	{
		text.text = diag;
	}
}
