using UnityEngine;
using System.Collections;

public class ChefStoveElement : ChefEntity
{
	protected bool on = false;
  protected float heatLevel = 0.0f;
  
  public ChefFlame flame;
  
  public ChefPan pan = null;

  void FixedUpdate()
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
  
  public bool setPan( ChefPan pan )
  {
    if( pan == null )
    {
      // Clear this burner's pan in this case.
      this.pan = null;
    }

    // Incoming pan.
    if( this.pan != null )
    {
      // TODO: Do something clever, as there is already a pan here?
      return false;
    }
    
    this.pan = pan;
    
    return true;
  }
}
