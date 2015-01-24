#pragma strict

public class PanAndHandle extends MonoBehaviour
{
  //protected var onBurner : boolean = false;
  protected var burner : StoveElement = null;
  
  public var handle : GameObject;
  
  private var dragging : boolean = false;
  private var panCenterToDragPointDistance : Vector3;

  function Start()
  {
    
  }

  function Update()
  {
    
  }
  
  function setBurner( newBurner : StoveElement ) : boolean
  {
    
  }
  
  function OnMouseDown()
  {
    //print( "mouse down" );
  }
  
  function OnMouseUp()
  {
    //print( "mouse up" );
    dragging = false;
    panCenterToDragPointDistance = Vector3.zero;
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
      
      if( handle != null )
      {
        //print( "drag with handle" );
      
        panCenterToDragPointDistance = transform.position - curPosition;
      }
    }
    
    transform.position = curPosition + panCenterToDragPointDistance;
  }
}
