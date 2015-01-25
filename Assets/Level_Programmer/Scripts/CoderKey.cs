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
		CoderWeapon.HitKey(transform);
	}
	
	void OnTriggerEnter2D (Collider2D other) {
		print ("Contact! " + name);
		if (other.gameObject == CoderWeapon.Col2D) {
			print ("Layer! " + name);
			CoderKeyboard.InterpretKeyPress (this);
		}
	}
	#endregion
}
