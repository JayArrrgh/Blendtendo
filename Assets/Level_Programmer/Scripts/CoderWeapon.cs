using UnityEngine;
using System.Collections;

public class CoderWeapon : MonoBehaviour {
	
	private static CoderWeapon instance;
	
	void Awake () {
		instance = this;
	}
	
	void Update () {
		
		// Testing only
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
		
	}
	
	#region Public methods
	public static void HitKey(Transform key) {
		print ("Hitting key: " + key.name);
	}
	#endregion
}
