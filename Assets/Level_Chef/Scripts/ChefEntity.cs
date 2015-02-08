using UnityEngine;
using System.Collections;

public class ChefEntity : MonoBehaviour
{
	public ArrayList objectList;
  public ChefEntity parent;
  public ChefEntity previousParent;

  public bool moving;
  public Vector3 beginPosition;
  public Vector3 destination;
  protected float moveBeginTime;
  protected float moveEndTime;
  protected float moveTime;

  protected bool movingFood = false;

  public ChefEntity()
  {
    parent = null;
    previousParent = null;

    objectList = new ArrayList();
    clearObjects();

    moving = false;
  }

  public virtual bool addObject( ChefEntity entity )
  {
    if( objectList.Contains( entity ) )
    {
      // TODO: Should this entity be moved the end of the list?
      return true;
    }
    else
    {
      ChefEntity entityParent = entity.parent;
      if( entityParent != null )
      {
        entityParent.removeObject( entity );
      }
    }

    entity.previousParent = entity.parent;
    entity.parent = this;
    objectList.Add( entity );

    return true;
  }

  public virtual bool removeObject( ChefEntity entity )
  {
    if( entity.parent == this )
    {
      entity.previousParent = this;
      entity.parent = null;
    }

    objectList.Remove( entity );
    return true;
  }

  public virtual void clearObjects()
  {
    int numberOfObjects = objectList.Count;
    if( numberOfObjects < 1 )
    {
      return;
    }

    ChefEntity entity;
    for( int index = numberOfObjects - 1; index > -1; index-- )
    {
      entity = objectList[index] as ChefEntity;
      if( entity != null )
      {
        entity.previousParent = this;
        entity.parent = null;
      }
    }

    objectList.Clear();
  }

  public bool hasObjects()
  {
    return objectList.Count > 0;
  }

  public bool moveToInTime( Vector3 destination, float duration )
  {
    beginPosition = transform.position;
    this.destination = destination;

    moveTime = duration;
    moveBeginTime = Time.time;
    moveEndTime = moveBeginTime + moveTime;

    this.moving = true;

    return true;
  }

  public bool move()
  {
    if( !moving )
    {
      return false;
    }

    float lerpT = ( Time.time - moveBeginTime ) / moveTime;
    if( lerpT >= 1.0f )
    {
      lerpT = 1.0f;
      moving = false;
    }

    transform.position = Vector3.Lerp( beginPosition, destination, lerpT );

    return true;
  }
}
