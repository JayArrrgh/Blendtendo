using UnityEngine;
using System.Collections;

public class CoderMusicPlayer : MonoBehaviour {

	private static CoderMusicPlayer instance;
	
	void Awake () {
		instance = this;
	}
	
	public static void StopMusic () {
		instance.audio.Stop();
	}
}
