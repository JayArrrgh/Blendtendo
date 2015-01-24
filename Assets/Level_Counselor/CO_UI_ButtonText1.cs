using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_ButtonText1 : MonoBehaviour {

	public CO_Megaman megaman = new CO_Megaman();

	Text text;

	void Awake()
	{
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = megaman.GetDialogue(0);
	}
}
