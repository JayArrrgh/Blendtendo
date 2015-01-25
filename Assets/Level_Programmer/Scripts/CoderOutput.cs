using UnityEngine;
using System.Collections;

[RequireComponent (typeof (GUIText))]
public class CoderOutput : MonoBehaviour {

	public string[] codeLines;
	public string errorLine;
	
	private string current = "";
	private int linesPrinted;
	private GUIText output;
	private const float textUpdateRate = 0.05f;
	private static CoderOutput instance;
	
	void Awake () {
		instance = this;
	}
	
	void Start () {
		output = guiText;
		output.text = "";
		current = "";
		linesPrinted = 0;
		InvokeRepeating("UpdateCharacter", 0f, textUpdateRate);
	}
	
	#region Public methods
	public static void PrintLine () {
		instance.MyPrintLine();
	}
	public static void PrintError () {
		instance.MyPrintError();
	}
	public static void DeleteError () {
		instance.MyDeleteError();
	}
	#endregion
	
	#region private methods
	private void MyPrintLine () {
		
		if (current.IndexOf(errorLine) == -1) {
		
			if (linesPrinted < codeLines.Length) {
				current += codeLines[linesPrinted];
				linesPrinted++;
			}
			else {
				Debug.LogError ("Tried to print more lines than defined in codeLines array");
			}
		}
		else {
			Debug.LogError("Tried to add a real line before getting rid of error.");
		}
	}
	
	private void MyPrintError () {
		current += errorLine;
	}
	
	private void MyDeleteError () {
		
		int index = current.LastIndexOf(errorLine);
		if (index != -1) {
			//current = current.Substring(0, index); // Only removes last error
			current = current.Replace(errorLine, ""); // Removes all errors
		}
		else {
			Debug.LogError("Tried to remove errorLine but couldn't find it in the text");
		}
	}
	
	// Adds or removes a single character in the output
	private void UpdateCharacter () {
		
		// If output contains something not current, remove a character
		if (current.IndexOf(output.text) == -1) {
			output.text = output.text.Remove(output.text.Length - 1);
		}
		// Else if output's length is less than current's, add a character
		else if (output.text.Length < current.Length) {
			output.text += current[output.text.Length];
		}
	}
	#endregion
}
