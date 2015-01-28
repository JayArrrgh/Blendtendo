using UnityEngine;
using System.Collections;

public class ChefFlame : MonoBehaviour
{
	protected bool on = false;
  protected float heatLevel = 0.0f;
  
  public float minScale = 0.0f;
  public float maxScale = 0.5f;
  
  public float maxHeatLevel = 10.0f;

  void Start()
  {
    turnOn( on );
  }

  void Update()
  {
    // Check if flame is on.
    /*if( !on )
    {
      return;
    }*/
    
    //print( "flame on" );
    
    // If so, acquire the parent burner.
    Transform parentTransform = transform.parent;
    GameObject parentGameObject = parentTransform.gameObject;
    ChefStoveElement burner = parentGameObject.GetComponent<ChefStoveElement>();
    if( burner != null )
    {
      //print( "burner not null" );
    
      // From the burner, acquire a pan, if present.
      ChefPan pan = burner.getPan();
      if( pan != null )
      {
        // If pan is present, heat it up.
        pan.applyHeatLevel( heatLevel );
      }
    }
  }
  
  public void turnOn( bool newOn )
  {
    on = newOn;
    
    // Turn on flame, vice versa.
    renderer.enabled = newOn;
  }
  
  public void setHeatLevel( float newHeatLevel )
  {
    heatLevel = newHeatLevel;
    
    // Adjust size (radius) of flame.
    float heatLevelRatio = heatLevel / maxHeatLevel;
    float scaleFactor = Mathf.Lerp( minScale, maxScale, heatLevelRatio );
    transform.localScale = new Vector3( scaleFactor, scaleFactor, 0 );
  }
}
