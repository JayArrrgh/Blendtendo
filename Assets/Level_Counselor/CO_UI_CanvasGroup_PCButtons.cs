using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CO_UI_CanvasGroup_PCButtons : MonoBehaviour 
{
	CanvasGroup myCG;

	bool transition = false;

	float alphaValue = 0;

	void Awake () 
	{
		myCG = GetComponent<CanvasGroup>();
	}

	public void ShowGroup()
	{
		myCG.alpha = alphaValue;
	}


	public void BeginTransition()
	{
		transition = true;
	}

	void Update()
	{
		if (transition)
		{
			if (alphaValue < 1.0f)
			{
				alphaValue += Time.deltaTime;
				ShowGroup();
			}

			if (myCG.interactable == false)
			{
				if (alphaValue >= 1.0f)
				{
					myCG.interactable = true;
					transition = false;
	
				}
			}
		}
	}

}
