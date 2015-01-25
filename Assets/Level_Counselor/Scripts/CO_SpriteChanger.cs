using UnityEngine;
using System.Collections;

public class CO_SpriteChanger : MonoBehaviour 
{
	private GameObject sprite;

	public Sprite sadSprite;

	public Sprite happySprite;

	private SpriteRenderer render;

	public void ChangeSprite(bool spriteChoice)
	{
		sprite = GameObject.Find("Metroid couch");

		render = sprite.GetComponent<SpriteRenderer>();

		if (spriteChoice)
		{
			render.sprite = happySprite;
		}
		else
			render.sprite = sadSprite;


	}

}
