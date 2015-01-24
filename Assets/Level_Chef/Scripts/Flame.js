#pragma strict

public class Flame extends MonoBehaviour
{
  protected var on : boolean = false;
  protected var level : float = 0.0f;

  function Start()
  {
    turnOn( on );
  }

  function Update()
  {
    
  }
  
  public function turnOn( newOn : boolean )
  {
    on = newOn;
    
    // Turn on flame, vice versa.
    renderer.enabled = newOn;
  }
  
  public function setLevel( newLevel : float )
  {
    level = newLevel;
    
    // Adjust size (radius) of flame.
  }
}
