using UnityEngine;
using System.Collections;

public class CoderWeapon : MonoBehaviour {
	
	private static CoderWeapon instance;
	private CoderKey targetKey;
	
	void Awake () {
		instance = this;
	}
	
	void Update () {
		// Testing only
		transform.Translate(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
		
		if (Input.GetKeyDown(KeyCode.G)) {
			animation.Play();
		}
	}
	
	#region Public methods
	public static void TargetKey(CoderKey key) {
		print ("Hitting key: " + key.name);
		instance.targetKey = key;
		// Play animation
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
