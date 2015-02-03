using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public int medalType;
	public string gameName;


	// Use this for initialization
	void Start () {
	
	}

	void Awake(){
		if (PlayerPrefs.GetInt (gameName + "_Played", 0) == 1 && PlayerPrefs.GetInt (gameName + "_Score", 0) == medalType && medalType !=0) {
			gameObject.SetActive(true);
			print ("score");
		} else {
			gameObject.SetActive(false);
			print ("No score");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

	public static void SetGameStats(int played, int score){
		string isPlayed = Application.loadedLevelName + "_Played";
		string hasScore = Application.loadedLevelName + "_Score";

		PlayerPrefs.SetInt(isPlayed, played);
		PlayerPrefs.SetInt(hasScore, score);
		PlayerPrefs.Save ();
	}
}
