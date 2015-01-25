using UnityEngine;
using System.Collections;

public class CoderLevelEnder : MonoBehaviour {
	
	private static CoderLevelEnder instance;
	public GameObject exitButton;
	
	void Awake () {
		instance = this;
	}
	
	public static void EndLevel () {
		CoderCountdown.StopStopWatch();
		CoderKeyboard.DeactivateAllKeys();
		CoderStatusText.DisplayResults(CoderScoreboard.GetLevel());
		instance.exitButton.SetActive(true);
	}
}
