#pragma strict

public class StoveElement extends MonoBehaviour
{
  protected var on : boolean = false;
  protected var level : float = 0.0f;
  
  public var flame : Flame;

  function Update()
  {
    turnOn( on );
    if( flame != null )
    {
      flame.setLevel( level );
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
  
  public function setLevel( newLevel : float )
  {
    level = newLevel;
    
    // Adjust size (radius) of flame.
    if( flame != null )
    {
      flame.setLevel( newLevel );
    }
  }
}
