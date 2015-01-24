using UnityEngine;
using System.Collections;

public class CoderOutput : MonoBehaviour {

	public string[] codeLines;
	public string errorLine;
	
	private GUIText output;
	private string current = "";
	
	void Start () {
		output = guiText;
		output.text = "";
		InvokeRepeating("PrintCharacter", 0f, 0.1f);
	}
	
	public void PrintLine () {
		
	}
	
	public void PrintError () {
		
	}
	
	private void PrintCharacter () {
		if (current != output.text) {
			output.text += current.Substring(output.text.Length, 1);
		}
	}
}
