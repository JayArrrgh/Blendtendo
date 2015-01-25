#pragma strict

public class Food extends MonoBehaviour
{
  public var heatLevel : float = 0.0f;
  public var appliedHeatLevel : float = 0.0f;
  
  public var cookedLevel : float = 0.0f;
  public var heatResistance : float = 0.4f;
  
  public var dragging : boolean = false;
  
  protected var originPosition : Vector3;
  
  public var cuttingBoard : CuttingBoard = null;
  public var pan : Pan = null;

  function Start()
  {
    originPosition = transform.position;
  
    reset();
  }

  function Update()
  {
    // Transfer heat slowly.
    if( heatLevel != appliedHeatLevel )
    {
      heatLevel = HeatTransferUtility.caculateNewHeatLevel( heatLevel, appliedHeatLevel, heatResistance );
      
      // Update tint of pot, based on heatLevel.
      var spriteRenderer : SpriteRenderer = GetComponent( SpriteRenderer );
      if( spriteRenderer != null )
      {
        spriteRenderer.color = Color.Lerp( Color.white, Color.black, cookedLevel );
      }
    }
  
    // TODO: Check if pan has (food) contents.
    if( false )
    {
      //var food : Food = getFoodContents();
      
      // Apply this pan's heat level to the food.
      //food.applyHeatLevel( heatLevel );
    }
  }
  
  public function reset()
  {
    var spriteRenderer : SpriteRenderer = GetComponent( SpriteRenderer );
    if( spriteRenderer != null )
    {
      spriteRenderer.color = Color.white;
    }
    
    transform.position = originPosition;
  }
  
  function OnMouseUp()
  {
    //print( "mouse up" );
    dragging = false;
    //panCenterToDragPointDistance = Vector3.zero;
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
    }
    
    transform.position = curPosition;
  }
  
  public function associateBurnerWithPan( newBurner : StoveElement )
  {
    //print( "associate" );
    //burner = newBurner;
    
    if( newBurner != null )
    {
      //newBurner.setPan( this );
    }

    // TODO: Orient pan a handle?
  }
  
  function OnTriggerEnter2D( other: Collider2D )
  {
    var otherName : String = other.name;
    if( otherName.Contains( "Pan" ) && !otherName.Contains( "PanHandle" ) ) // NOTE: This is super sensitive bad coding!
    {
      //print( otherName );
      var curPan : Pan = other.GetComponent( Pan );
      if( curPan != null )
      {
        //curPan.associateFoodWithPan( curPan );
      }
    }
  }
  
  function OnTriggerExit2D( other : Collider2D )
  {
    //associate( null );
  }
  
  public function applyHeatLevel( newHeatLevel : float )
  {
    appliedHeatLevel = newHeatLevel;
  }
}
