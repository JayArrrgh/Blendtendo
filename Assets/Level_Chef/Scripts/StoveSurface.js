#pragma strict

public class StoveSurface extends MonoBehaviour
{
  public static var reference : StoveSurface;

  protected var on : boolean = false;
  protected var level : float = 0.0f;
  
  public var burners : StoveElement[];

  function Start()
  {
    reference = this;
  
    getBurners( burners );
  }

  function Update()
  {
    
  }
  
  public function getBurners( burners : StoveElement[] ) : boolean
  {
    //var renderers:MeshRenderer[] = go.GetComponentsInChildren(MeshRenderer) as MeshRenderer[];
    burners = GetComponentsInChildren( StoveElement ) as StoveElement[];
    if( burners.Length < 1 )
    {
      return false;
    }
    
    return true;
  }
}
