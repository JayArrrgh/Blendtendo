using UnityEngine;
using System.Collections;

public class CoderKeyboard : MonoBehaviour {

	public CoderKey[] keys;
	public CoderKey backspaceKey;
	
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
	#endregion
	
	public static void InterpretKeyPress (CoderKey key) {
		if (key == BackspaceKey && ErrorCount > 0) {
			DeactivateKey(key);
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
			CoderOutput.PrintLine();
			
			// Tell GameManager or whatever about the success
			//////////////PUT THIS IN//////////////////////
			
			ActivateKey(PickRandomKeyNoRepeats());
		}
		else {
			if (ErrorCount == 0) {
				// If not backspace, save it for later
				MissedActiveKey = ActiveKey;
			}
			DeactivateKey(ActiveKey);
			CoderOutput.PrintError();
			ActivateKey(BackspaceKey);
			ErrorCount++;
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
	#endregion
}
