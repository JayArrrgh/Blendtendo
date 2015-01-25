using UnityEngine;
using System.Collections;
using System;

public class CoderDestroyableWorkstation : MonoBehaviour {
	
	private static CoderDestroyableWorkstation instance;
	public Sprite[] frames;
	SpriteRenderer spriteRenderer;
	
	void Awake () {
		instance = this;
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = frames[0];
	}
	
	void Update () {
		
	}
	
	public static void Damage () {
		
		int nextIndex = Array.IndexOf(Frames, SpRenderer.sprite) + 1;
		nextIndex = Mathf.Clamp(nextIndex, 0, Frames.Length - 1);
		SpRenderer.sprite = Frames[nextIndex];
	}
	
	public static void Destroy () {
		print ("Destroyed workstation");
	}
	
	private static SpriteRenderer SpRenderer {
		get { return instance.spriteRenderer; }
	}
	private static Sprite[] Frames {
		get { return instance.frames; }
	}
}
