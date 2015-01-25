using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoderLevelEnder : MonoBehaviour {
	
	private static CoderLevelEnder instance;
	public GameObject exitButton;
	public AudioClip winSound, loseSound;
	private bool levelEnded = false;
	
	void Awake () {
		instance = this;
	}
	
	public static void EndLevel () {
		
		if (!LevelEnded) {
			instance.levelEnded = true;
			CoderCountdown.StopStopWatch();
			CoderKeyboard.DeactivateAllKeys();
			CoderStatusText.DisplayResults(CoderScoreboard.GetLevel());
			
			CoderMusicPlayer.StopMusic();
			
			if (CoderScoreboard.GetLevel() == "fail") {
				instance.audio.PlayOneShot(instance.loseSound);
			}
			else {
				instance.audio.PlayOneShot(instance.winSound);
			}
	
			instance.exitButton.SetActive(true);
		}
	}
	public static bool LevelEnded {
		get { return instance.levelEnded; }
	}
}
