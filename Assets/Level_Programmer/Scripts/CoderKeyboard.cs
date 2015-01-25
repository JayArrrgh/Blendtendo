using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoderKeyboard : MonoBehaviour {

	public CoderKey[] keys;
	public CoderKey backspaceKey;
	public AudioClip typingSound, errorSound;
	
	private static CoderKeyboard instance;
	private CoderKey activeKey;
	private CoderKey missedActiveKey;
	private CoderKey lastActiveKey;
	private int errorCount;
	
	void Awake () {
		instance = this;
		LastActiveKey = null;
	}
	
	void Start () {
		errorCount = 0;
		ActivateKey(PickRandomKeyNoRepeats());
	}
	
	void Update () {
		// Testing
		if (Input.GetKeyDown (KeyCode.F)) {
			ActivateKey(PickRandomKeyNoRepeats());
		}
	}
	
	#region Private Helpers
	private static CoderKey PickRandomKey () {
		
		int randomKeyIndex = Mathf.FloorToInt(Random.value * Keys.Length);
		return Keys[randomKeyIndex];
	}
	
	private static CoderKey PickRandomKeyNoRepeats () {
		
		CoderKey nextKey;
		do {
			nextKey = PickRandomKey();
		} while (nextKey == LastActiveKey);
		
		LastActiveKey = nextKey;
		
		return nextKey;
	}
	
	private static void ActivateKey (CoderKey key) {
		key.Activate();
		ActiveKey = key;
	}
	
	private static void DeactivateKey (CoderKey key) {
		key.Deactivate();
		//LastActiveKey = ActiveKey;
		ActiveKey = null;
	}
	
	public static void DeactivateAllKeys () {
		foreach (CoderKey key in Keys) {
			key.gameObject.SetActive(false);
		}
		BackspaceKey.gameObject.SetActive(false);
	}
	#endregion
	
	public static void InterpretKeyPress (CoderKey key) {
		if (key == BackspaceKey && ErrorCount > 0) {
			DeactivateKey(key);
			instance.audio.PlayOneShot(instance.typingSound);
			CoderOutput.DeleteError();
			ErrorCount--;
			if (ErrorCount == 0) {
				ActivateKey(MissedActiveKey);
			}
			else {
				ActivateKey(BackspaceKey);
			}
		}
		else if (key == ActiveKey) {
			key.Deactivate();
			instance.audio.PlayOneShot(instance.typingSound);
			CoderOutput.PrintLine();
			CoderScoreboard.GetPoint();
			ActivateKey(PickRandomKeyNoRepeats());
		}
		else {
			if (ErrorCount == 0) {
				// If not backspace, save it for later
				MissedActiveKey = ActiveKey;
			}
			DeactivateKey(ActiveKey);
			instance.audio.PlayOneShot(instance.errorSound);
			CoderOutput.PrintError();
			ActivateKey(BackspaceKey);
			ErrorCount = 1; // Track all errors with single boolean
			// ErrorCount++; // Track each error individually
		}
	}
	
	#region Properties
	private static CoderKey ActiveKey {
		get { return instance.activeKey; }
		set { instance.activeKey = value; }
	}
	private static CoderKey MissedActiveKey {
		get { return instance.missedActiveKey; }
		set { instance.missedActiveKey = value; }
	}
	private static CoderKey LastActiveKey {
		get { return instance.lastActiveKey; }
		set { instance.lastActiveKey = value; }
	}
	private static CoderKey[] Keys {
		get { return instance.keys; }
	}
	private static CoderKey BackspaceKey {
		get { return instance.backspaceKey; }
	}
	private static int ErrorCount {
		get { return instance.errorCount; }
		set { instance.errorCount = value; }
	}
	public static CoderKeyboard Keyboard {
		get { return instance; }
	}
	#endregion
}
