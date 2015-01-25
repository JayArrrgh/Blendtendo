using UnityEngine;
using System.Collections;

public class CoderExitButton : MonoBehaviour {
	
	void Start () {
		gameObject.SetActive(false);
	}
	
	void OnMouseDown () {
		StartCoroutine("FadeAndLoad");
	}
	
	IEnumerator FadeAndLoad () {
		CoderBlackout.FadeOut();
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("MenuScene");
	}
}
