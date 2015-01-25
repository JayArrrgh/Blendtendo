using UnityEngine;
using System.Collections;

public class CoderStatusText : MonoBehaviour {

	private static string instructions = "Click the lit\nkeys to write\ncode!";
	private static string goldText = "Workday vanquished!\nClick anywhere\nto continue";
	private static string silverText = "Level up!\nClick anywhere\nto continue";
	private static string bronzeText = "Good enough!\nClick anywhere\nto continue";
	private static string failText = "You're fired!\nClick anywhere\nto continue";
	
	private static CoderStatusText instance;
	
	// Use this for initialization
	void Awake () {
		instance = this;
		instance.guiText.text = instructions;
	}
	
	public static void DisplayResults (string level) {
		
		switch (level) {
			case "gold":
				instance.guiText.text = goldText;
				break;
			case "silver":
				instance.guiText.text = silverText;
				break;
			case "bronze":
				instance.guiText.text = bronzeText;
				break;
			default:
				instance.guiText.text = failText;
				break;
		}
	}
	
	
	
}
