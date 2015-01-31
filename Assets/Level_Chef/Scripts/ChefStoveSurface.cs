using UnityEngine;
using System.Collections;

public class ChefStoveSurface : ChefEntity
{
	public static ChefStoveSurface reference;

  protected bool on = false;
  protected float level = 0.0f;
  
  public ChefStoveElement[] burners;

  void Start()
  {
    reference = this;
  
    getBurners( burners );
  }
  
  public bool getBurners( ChefStoveElement[] burners )
  {
    //var renderers:MeshRenderer[] = go.GetComponentsInChildren(MeshRenderer) as MeshRenderer[];
    burners = GetComponentsInChildren<ChefStoveElement>();
    if( burners.Length < 1 )
    {
      return false;
    }
    
    return true;
  }
}
