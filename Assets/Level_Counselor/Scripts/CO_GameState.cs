using UnityEngine;
using System.Collections;

public class CO_GameState : MonoBehaviour 
{
	public CO_Megaman megaman = new CO_Megaman();

	// NPC talks
	// Your choices appear
	// you make choice
	// game result
	
	// load assets (NPC art, dialogue)
	// type NPC dialogue
	// display player choices
	// player makes choice
	// other dialogue disappears
	// game result

	private CO_SpriteChanger changer;

	int score;


	// Audio sources (and a couple of clips required)

	public AudioSource winSound;

	public AudioSource lossSound;

	public AudioSource therapizeSound;

	public AudioClip therapizeClip;

	public AudioSource music;

	public AudioSource dialogueSelect;

	public AudioClip dialogueClip;

	public void PlayMusic()
	{
		music.Play();
	}

	public void PlayTherapize()
	{
		therapizeSound.PlayOneShot(therapizeClip, 2.0f);
	}

	public void PlayDialogueSelect()
	{
		dialogueSelect.Play();
	}

	public void PlayWinSound()
	{
		winSound.Play();
	}

	public void PlayLossSound()
	{
		lossSound.Play();
	}

	public void StopMusic()
	{
		if (music.isPlaying)
			music.Stop();
	}

	public void StopDialogueMusic()
	{
		if (dialogueSelect.isPlaying)
			dialogueSelect.Stop();
	}


	// Scoretracking methods
	// these were designed to be called via a button's OnClick event in the Inspector.

	public void ScoreZero()
	{
		score = 0;
		Debug.Log (score);
	}

	public void ScoreBronze()
	{
		score = 1;
		Debug.Log (score);
	}

	public void ScoreSilver()
	{
		score = 2;
		Debug.Log (score);
	}

	public void ScoreGold()
	{
		score = 3;
		Debug.Log (score);
	}

	public void ResolvePlayerChoice(int choice)
	{
		changer = GetComponent<CO_SpriteChanger>();

		//StartCoroutine(DialogueTransition());

		if (megaman.GetOutcome(choice) == true)
		{
			// end the game in the success state
			changer.ChangeSprite(true);
			music.Stop();
			PlayWinSound();
		}
		else
		{
			// end the game in the fail state
			changer.ChangeSprite(false);
			music.Stop();
			PlayLossSound();
		}
	}


	public void ReturnToMenu()
	{
		ScoreKeeper.SetGameStats(1, score);
		Debug.Log (score);
		Application.LoadLevel("MenuScene");
	}






}
