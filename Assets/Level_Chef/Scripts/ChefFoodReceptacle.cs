using UnityEngine;
using System.Collections;

public class ChefFoodReceptacle : ChefEntity
{
  public override bool addObject( ChefEntity entity )
  {
    // Should only be allowed to add ChefFood.
    ChefFood food = entity as ChefFood;
    if( food == null )
    {
      return false;
    }

    return base.addObject( food );
  }
}
