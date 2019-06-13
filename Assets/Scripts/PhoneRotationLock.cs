using UnityEngine;

public class PhoneRotationLock : MonoBehaviour{
	
	
	
	
	private void Awake(){
		DontDestroyOnLoad(gameObject);
		DisableLandscape();
	}

	public void DisableLandscape(){
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = true;
	}
	
	public void EnableLandscape(){
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;
		Screen.autorotateToPortrait = false;
		Screen.autorotateToPortraitUpsideDown = false;
	}
	
	
}
