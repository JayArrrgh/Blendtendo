#pragma strict

public class HeatTransferUtility extends MonoBehaviour
{
  public static var minHeatLevel : float = 0.0f;
  public static var maxHeadLevel : float = 10.0f;
  public static var heatSlowdownWeight : float = 0.5f;

  public static function caculateNewHeatLevel( heatLevel : float, appliedHeatLevel : float, heatResistance : float ) : float
  {
    if( heatLevel == appliedHeatLevel )
    {
      return heatLevel;
    }
  
    var heatIncrement : float = heatResistance / 40.0f;
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
