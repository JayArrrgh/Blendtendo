using UnityEngine;
using System.Collections;

public class CoderLevelEnder : MonoBehaviour {

	private static CoderLevelEnder instance;
	private bool active;
	
	// Use this for initialization
	void Awake () {
		guiText.text = "CLICK ANYWHERE\nTO EXIT";
		instance = this;
		guiText.enabled = false;
		active = false;
	}
	
	public static void EndLevel () {
		instance.guiText.enabled = true;
		instance.active = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (active) {
			if (Input.GetMouseButtonDown(0)) {
				Application.LoadLevel("MenuScene");
			}
		}
	}
}
