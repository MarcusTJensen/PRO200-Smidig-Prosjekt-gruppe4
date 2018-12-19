using UnityEngine;

public class PhoneRotationLock : MonoBehaviour{
	private void Start(){
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
	}
}
