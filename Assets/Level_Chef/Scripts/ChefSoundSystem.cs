using UnityEngine;
using System.Collections;

public class ChefSoundSystem : MonoBehaviour
{
  public static ChefSoundSystem instance = null;

  protected AudioSource themeMusic = null;

	void Awake()
  {
    instance = this;

    GameObject themeMusicGameObject = GameObject.Find( "Theme Music" );
    if( themeMusicGameObject != null )
    {
      themeMusic = themeMusicGameObject.GetComponent<AudioSource>();
    }
	}

  public bool playTheme( bool play )
  {
    if( instance.themeMusic == null )
    {
      return false;
    }

    if( play )
    {
      instance.themeMusic.Play();
    }
    else
    {
      instance.themeMusic.Stop();
    }

    return true;
  }

  public static bool PlayTheme()
  {
    if( instance == null )
    {
      return false;
    }

    return instance.playTheme( true );
  }

  public static bool StopTheme()
  {
    if( instance == null )
    {
      return false;
    }

    return instance.playTheme( false );
  }
}
