using UnityEngine;
using System.Collections;

public class CoderKey : MonoBehaviour {

	public Sprite litSprite, rightSprite, wrongSprite;
	new SpriteRenderer renderer;
	
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
		renderer.sprite = litSprite;
		LightOff ();
	}
	
	#region Public Methods
	public void Activate () {
		renderer.sprite = litSprite;
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
		if (IsActive) {
			// Flash right
			StartCoroutine("FlashRight");
			CoderWeapon.TargetKey(this);
		}
		else {
			// Flash wrong and turn off
			StartCoroutine("FlashWrong");
			CoderWeapon.TargetKey(this);
		}
	}
	
	IEnumerator FlashRight () {
		renderer.sprite = rightSprite;
		yield return new WaitForSeconds(0.15f);
		renderer.sprite = litSprite;
	}
	
	IEnumerator FlashWrong () {
		renderer.sprite = wrongSprite;
		LightOn ();
		yield return new WaitForSeconds(0.15f);
		LightOff ();
	}
	
	public void GetHit () {
		
		if (!CoderLevelEnder.LevelEnded) {
			if (!CoderCountdown.IsRunning) {
				CoderCountdown.StartStopWatch();
			}
			CoderKeyboard.InterpretKeyPress (this);
		}
	}
	#endregion
}
