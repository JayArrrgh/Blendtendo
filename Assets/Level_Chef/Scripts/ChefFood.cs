using UnityEngine;
using System.Collections;

public class ChefFood : ChefEntity
{
	public float heatLevel = 0.0f;
  public float appliedHeatLevel = 0.0f;
  
  public float cookedLevel = 0.0f;
  public float heatResistance = 0.4f;
  
  public bool dragging = false;
  
  protected Vector3 originPosition;
  
  public ChefCuttingBoard cuttingBoard = null;
  public ChefPan pan = null;

  void Start()
  {
    originPosition = transform.position;
  
    reset();
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
        spriteRenderer.color = Color.Lerp( Color.white, Color.black, cookedLevel );
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
  
  public void reset()
  {
    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if( spriteRenderer != null )
    {
      spriteRenderer.color = Color.white;
    }
    
    transform.position = originPosition;
  }
  
  void OnMouseUp()
  {
    //print( "mouse up" );
    dragging = false;
    //panCenterToDragPointDistance = Vector3.zero;
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
    }
    
    transform.position = curPosition;
  }
  
  /*void OnTriggerEnter2D( Collider2D other )
  {
    string otherName = other.name;
    if( otherName.Contains( "Pan" ) && !otherName.Contains( "PanHandle" ) ) // NOTE: This is super sensitive bad coding!
    {
      //print( otherName );
      ChefPan curPan = other.GetComponent<ChefPan>();
      if( curPan != null )
      {
        //curPan.associateFoodWithPan( curPan );
      }
    }
  }*/
  
  void OnTriggerStay2D( Collider2D other )
  {
    if( !dragging )
    {
      // Put food in container.
      ChefFoodReceptacle foodReceptacle = other.GetComponent<ChefFoodReceptacle>();
      if( foodReceptacle != null )
      { 
        ChefPan pan = foodReceptacle as ChefPan;
        if( pan != null )
        { 
          if( pan.addObject( this ) )
          {
            // Reposition food to center of pan.
            transform.position = pan.transform.position;
          }
          return;
        }

        foodReceptacle.addObject( this );

        return;
      }
    }
  }
  
  void OnTriggerExit2D( Collider2D other )
  {
    string otherName = other.name;
    if( otherName.Contains( "Pan" ) && !otherName.Contains( "PanHandle" ) ) // NOTE: This is super sensitive bad coding!
    {
      ChefFoodReceptacle foodReceptacle = other.GetComponent<ChefFoodReceptacle>();
      if( foodReceptacle != null )
      {
        foodReceptacle.removeObject( this );
        return;
      }
    }
  }

  public void applyHeatLevel( float newHeatLevel )
  {
    appliedHeatLevel = newHeatLevel;
  }
}
