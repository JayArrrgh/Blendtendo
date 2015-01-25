using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_NPCText : MonoBehaviour {

	Text text;

	public int NPCDialogueChoice;


	public CO_NPC npc = new CO_NPC();



	private string diag;


	void Awake()
	{
		text = GetComponent<Text>();

		diag = npc.GetDialogue(NPCDialogueChoice);

	}


	private string TyperHandler()
	{
		CO_TextTyping typer = GetComponent<CO_TextTyping>();
		if (typer != null)
		{
			Debug.Log ("IN!");
			typer.TypeText(diag);
			return typer.ReturnText();
		}
		else
		{
			return diag;
		}
	}

	void Start()
	{

	}


	void Update()
	{
		text.text = TyperHandler();
	}
}
