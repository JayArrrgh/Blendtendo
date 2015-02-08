using UnityEngine;
using System.Collections;

public class ChefFood : ChefEntity
{
  public static float CookedLevelRaw        = 0.0f;
  public static float CookedLevelCooked     = 0.5f;
  public static float CookedLevelOverCooked = 0.7f;
  public static float CookedLevelBurnt      = 1.0f;

	public float heatLevel = 0.0f;
  public float appliedHeatLevel = 0.0f;
  
  public float cookedLevel = 0.0f;
  public float heatResistance = 0.4f;
  
  public bool dragging = false;
  public ChefFoodReceptacle intendedParent;
  
  protected Vector3 originPosition;

  protected AudioSource cookingSound;

  void Awake()
  {
    cookingSound = GetComponentInChildren<AudioSource>();

    originPosition = transform.position;
  
    reset();
  }

  void FixedUpdate()
  {
    move();

    // Transfer heat slowly.
    if( heatLevel != appliedHeatLevel )
    {
      float previousHeatLevel = heatLevel;

      heatLevel = ChefHeatTransferUtility.caculateNewHeatLevel( heatLevel, appliedHeatLevel, heatResistance );

      if( cookingSound != null )
      {
        if( heatLevel == 0.0f )
        {
          cookingSound.Stop();
        }
        else
        {
          cookingSound.volume = heatLevel / 10.0f;

          if( previousHeatLevel == 0.0f )
          {
            cookingSound.Play();
          }
        }
      }
      
    }

    if( heatLevel > 0.0f )
    {
      cookedLevel += 0.0001f * heatLevel / heatResistance;
      if( cookedLevel >= 1.0f )
      {
        cookedLevel = 1.0f;
      }

      // Update tint of pot, based on heatLevel.
      SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
      if( spriteRenderer != null )
      {
        if( cookedLevel < ChefFood.CookedLevelCooked )
        {
          spriteRenderer.color = Color.Lerp( Color.white, Color.red,
                                             ( cookedLevel - ChefFood.CookedLevelRaw ) / ( ChefFood.CookedLevelCooked - ChefFood.CookedLevelRaw ) );
        }
        else
        if( cookedLevel <= ChefFood.CookedLevelBurnt )
        {
          spriteRenderer.color = Color.Lerp( Color.red, Color.black,
                                             ( cookedLevel - ChefFood.CookedLevelCooked ) / ( ChefFood.CookedLevelBurnt - ChefFood.CookedLevelCooked ) );
        }
      }
    }
  }
  
  public void reset()
  {
    heatLevel = 0.0f;
    appliedHeatLevel = 0.0f;
    cookedLevel = 0.0f;

    intendedParent = null;

    SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    if( spriteRenderer != null )
    {
      spriteRenderer.color = Color.white;
    }
    
    transform.position = originPosition;

    if( cookingSound != null )
    { 
      cookingSound.Stop();
    }

    ChefFoodQueue.instance.addObject( this );
  }

  /*void OnMouseDown()
  {
    print( "mouse down" );
  }*/
  
  void OnMouseUp()
  {
    //print( "mouse up" );
    dragging = false;

    if( intendedParent != null )
    {
      // Drop this food into this receptacle.
      intendedParent.addObject( this );
      intendedParent = null;
    }

    if( parent == null )
    {
      // Food wasn't put anywhere it could (or should) go.
      returnToPreviousParent();
    }
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
      
      if( parent != null )
      {
        // Move food from its parent.
        parent.removeObject( this );
      }
    }
    
    transform.position = curPosition;
  }
  
  void OnTriggerStay2D( Collider2D other )
  {
    if( !dragging )
    {
      return;
    }

    // Put food in container.
    ChefFoodReceptacle foodReceptacle = other.GetComponent<ChefFoodReceptacle>();
    if( foodReceptacle != null )
    {
      if( foodReceptacle == parent )
      {
        // This food receptacle is already this food's parent.
        return;
      }

      intendedParent = foodReceptacle;
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

        appliedHeatLevel = 0.0f;
        return;
      }
    }
  }

  public void returnToPreviousParent()
  {
    // Return food to pan to its previous parent.
    // If no previous parent, put the food in the food queue.
    ChefEntity newParent = ( previousParent != null ) ? previousParent : ChefFoodQueue.instance;
    if( newParent != null )
    {
      newParent.addObject( this );
    }
  }

  public void applyHeatLevel( float newHeatLevel )
  {
    appliedHeatLevel = newHeatLevel;
  }
}
