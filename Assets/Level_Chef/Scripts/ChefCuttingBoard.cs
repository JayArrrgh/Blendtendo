using UnityEngine;
using System.Collections;

public class ChefCuttingBoard : MonoBehaviour
{
	void Start()
  {
    // Move chicken back to initial point.
    //food.reset();
  }

  void Update()
  {
    
  }
  
  void OnTriggerEnter2D( Collider2D other )
  {
    string otherName = other.name;
    if( otherName.Contains( "Chicken" ) ) // NOTE: This is super sensitive bad coding!
    {
      print( otherName );
      ChefFood food = other.GetComponent<ChefFood>();
      if( food != null )
      {
        // Determine if food is raw, cooked, or overcooked.
        // Update user score.
        if( food.cookedLevel < 0.5 || food.cookedLevel > 1.0 )
        {
          ChefMain.NumberOfBadFoodPrepared++;
        }
        else
        {
          ChefMain.NumberOfGoodFoodPrepared++;
        }
      }
    }
  }

  void OnTriggerExit2D( Collider2D other )
  {
    //associate( null );
  }
}
