using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_TextTyping : MonoBehaviour
{
	// Interval between each letter being typed in a string of text.
	public float typingSpeed = 0.2f;

	public int NPCDialogueChoice;

	public CO_NPC npc = new CO_NPC();

	Text text;

	string dialogue;

	GameObject obj;

	CanvasGroup therapizeCG;

	void Start()
	{
		text = GetComponent<Text>();
		dialogue = npc.GetDialogue(NPCDialogueChoice);
		text.text = "";
		obj = GameObject.Find("Therapize CanvasGroup");
		therapizeCG = obj.GetComponent<CanvasGroup>();
		StartCoroutine(TypeText());
	}

	// Creates a blank string and adds characters to it from the provided piece of dialogue text.
	IEnumerator TypeText()
	{
		foreach (char letter in dialogue.ToCharArray())
		{
			text.text += letter;
			yield return new WaitForSeconds(typingSpeed);
		}
		therapizeCG.alpha = 1.0f;
		therapizeCG.interactable = true;
	}

}
