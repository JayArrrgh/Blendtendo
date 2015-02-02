using UnityEngine;
using System.Collections;

public class ChefPan : ChefFoodReceptacle
{
	public float heatLevel = 0.0f;
  public float appliedHeatLevel = 0.0f;
  
  public float heatResistance = 0.4f;
  
  public bool dragging = false;

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
  
    if( hasObjects() )
    {
      for( int i = 0; i < objectList.Count; i++ )
      {
        ChefEntity entity = objectList[i] as ChefEntity;
        if( entity != null )
        {
          ChefFood food = entity as ChefFood;
          if( food != null )
          {
            // Apply this pan's heat level to the food.
            food.applyHeatLevel( heatLevel );
          }
        }
      }

    }
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

  public override bool addObject( ChefEntity entity )
  {
    // Should only be allowed to add ChefFood.
    ChefFood food = entity as ChefFood;
    if( food == null )
    {
      return false;
    }

    if( hasObjects() )
    {
      // NOTE: Only one piece of food allowed at the moment.
      return false;
    }

    return base.addObject( entity );
  }
}
