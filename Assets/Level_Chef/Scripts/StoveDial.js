#pragma strict

public class StoveDial extends MonoBehaviour
{
  public var on : boolean = false;

  public var level : float = 0.0f;
  public var minLevel : float = 0.0f;
  public var maxLevel : float = 7.0f;
  public var levelTickIncrement : float = 1.0f;
  
  protected var rotationAngle : float = 0.0;

  public var stoveElement : StoveElement;

  function Start()
  {
  
    // Rotate to default angle.
    
  }

  function Update()
  {
    
  }
  
  public function OnMouseDown()
  {
    on = !on;
    
    // TODO: For the time being, just turn burner on or off.
    level = on ? maxLevel : minLevel;
    rotateToLevel( level );
    
    // Turn on/off burner.
    if( stoveElement != null )
    {
      stoveElement.turnOn( on );
      
      // Level to heat level.
      var heatLevel : float = level / maxLevel * 10.0f;
      stoveElement.setHeatLevel( heatLevel );
    }
  }
  
  public function rotateToLevel( newLevel : float )
  {
    // TODO: Rotate dial to max level tick.
    transform.rotation = Quaternion.identity;
    
    // Set new angle.
    var angle : float = levelToAngle( newLevel );
    //print( "Level/Angle" + newLevel + ":" + angle );
    
    transform.eulerAngles = Vector3( 0.0f, 0.0f, -angle );
  }
  
  protected function levelToAngle( inputLevel : float ) : float
  {
    var numberOfTicks : int = maxLevel / levelTickIncrement;
    //print( "" + numberOfTicks );
    
    var anglePerTick : float = 360.0f / ( numberOfTicks + 1 );
    //print( "" + anglePerTick );
  
    var angle : float = inputLevel * anglePerTick;
    
    return angle;
  }
}
