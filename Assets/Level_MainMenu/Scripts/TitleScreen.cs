using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {

	public string scene;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel (scene);
			print ("hey it worked.");
		}
	}


}
