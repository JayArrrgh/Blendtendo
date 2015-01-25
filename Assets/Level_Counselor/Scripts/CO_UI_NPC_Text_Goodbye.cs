using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_NPC_Text_Goodbye : MonoBehaviour 
{
	Text text;

	void Start()
	{
		text = GetComponent<Text>();
	}

	public void SuccessText()
	{
		text.text = "Yeah, that makes sense!";
	}

	public void FailText()
	{
		text.text = "...What? Are you even a licensed healthcare professional?";
	}

}