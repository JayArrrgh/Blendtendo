using UnityEngine;
using System.Collections;

public class CoderKeyboard : MonoBehaviour {

	public CoderKey[] keys;
	public CoderKey backspaceKey;
	
	private static CoderKeyboard instance;
	private CoderKey activeKey;
	private CoderKey missedActiveKey;
	private int errorCount;
	
	void Awake () {
		instance = this;
	}
	
	void Start () {
		errorCount = 0;
	}
	
	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			ActivateKey(PickRandomKey());
		}
	}
	
	private static CoderKey PickRandomKey () {
		int randomKeyIndex = Mathf.FloorToInt(Random.value * Keys.Length);
		return Keys[randomKeyIndex];
	}
	
	private static void ActivateKey (CoderKey key) {
		key.Activate();
		ActiveKey = key;
	}
	
	private static void DeactivateKey (CoderKey key) {
		key.Deactivate();
		ActiveKey = null;
	}
	
	public static void InterpretKeyPress (CoderKey key) {
		if (key == BackspaceKey && ErrorCount > 0) {
			// Turn it off
			DeactivateKey(key);
			// Send delete error to the output
			CoderOutput.DeleteError();
			// Decrement the error count
			ErrorCount--;
			print ("errors: " + ErrorCount);
			if (ErrorCount == 0) {
				print ("Activating old missed: " + MissedActiveKey.name);
				// Re-activate previous next
				ActivateKey(MissedActiveKey);
			}
			else {
				ActivateKey(BackspaceKey);
			}
		}
		else if (key == ActiveKey) {
			// Turn it off
			key.Deactivate();
			// Send success message to the output
			CoderOutput.PrintLine();
			
			// Tell GameManager or whatever about the success
			//////////////PUT THIS IN//////////////////////
			
			// ?wait? and move onto the next one.
			ActivateKey(PickRandomKey());
		}
		else {
			// If not backspace, save it for later
			if (ErrorCount == 0) {
				MissedActiveKey = ActiveKey;
			}
			// Turn it off
			DeactivateKey(ActiveKey);
			// Send error to the output
			CoderOutput.PrintError();
			// Activate the backspace
			ActivateKey(BackspaceKey);
			// Increment the error count
			ErrorCount++;
			print ("Errors: " + ErrorCount);
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
