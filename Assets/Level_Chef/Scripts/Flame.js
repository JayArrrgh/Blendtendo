#pragma strict

public class Flame extends MonoBehaviour
{
  protected var on : boolean = false;
  protected var heatLevel : float = 0.0f;

  function Start()
  {
    turnOn( on );
  }

  function Update()
  {
    // Check if flame is on.
    /*if( !on )
    {
      return;
    }*/
    
    //print( "flame on" );
    
    // If so, acquire the parent burner.
    var parentTransform : Transform = transform.parent;
    var parentGameObject = parentTransform.gameObject;
    var burner : StoveElement = parentGameObject.GetComponent( StoveElement );
    if( burner != null )
    {
      //print( "burner not null" );
    
      // From the burner, acquire a pan, if present.
      var pan : Pan = burner.getPan();
      if( pan != null )
      {
        // If pan is present, heat it up.
        pan.applyHeatLevel( heatLevel );
      }
    }
  }
  
  public function turnOn( newOn : boolean )
  {
    on = newOn;
    
    // Turn on flame, vice versa.
    renderer.enabled = newOn;
  }
  
  public function setHeatLevel( newHeatLevel : float )
  {
    heatLevel = newHeatLevel;
    
    // Adjust size (radius) of flame.
  }
}
