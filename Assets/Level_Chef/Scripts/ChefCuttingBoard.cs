using UnityEngine;
using System.Collections;

public class ChefCuttingBoard : ChefFoodReceptacle
{
  public override bool addObject( ChefEntity entity )
  {
    // Should only be allowed to add ChefFood.
    ChefFood food = entity as ChefFood;
    if( food == null )
    {
      return false;
    }

    // Determine if food is raw, cooked, or overcooked.
    // Update user score.
    if( food.cookedLevel < ChefFood.CookedLevelCooked ||
        food.cookedLevel >= ChefFood.CookedLevelOverCooked )
    {
      ChefMain.NumberOfBadFoodPrepared++;
      print( "Bad food prepared." );
    }
    else
    {
      ChefMain.NumberOfGoodFoodPrepared++;
      print( "Good food prepared." );
    }

    clearObjects();
    food.reset();

    return true;
  }
}
