using UnityEngine;
using System.Collections;

public class CO_TextTyping : MonoBehaviour
{
	// Interval between each letter being typed in a string of text.
	public float typingSpeed;

	private int iterations = 0;

	private string typingText = "";

	// Creates a blank string and adds characters to it from the provided piece of dialogue text.
	public void TypeText(string line)
	{
		string textToType = line;
		typingText += textToType[iterations];
		iterations++;

		if (iterations < line.Length)
		{
			InvokeRepeating("TypeText", 0, typingSpeed);
		}

	}

	// This method is necessary to return the string being made above.

	public string ReturnText()
	{
		return typingText;
	}


}
