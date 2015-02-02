using UnityEngine;
using System.Collections;

public class CoderStatusText : MonoBehaviour {

  protected static string instructions = "Click the lit keys\nto write code!";
  private static string goldText = "Workday vanquished!";
  private static string silverText = "Level up!";
  private static string bronzeText = "Good enough!";
  private static string failText = "You're fired\n(for obvious\nreasons)";
	
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
				ScoreKeeper.SetGameStats(1, 3);
				break;
			case "silver":
				instance.guiText.text = silverText;
				ScoreKeeper.SetGameStats(1, 2);
				break;
			case "bronze":
				instance.guiText.text = bronzeText;
				ScoreKeeper.SetGameStats(1, 1);
				break;
			default:
				instance.guiText.text = failText;
				ScoreKeeper.SetGameStats(1, 0);
				break;
		}
	}
	
	
	
}
