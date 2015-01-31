using UnityEngine;
using System.Collections;

public class ChefPanHandle : MonoBehaviour
{
  protected ChefPan pan;

  protected bool dragging = false;
  private Vector3 panCenterToDragPointDistance;

	void Start()
  {
    Transform parentTransform = transform.parent;
    GameObject parentGameObject = parentTransform.gameObject;
    pan = parentGameObject.GetComponent<ChefPan>();
	}
	
	void FixedUpdate()
  {
	
	}

  void OnMouseDown()
  {
    //print( "mouse down" );
  }

  void OnMouseUp()
  {
    //print( "mouse up" );
    dragging = false;
    panCenterToDragPointDistance = Vector3.zero;
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

      if( pan != null )
      {
        //print( "drag with handle" );

        panCenterToDragPointDistance = pan.transform.position - curPosition;
      }
    }

    pan.transform.position = curPosition + panCenterToDragPointDistance;
  }
}
