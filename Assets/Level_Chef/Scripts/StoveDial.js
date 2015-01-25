#pragma strict

public class StoveDial extends MonoBehaviour
{
  public var on : boolean = false;

  public var level : float = 0.0f;
  public var minLevel : float = 0.0f;
  public var maxLevel : float = 7.0f;
  public var levelTickIncrement : float = 1.0f;
  
  protected var rotationAngle : float = 0.0;
  protected var dragging : boolean = false;
  protected var dragAnchorPoint : Vector3;
  protected var dragAnchorRotationAngle : float = 0.0f;

  public var stoveElement : StoveElement;

  function Start()
  {
    // Rotate to default angle.
    
    dragAnchorPoint = Vector3.zero;
  }

  function Update()
  {
    
  }
  
  public function OnMouseDown()
  {
    /*on = !on;
    
    // TODO: For the time being, just turn burner on or off.
    
    level = on ? maxLevel : minLevel;
    rotateToLevel( level );
    */
  }
  
  function OnMouseUp()
  {
    //print( "mouse up" );
    dragging = false;
    dragAnchorPoint = Vector3.zero;
    dragAnchorRotationAngle = 0.0f;
  }
  
  function OnMouseDrag()
  {
    //print( "drag'n" );
    
    var curScreenPoint : Vector3 = new Vector3( Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z );
    var curPosition :    Vector3 = Camera.main.ScreenToWorldPoint( curScreenPoint );
    curPosition.z = 0.0f; // NOTE: Weird 2D plane stuff!!!
  
    if( !dragging )
    {
      dragging = true;
      //print( "" + curPosition.x + ":" + curPosition.y + ":" + curPosition.z );
      
      dragAnchorPoint = curPosition;
      dragAnchorRotationAngle = levelToAngle( level );
    }
    
    var dragPointDistanceFromAnchor : Vector3 = curPosition - dragAnchorPoint;
    
    // Drag from dial distance to rotationAngle.
    var totalAngleFromXDrag : float = dragPointDistanceFromAnchor.x / 0.0125f;
    
    // Get new level from dial rotation.
    level = angleToLevel( dragAnchorRotationAngle + totalAngleFromXDrag );
    
    // Restrict user from spinning forever?
    if( level > maxLevel )
    {
      level = maxLevel;
    }
    
    if( level < minLevel )
    {
      level = minLevel;
    }
    
    // Rotate dial with new level.
    rotateToLevel( level );
    
    // Turn on/off burner, potentially.
    on = ( level >= 1.0 ) ? true : false;
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
  
  protected function anglePerTick() : float
  {
    // TODO: Should probably be preprocessed.
  
    var numberOfTicks : int = maxLevel / levelTickIncrement;
    //print( "" + numberOfTicks );
    
    var anglePerTick : float = 360.0f / ( numberOfTicks + 1 );
    //print( "" + anglePerTick );
    
    return anglePerTick;
  }
  
  protected function angleToLevel( inputAngle : float ) : float
  {
    return inputAngle / anglePerTick();
  }
  
  protected function levelToAngle( inputLevel : float ) : float
  {
    return inputLevel * anglePerTick();
  }
}
