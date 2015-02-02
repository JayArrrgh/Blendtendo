using UnityEngine;
using System.Collections;

public class ClickToExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		Application.Quit ();
		print ("clickie");
	}
}
