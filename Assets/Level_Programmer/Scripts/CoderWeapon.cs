using UnityEngine;
using System.Collections;

public class CoderWeapon : MonoBehaviour {
	
	private static CoderWeapon instance;
	
	void Awake () {
		instance = this;
	}
	
	void Update () {
		// Testing only
		transform.Translate(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
	}
	
	#region Public methods
	public static void HitKey(Transform key) {
		print ("Hitting key: " + key.name);
	}
	#endregion
}
