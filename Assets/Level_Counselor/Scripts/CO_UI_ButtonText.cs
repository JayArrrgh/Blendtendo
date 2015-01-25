using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_ButtonText : MonoBehaviour {

	public CO_Megaman megaman = new CO_Megaman();

	Text text;

	// The piece of dialogue to associate with the button this script is attached to.
	// It can be changed in the Inspector to make each button display different dialogue.

	public int dialogueChoice;


	// How many seconds the dialogue TEXT (not the button) should take to fade into transparency.
	public float fadeTime;


	// Hides button TEXT only (not the button itself)

	public void HideButtonText()
	{
		text.CrossFadeAlpha(0, fadeTime, false);
	}

	void Awake()
	{
		text = GetComponent <Text> ();
	}

	void Update () 
	{
		text.text = megaman.GetDialogue(dialogueChoice);
	}
}
