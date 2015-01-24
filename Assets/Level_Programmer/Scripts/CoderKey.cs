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
	private void PressKey () {
		
		if (IsActive) {
			// Send keyboard a success message
		}
		else {
			// Send keyboard a failure message
		}
	}
		
	#region Events
	void OnMouseDown () {
		CoderWeapon.HitKey(transform);
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer("KeyPresser")) {
			PressKey();
		}
	}
	#endregion
}
