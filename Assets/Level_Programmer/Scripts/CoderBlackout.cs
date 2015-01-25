using UnityEngine;
using System.Collections;

public class CoderBlackout : MonoBehaviour {
	
	private static CoderBlackout instance;
	
	void Awake () {
		instance = this;
		Rect screen = new Rect(0, 0, Screen.width, Screen.height);
		guiTexture.pixelInset = screen;
	}
	
	void Start () {
		FadeIn ();
	}
	
	public static void FadeIn () {
		instance.animation.Play("FadeIn");
	}
	
	public static void FadeOut () {
		instance.animation.Play("FadeOut");
	}
}
