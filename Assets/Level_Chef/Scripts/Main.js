#pragma strict

public class Main extends MonoBehaviour
{
  public static var me : Main = null;

  public static var NumberOfGoodFoodPrepared : int = 0;
  public static var NumberOfBadFoodPrepared : int = 0;
  
  public static var totalTime : float = 30;
  public static var timeLeft : float = 0;
  
  public var musicClip : AudioClip;

  function Start()
  {
    me = this;
  
    Main.NumberOfGoodFoodPrepared = 0;
    Main.NumberOfBadFoodPrepared = 0;
    
    // Set timer.
    timeLeft = totalTime;
    
    // Start music.
    if( musicClip != null )
    {
      AudioSource.PlayClipAtPoint( musicClip, transform.position );
    }
  }

  function Update()
  {
    
  }
  
  public static function SetScore( score : int )
  {
    //ScoreKeeper.SetGameStats( 1, score );
    
    // Damn, pulled this from ScoreKeeper::SetScore, because I suck and Unity Technologies suck.
//    var isPlayed : String = Application.loadedLevelName + "_Played";
//    var hasScore : String = Application.loadedLevelName + "_Score";
//
//    PlayerPrefs.SetInt(isPlayed, 1);
//    PlayerPrefs.SetInt(hasScore, score);
//    PlayerPrefs.Save();
  }
  
  public function ReturnToMenu()
  {
    var score : int = 0;
   
    var numberOfTotalFoodPrepared : int =
      Main.NumberOfGoodFoodPrepared + Main.NumberOfBadFoodPrepared; 
    if( numberOfTotalFoodPrepared == 0 )
    {
      score = 0;
    }
    else
    {
      var scoreRatio : float = Main.NumberOfGoodFoodPrepared / numberOfTotalFoodPrepared;
      score = scoreRatio * 3;
    }
    
    Main.SetScore( score );
    Application.LoadLevel( "MenuScene" );
  }
  
}
