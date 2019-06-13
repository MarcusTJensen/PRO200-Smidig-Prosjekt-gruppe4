using UnityEngine;

public class OnLookController : MonoBehaviour{

	private Camera cam;
	private GameObject objLookedAt;
	private ElementAction targetElement;

	private void Awake(){
		cam = GetComponent<Camera>();
	}

	//Shoot ray/laser from center of camera to detect objects in front of where the player is looking
	private void Update(){
		
		Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 50f)){
			if(objLookedAt != hit.transform.gameObject){
				objLookedAt = hit.transform.gameObject;
				targetElement = objLookedAt.GetComponent<ElementAction>();
			}
			targetElement.Progress();
		} else{
			if (targetElement != null)
				targetElement.Reset();
			objLookedAt = null;
			targetElement = null;
		}
	}
	
	
}
