using UnityEngine;
using System.Collections;

public class ChefStoveElement : ChefEntity
{
	protected bool on = false;
  protected float heatLevel = 0.0f;
  
  public ChefFlame flame;
  
  protected ChefPan pan = null;

  void Update()
  {
    turnOn( on );
    if( flame != null )
    {
      flame.setHeatLevel( heatLevel );
    }
  }
  
  public void turnOn( bool newOn )
  {
    on = newOn;
    
    // Turn on flame, vice versa.
    if( flame != null )
    {
      flame.turnOn( newOn );
    }
  }
  
  public void setHeatLevel( float newHeatLevel )
  {
    heatLevel = newHeatLevel;
    
    if( flame != null )
    {
      flame.setHeatLevel( heatLevel );
    }
  }
  
  public ChefPan getPan()
  {
    return pan;
  }
  
  public bool setPan( ChefPan newPan )
  {
    if( pan != null )
    {
      // TODO: Do something clever, as there is already a pan here?
      return false;
    }
    
    pan = newPan;
    
    return true;
  }
}
