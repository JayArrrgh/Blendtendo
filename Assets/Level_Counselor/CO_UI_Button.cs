using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_Button : MonoBehaviour 
{
	Button myButton;
	Image myImage;

	public float fadeTime;

	void Awake()
	{
		myButton = GetComponent<Button>();
		myImage = GetComponent<Image>();
	}

	public void DisableButton()
	{
		myButton.interactable = false;
	}

	public void HideButton()
	{
		myImage.CrossFadeAlpha(0, fadeTime, true);
	}
}
