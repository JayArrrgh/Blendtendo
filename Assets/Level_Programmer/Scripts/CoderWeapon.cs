using UnityEngine;
using System.Collections;

public class CoderWeapon : MonoBehaviour {
	
	private static CoderWeapon instance;
	private CoderKey targetKey;
	
	void Awake () {
		instance = this;
	}
	
	#region Public methods
	public static void TargetKey(CoderKey key) {
		
		instance.targetKey = key;
		if (instance.animation.isPlaying) {
			instance.animation.Stop ();
		}
		instance.animation.Play();
	}
	public void HitKey () {
		Camera.main.animation.Play("Camera jerk");
		instance.targetKey.GetHit();
	}
	#endregion
	
	public static Collider2D Col2D {
		get { return instance.collider2D; }
	}
}
