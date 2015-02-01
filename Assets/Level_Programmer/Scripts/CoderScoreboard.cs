using UnityEngine;
using System.Collections;

public class CoderScoreboard : MonoBehaviour {

	private static CoderScoreboard instance;
	
	protected int score = 0;
	protected string prefix = "Code Written: ";
	public int goldLevel = 20, silverLevel = 12, bronzeLevel = 5;
	//public GameObject goldMedal, silverMedal, bronzeMedal;
	
	void Awake () {
		instance = this;
	}
	
	public static void GetPoint () {
		instance.MyGetPoint();
	}
	
	protected virtual void MyGetPoint () {
		score++;
		CoderDestroyableWorkstation.Damage();
		if (score == goldLevel) {
			CoderDestroyableWorkstation.Destroy();
			
			CoderLevelEnder.EndLevel();
		}
	}
	
	public static string GetLevel () {
		if (instance.score >= instance.goldLevel) {
			return "gold";
		}
		else if (instance.score >= instance.silverLevel) {
			return "silver";
		}
		else if (instance.score >= instance.bronzeLevel) {
			return "bronze";
		}
		
		return "fail";
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = prefix + score + " / " + goldLevel;
	}
}