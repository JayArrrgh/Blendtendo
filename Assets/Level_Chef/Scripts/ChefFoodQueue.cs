using UnityEngine;
using System.Collections;

public class ChefFoodQueue : ChefFoodReceptacle
{
  public static ChefFoodQueue instance = null;

  public float foodMoveTime = 0.25f;

  void Awake()
  {
    instance = this;
  }

  public override bool addObject( ChefEntity entity )
  {
    // Should only be allowed to add ChefFood.
    ChefFood food = entity as ChefFood;
    if( food == null )
    {
      return false;
    }

    bool status = base.addObject( entity );
    if( !status )
    {
      return false;
    }

    // TODO: Add food as a child of this queue.

    // Initiate process which will move all food in queue.
    setMovingFood( true );

    return true;
  }

  public override bool removeObject( ChefEntity entity )
  {
    // Should only be allowed to add ChefFood.
    ChefFood food = entity as ChefFood;
    if( food == null )
    {
      return false;
    }

    bool status = base.removeObject( food );
    if( status )
    {
      setMovingFood( true );
    }

    return status;
  }

  protected void setMovingFood( bool movingFood )
  {
    ChefEntity entity;

    Vector3 indexPosition = transform.position;

    int numberOfFood = objectList.Count;
    for( int foodIndex = 0; foodIndex < numberOfFood; foodIndex++ )
    {
      entity = objectList[foodIndex] as ChefEntity;
      if( entity == null )
      {
        continue;
      }

      entity.moveToInTime( indexPosition, foodMoveTime );

      // TODO: Better determine this offset (scale by number number of food and width of visible queue?).
      indexPosition.x -= 0.5f;
    }
  }
}
