using UnityEngine;
using System.Collections;

public class CO_UI_ButtonBase : MonoBehaviour 
{

	// constants for dialogue button positioning.
	// ALL BUTTON SCRIPTS SHOULD INHERIT FROM THIS CLASS

	// offsets are the padding space between UI elements


	public const int UI_OFFSET_X = 30;
	public const int UI_OFFSET_Y = 30;


	// the total number of UI elements that share the same X plane as the buttons.
	// this includes the buttons, and the potential character portrait.

	public const int NUM_UI_ELEMENTS = 5;



}
