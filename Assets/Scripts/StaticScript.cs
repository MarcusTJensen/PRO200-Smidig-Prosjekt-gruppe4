using UnityEngine;

public class StaticScript : MonoBehaviour {



	public static float playerRotation;
	public static bool comingFromSettings;

	// Just a static script to keep some values between scenes.
	// This is also the object that holds the music objects, this way it will continue
	//   playing and not stop when loading new scenes.
	private void Awake(){
		DontDestroyOnLoad(gameObject);
	}
}
