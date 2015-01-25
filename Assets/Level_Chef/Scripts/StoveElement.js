#pragma strict

public class StoveElement extends MonoBehaviour
{
  protected var on : boolean = false;
  protected var heatLevel : float = 0.0f;
  
  public var flame : Flame;
  
  protected var pan : Pan = null;

  function Update()
  {
    turnOn( on );
    if( flame != null )
    {
      flame.setHeatLevel( heatLevel );
    }
  }
  
  public function turnOn( newOn : boolean )
  {
    on = newOn;
    
    // Turn on flame, vice versa.
    if( flame != null )
    {
      flame.turnOn( newOn );
    }
  }
  
  public function setHeatLevel( newHeatLevel : float )
  {
    heatLevel = newHeatLevel;
    
    if( flame != null )
    {
      flame.setHeatLevel( heatLevel );
    }
  }
  
  public function getPan() : Pan
  {
    return pan;
  }
  
  public function setPan( newPan : Pan ) : boolean
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
