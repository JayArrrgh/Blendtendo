using UnityEngine;
using System.Collections;

public class CoderWeapon : MonoBehaviour {
	
	private static CoderWeapon instance;
	private CoderKey targetKey;
	public Animator knightAnim;
	
	void Awake () {
		instance = this;
	}
	
	#region Public methods
	public static void TargetKey(CoderKey key) {
		
		instance.targetKey = key;
		if (instance.animation.isPlaying) {
			instance.animation.Stop ();
		}
		instance.animation.Play("AxeSwing-" + key.name);
		
		instance.knightAnim.SetBool("Swing", false);
		instance.knightAnim.SetBool("Swing", true);
		instance.knightAnim.SetBool("Swing", false);
		
		
	}
	public void HitKey () {
		Camera.main.animation.Play("Camera jerk");
		instance.targetKey.GetHit();
		CoderDestroyableWorkstation.Damage();
		instance.knightAnim.SetBool("Swing", false);
	}
	#endregion
	
	public static Collider2D Col2D {
		get { return instance.collider2D; }
	}
}
