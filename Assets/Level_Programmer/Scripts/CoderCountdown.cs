using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class CoderCountdown : MonoBehaviour {
	
	public double duration;
	protected string prefix = "Time Remaining: ";
	protected static CoderCountdown instance;
	
	protected Stopwatch sw;
	
	
	void Awake () {
		instance = this;
		sw = new Stopwatch();
	}
	
	public static bool IsRunning {
		get { return instance.sw.IsRunning; }
	}
	
	public static void StartStopWatch () {
		instance.sw.Start();
	}
	
	public static void StopStopWatch () {
		instance.sw.Stop();
	}
	
	void Update () {
		
		if (Input.GetKeyDown(KeyCode.T)) {
			StartStopWatch();
		}
		
		guiText.text = prefix + Mathf.Max((float)(duration - sw.Elapsed.TotalSeconds), 0).ToString("F2");
		if (sw.Elapsed.TotalSeconds > duration && !CoderLevelEnder.LevelEnded) {
			CoderLevelEnder.EndLevel ();
		}
	}
}
