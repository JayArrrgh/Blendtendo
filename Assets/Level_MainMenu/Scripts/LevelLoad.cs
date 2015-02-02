using UnityEngine;
using System.Collections;

public class LevelLoad : MonoBehaviour {

	public string scene;
	public float time;
	public AudioClip sound;
	
	private bool loadLock = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void LoadScene(){
		loadLock = true;
		//yield WaitForSeconds (audio.clip.length);
		Application.LoadLevel (scene);
		print ("hey it worked.");

	}

	void OnMouseDown(){
		if (!loadLock){
			loadLock = true;
		}
	}

	void OnTriggerEnter2D(Collider2D target){
		if (target.gameObject.tag == "Player" ) {
			if (loadLock == true){

				StartCoroutine( LoadSceneDelayed());
				audio.PlayOneShot(sound);
			}
		}
	}

	IEnumerator LoadSceneDelayed () {
		print ("hey before wait for " + time);
		yield return new WaitForSeconds (time);
		print ("hey after wait");
		print(Time.time);
		LoadScene ();
	}

}
