using UnityEngine;
using System.Collections;

public class ChefHeatTransferUtility : MonoBehaviour
{
	public static float minHeatLevel = 0.0f;
  public static float maxHeadLevel = 10.0f;
  public static float heatSlowdownWeight = 0.5f;

  public static float caculateNewHeatLevel( float heatLevel, float appliedHeatLevel, float heatResistance )
  {
    if( heatLevel == appliedHeatLevel )
    {
      return heatLevel;
    }
  
    float heatIncrement = heatResistance / 1.0f;
    if( heatLevel < appliedHeatLevel )
    {
      heatLevel += heatIncrement;
    }
    else
    {
      heatLevel -= heatIncrement * heatSlowdownWeight;
    }
    
    if( heatLevel < minHeatLevel )
    {
      heatLevel = minHeatLevel;
    }
    else
    if( heatLevel > maxHeadLevel )
    {
      heatLevel = maxHeadLevel;
    }
    
    return heatLevel;
  }
}
