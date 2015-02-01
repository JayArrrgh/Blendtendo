using UnityEngine;
using System.Collections;

public class ChefTrashCan : ChefFoodReceptacle
{
  public override bool addObject( ChefEntity entity )
  {
    // Should only be allowed to add ChefFood.
    ChefFood food = entity as ChefFood;
    if( food == null )
    {
      return false;
    }

    ChefMain.NumberOfFoodThrownOut++;
    print( "Food thrown out." );

    clearObjects();
    food.reset();

    return true;
  }
}
