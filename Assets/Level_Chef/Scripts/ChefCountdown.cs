using UnityEngine;
using System.Collections;
using System.Diagnostics;
using System;

public class ChefCountdown : CoderCountdown
{
  void Update()
  {
		guiText.text = prefix + Mathf.Max( ( float )( duration - sw.Elapsed.TotalSeconds ), 0 ).ToString( "F2" );
		if( sw.Elapsed.TotalSeconds > duration && !ChefMain.LevelEnded ) 
    {
      ChefMain.StaticEndLevel();
		}
	}
}
