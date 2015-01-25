using UnityEngine;
using System.Collections;

public class CoderKey : MonoBehaviour {

	#region Public Methods
	public void Activate () {
		LightOn ();
	}
	public void Deactivate () {
		LightOff ();
	}
	#endregion
	
	
	private void LightOn () {
		renderer.enabled = true;
	}
	private void LightOff () {
		renderer.enabled = false;
	}
	private bool IsActive {
		get { return renderer.enabled; }
	}
		
	#region Events
	void OnMouseDown () {
		CoderWeapon.TargetKey(this);
	}
	
	public void GetHit () {
		CoderKeyboard.InterpretKeyPress (this);
	}
	#endregion
}
