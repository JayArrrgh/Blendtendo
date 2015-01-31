using UnityEngine;
using System.Collections;

public class ChefMain : MonoBehaviour
{
	public static ChefMain me = null;

  public static int NumberOfGoodFoodPrepared = 0;
  public static int NumberOfBadFoodPrepared = 0;
  public static int NumberOfFoodThrownOut = 0;
  
  public static float totalTime = 30;
  public static float timeLeft = 0;
  
  public AudioClip musicClip;

  void Start()
  {
    me = this;
  
    ChefMain.NumberOfGoodFoodPrepared = 0;
    ChefMain.NumberOfBadFoodPrepared = 0;
    ChefMain.NumberOfFoodThrownOut = 0;

    // Set timer.
    timeLeft = totalTime;

    // Start music.
    if( musicClip != null )
    {
      AudioSource.PlayClipAtPoint( musicClip, transform.position );
    }
  }

  void Update()
  {
    
  }
  
  public static void SetScore( int score )
  {
    ScoreKeeper.SetGameStats( 1, score );
  }
  
  public void ReturnToMenu()
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
