using UnityEngine;
using System.Collections;

public class ChefStoveDial : MonoBehaviour
{
	public bool on = false;

  public float level = 0.0f;
  public float minLevel = 0.0f;
  public float maxLevel = 7.0f;
  public float levelTickIncrement = 1.0f;
  
  protected float rotationAngle = 0.0f;
  protected bool dragging = false;
  protected Vector3 dragAnchorPoint;
  protected float dragAnchorRotationAngle = 0.0f;

  public ChefStoveElement stoveElement;

  void Start()
  {
    // Rotate to default angle.
    
    dragAnchorPoint = Vector3.zero;
  }

  void Update()
  {
    
  }
  
  void OnMouseUp()
  {
    //print( "mouse up" );
    dragging = false;
    dragAnchorPoint = Vector3.zero;
    dragAnchorRotationAngle = 0.0f;
  }
  
  void OnMouseDrag()
  {
    //print( "drag'n" );
    
    Vector3 curScreenPoint = new Vector3( Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z );
    Vector3 curPosition = Camera.main.ScreenToWorldPoint( curScreenPoint );
    curPosition.z = 0.0f; // NOTE: Weird 2D plane stuff!!!
  
    if( !dragging )
    {
      dragging = true;
      //print( "" + curPosition.x + ":" + curPosition.y + ":" + curPosition.z );
      
      dragAnchorPoint = curPosition;
      dragAnchorRotationAngle = levelToAngle( level );
    }
    
    Vector3 dragPointDistanceFromAnchor = curPosition - dragAnchorPoint;
    
    // Drag from dial distance to rotationAngle.
    float totalAngleFromXDrag = dragPointDistanceFromAnchor.x / 0.0125f;
    
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
      float heatLevel = level / maxLevel * 10.0f;
      stoveElement.setHeatLevel( heatLevel );
    }
  }
  
  public void rotateToLevel( float newLevel )
  {
    // TODO: Rotate dial to max level tick.
    transform.rotation = Quaternion.identity;
    
    // Set new angle.
    float angle = levelToAngle( newLevel );
    //print( "Level/Angle" + newLevel + ":" + angle );
    
    transform.eulerAngles = new Vector3( 0.0f, 0.0f, -angle );
  }
  
  protected float anglePerTick()
  {
    // TODO: Should probably be preprocessed.
  
    int numberOfTicks = ( int )( maxLevel / levelTickIncrement );
    //print( "" + numberOfTicks );
    
    float anglePerTick = 360.0f / ( numberOfTicks + 1 );
    //print( "" + anglePerTick );
    
    return anglePerTick;
  }
  
  protected float angleToLevel( float inputAngle )
  {
    return inputAngle / anglePerTick();
  }
  
  protected float levelToAngle( float inputLevel )
  {
    return inputLevel * anglePerTick();
  }
}
