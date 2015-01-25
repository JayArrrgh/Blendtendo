using UnityEngine;
using System.Collections;

public class PlayerReady : MonoBehaviour {

	public bool ready = false;
	public bool standing;
	public Vector2 maxVelocity = new Vector2(3,5);
	public float speed = 10f;
	public float airSpeedMultiplier = .3f;

	private PlayerMovement controller;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();	
		controller = GetComponent<PlayerMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs (rigidbody2D.velocity.x);
		var absVelY = Mathf.Abs (rigidbody2D.velocity.y);
		if (Input.GetMouseButtonDown (0)) {
			if (absVelY < .2f) {
				standing = true;
			} else {
				standing = false;
			}
			if (!standing) {
				animator.SetInteger ("AnimState", 1);
			} else {
				animator.SetInteger ("AnimState", 0);
			}

//			if (controller.moving.x != 0 && !standing) {
//				if (absVelX < maxVelocity.x) {
//					forceX = standing ? speed * controller.moving.x : (speed * controller.moving.x * airSpeedMultiplier);
//					transform.localScale = new Vector3 (forceX > 0 ? 1 : -1, 1, 1);
//				}
//				animator.SetInteger ("AnimState", 1);
//			} else {
//				animator.SetInteger ("AnimState", 0);
//			}
		}

	}

}