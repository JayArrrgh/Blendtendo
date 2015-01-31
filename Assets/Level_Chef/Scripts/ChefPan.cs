using UnityEngine;
using System.Collections;

public class ChefPan : ChefFoodReceptacle
{
	public float heatLevel = 0.0f;
  public float appliedHeatLevel = 0.0f;
  
  public GameObject handle;
  
  public float heatResistance = 0.4f;
  
  private bool dragging = false;
  private Vector3 panCenterToDragPointDistance;

  void Start()
  {
    
  }

  void FixedUpdate()
  {
    // Transfer heat slowly.
    if( heatLevel != appliedHeatLevel )
    {
      heatLevel = ChefHeatTransferUtility.caculateNewHeatLevel( heatLevel, appliedHeatLevel, heatResistance );
      
      // Update tint of pot, based on heatLevel.
      SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
      if( spriteRenderer != null )
      {
        spriteRenderer.color = Color.Lerp( Color.white, Color.red, heatLevel / 20.0f );
      }
    }
  
    // TODO: Check if pan has (food) contents.
    //if( false )
    {
      //var food : Food = getFoodContents();
      
      // Apply this pan's heat level to the food.
      //food.applyHeatLevel( heatLevel );
    }
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
      
      if( handle != null )
      {
        //print( "drag with handle" );
      
        panCenterToDragPointDistance = transform.position - curPosition;
      }
    }
    
    transform.position = curPosition + panCenterToDragPointDistance;
  }
  
  void OnTriggerEnter2D( Collider2D other )
  {
    string otherName = other.name;
    if( otherName.Contains( "StoveElement" ) ) // NOTE: This is super sensitive bad coding!
    {
      ChefStoveElement burner = other.GetComponent<ChefStoveElement>();
      if( burner != null )
      {
        print( "Pan entering: " + otherName );
      
        burner.setPan( this );
      }
    }
  }

  void OnTriggerStay2D( Collider2D other )
  {
    string otherName = other.name;
    if( otherName.Contains( "StoveElement" ) ) // NOTE: This is super sensitive bad coding!
    {
      ChefStoveElement burner = other.GetComponent<ChefStoveElement>();
      if( burner != null )
      {
        //print( "Pan staying: " + otherName );

        burner.setPan( this );
      }
    }
  }
  
  void OnTriggerExit2D( Collider2D other )
  {
    string otherName = other.name;
    if( otherName.Contains( "StoveElement" ) ) // NOTE: This is super sensitive bad coding!
    {
      ChefStoveElement burner = other.GetComponent<ChefStoveElement>();
      if( burner != null )
      {
        print( "Pan exiting: " + otherName );

        burner.setPan( null );
      }
    }
  }
  
  public void applyHeatLevel( float newHeatLevel )
  {
    appliedHeatLevel = newHeatLevel;
  }
}
