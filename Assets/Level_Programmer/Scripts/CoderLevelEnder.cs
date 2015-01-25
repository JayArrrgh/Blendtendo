using UnityEngine;
using System.Collections;

public class CoderLevelEnder : MonoBehaviour {
	
	private static CoderLevelEnder instance;
	bool active = false;
	
	void Awake () {
		instance = this;
	}
	
	public static void EndLevel () {
		CoderCountdown.StopStopWatch();
		CoderStatusText.DisplayResults(CoderScoreboard.GetLevel());
		instance.active = true;
	}
	
	void Update () {
	
		if (active) {
			if (Input.GetMouseButtonDown(0)) {
				Application.LoadLevel("MenuScene");
			}
		}
	}
}
