using UnityEngine;
using System.Collections;

public class CO_UI_EndButton : MonoBehaviour {


	CanvasGroup eCG;

	void Start () 
	{
		eCG = GetComponent<CanvasGroup>();

	}

	public void MakeVisible()
	{
		eCG.alpha = 1.0f;
		eCG.interactable = true;
	}
}
