using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public int directionX = 0;
	public float speed = 1f;
	public bool needsCollision = true;
	public Vector3 mouseClick;

	private Animator animator;
	//private bool collision = false;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();	
		mouseClick = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			mouseClick = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}

		if ((transform.position.x < (mouseClick.x + .2f)) && (transform.position.x > (mouseClick.x - .2f))) {
				directionX = 0;
		} else {
				if (mouseClick.x - transform.position.x > 0.1f) {
						directionX = 1;
						transform.localScale = new Vector3 (-1.5f, 1.5f, 1.5f);
				} else if (mouseClick.x - transform.position.x < 0.1f) {
						directionX = -1;
						transform.localScale = new Vector3 (1.5f, 1.5f, 1.5f);
				}
		}

		if (directionX != 0) {
				transform.Translate (directionX * speed * Time.deltaTime, 0, 0);
				animator.SetInteger ("AnimState", 1);
		} else {
				animator.SetInteger ("AnimState", 0);
		}
	}
}
