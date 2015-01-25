using UnityEngine;
using System.Collections;

public class CoderScoreboard : MonoBehaviour {

	private static CoderScoreboard instance;
	
	private int score = 0;
	public int goldLevel = 20, silverLevel = 12, bronzeLevel = 5;
	//public GameObject goldMedal, silverMedal, bronzeMedal;
	
	void Awake () {
		instance = this;
	}
	
	public static void GetPoint () {
		instance.MyGetPoint();
	}
	
	private void MyGetPoint () {
		score++;
		CoderDestroyableWorkstation.Damage();
		if (score == goldLevel) {
			CoderDestroyableWorkstation.Destroy();
			CoderCountdown.StopStopWatch();
			CoderLevelEnder.EndLevel();
		}
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = score + " / " + goldLevel;
	}
}