#pragma strict

public class PanHandle extends MonoBehaviour
{
  //protected var onBurner : boolean = false;
  protected var burner : StoveElement = null;
  
  public var pan : Pan;
  
  private var dragging : boolean = false;
  private var panCenterToDragPointDistance : Vector3;

  function Start()
  {
    var parentTransform : Transform = transform.parent;
    var parentGameObject = parentTransform.gameObject;
    pan = parentGameObject.GetComponent( Pan );
    if( pan != null )
    {
      //print( "we have pan" );
    }
  }

  function Update()
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
      
      if( pan != null )
      {
        //print( "drag with handle" );
      
        panCenterToDragPointDistance = pan.transform.position - curPosition;
      }
    }
    
    if( pan != null )
    {
      pan.transform.position = curPosition + panCenterToDragPointDistance;
    }
  }
  
  public function associateBurnerWithPan()
  {
    // Iterate through all the burners and determine if there is overlap of 1 burner.
    if( StoveSurface.reference == null )
    {
      return;
    }
    
    var burners : StoveElement[];
    StoveSurface.reference.getBurners( burners );
    
    // If so,
    // - associate burner with pan.
    // - 

    // TODO: Orient pan a handle?
  }
}
