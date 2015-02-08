using UnityEngine;
using System.Collections;

public class ChefMain : MonoBehaviour
{
	public static ChefMain me = null;

  public static bool LevelEnded = false;

  public static int NumberOfGoodFoodPrepared = 0;
  public static int NumberOfBadFoodPrepared = 0;
  public static int NumberOfFoodThrownOut = 0;

  public GameObject foodPrefab = null;
  
  //public static float totalTime = 30;
  public double nextSpawnFoodTime = 0.0;
  public double spawnFoodTimeInterval = 10.0;

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
    bool releaseNewPieceOfFood = false;

    double totalSeconds = ChefCountdown.GetTotalSeconds();
    if( totalSeconds >= nextSpawnFoodTime )
    {
      // Every so many seconds, release a new piece of food.
      releaseNewPieceOfFood = true;

      nextSpawnFoodTime = totalSeconds + spawnFoodTimeInterval;
    }

    if( Input.GetKeyDown( KeyCode.Space ) )
    {
      // If player presses Space key, release a new piece of food.
      releaseNewPieceOfFood = true;
    }

    if( releaseNewPieceOfFood )
    {
      GameObject newObject = GameObject.Instantiate( foodPrefab ) as GameObject;
      if( newObject != null )
      {
        ChefFood newFood = newObject.GetComponent<ChefFood>();
        if( newFood != null )
        {
          ChefFoodQueue.instance.addObject( newFood );
        }
      }
    }
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
