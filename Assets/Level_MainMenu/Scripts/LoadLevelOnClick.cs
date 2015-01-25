using UnityEngine;
using System.Collections;

public class LoadLevelOnClick : MonoBehaviour {
	private bool loadLock = false;
	public string scene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) && !loadLock){
			loadLock = true;
			Application.LoadLevel(scene);
		}
	}
}
