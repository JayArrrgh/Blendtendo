using UnityEngine;
using System.Collections;

public class ChefMain : MonoBehaviour
{
	public static ChefMain me = null;

  public static bool LevelEnded = false;

  public static int NumberOfGoodFoodPrepared = 0;
  public static int NumberOfBadFoodPrepared = 0;
  public static int NumberOfFoodThrownOut = 0;
  
  //public static float totalTime = 30;

  void Start()
  {
    me = this;

    ChefMain.LevelEnded = false;
  
    ChefMain.NumberOfGoodFoodPrepared = 0;
    ChefMain.NumberOfBadFoodPrepared = 0;
    ChefMain.NumberOfFoodThrownOut = 0;

    // Set timer.
    ChefCountdown.StartStopWatch();

    // Start music.
    ChefSoundSystem.PlayTheme();
  }

  void Update()
  {
    
  }
  
  public static void SetScore( int score )
  {
    ScoreKeeper.SetGameStats( 1, score );
  }

  public void endThisLevel()
  {
    ChefSoundSystem.StopTheme();

    returnToMenu();
  }

  public static void StaticEndLevel()
  {
    ChefMain.me.endThisLevel();
  }
  
  public void returnToMenu()
  {
    int score = 0;
   
    int numberOfTotalFoodPrepared = ChefMain.NumberOfGoodFoodPrepared +
                                    ChefMain.NumberOfBadFoodPrepared +
                                    ChefMain.NumberOfFoodThrownOut; 
    if( numberOfTotalFoodPrepared == 0 )
    {
      score = 0;
    }
    else
    {
      float scoreRatio = ChefMain.NumberOfGoodFoodPrepared / numberOfTotalFoodPrepared;
      score = ( int )( scoreRatio * 3 );
    }
    
    ChefMain.SetScore( score );
    Application.LoadLevel( "MenuScene" );
  }
}
