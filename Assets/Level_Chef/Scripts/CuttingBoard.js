#pragma strict

public class CuttingBoard extends MonoBehaviour
{
  function Start()
  {
    // Move chicken back to initial point.
    //food.reset();
  }

  function Update()
  {
    
  }
  
  function OnTriggerEnter2D( other: Collider2D )
  {
    var otherName : String = other.name;
    if( otherName.Contains( "Chicken" ) ) // NOTE: This is super sensitive bad coding!
    {
      print( otherName );
      var food : Food = other.GetComponent( Food );
      if( food != null )
      {
        // Determine if food is raw, cooked, or overcooked.
        // Update user score.
        if( food.cookedLevel < 0.5 || food.cookedLevel > 1.0 )
        {
          Main.NumberOfBadFoodPrepared++;
        }
        else
        {
          Main.NumberOfGoodFoodPrepared++;
        }
      }
    }
  }
  
  function OnTriggerExit2D( other : Collider2D )
  {
    //associate( null );
  }
}
