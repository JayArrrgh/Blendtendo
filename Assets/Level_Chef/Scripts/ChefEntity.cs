using UnityEngine;
using System.Collections;

public class ChefEntity : MonoBehaviour
{
	public ArrayList objectList;

  public ChefEntity()
  {
    objectList = new ArrayList();
    clearObjects();
  }

  public virtual bool addObject( ChefEntity entity )
  {
    objectList.Add( entity );
    return true;
  }

  public virtual bool removeObject( ChefEntity entity )
  {
    objectList.Remove( entity );
    return true;
  }

  public virtual void clearObjects()
  {
    objectList.Clear();
  }

  public bool hasObjects()
  {
    return objectList.Count > 0;
  }
}
