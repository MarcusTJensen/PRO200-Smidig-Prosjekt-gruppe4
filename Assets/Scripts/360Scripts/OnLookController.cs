using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class OnLookController : MonoBehaviour{

	
	public Slider slider;
	
	
	private Camera cam;
	private GameObject objLookedAt;
	private float lookTimer;
	private float lookTime = 2f;
	private bool elementActivated = false;

	private void Awake(){
		cam = GetComponent<Camera>();
		slider.maxValue = lookTime;
	}

	private void Update(){
		
		Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 50f)){
			if(objLookedAt != hit.transform.gameObject){
				objLookedAt = hit.transform.gameObject;
				lookTimer = 0;
			}
			if(lookTimer < lookTime){
				lookTimer += Time.deltaTime;
			} else{
				//TODO: Activate look action on other object
				if (!elementActivated){
					elementActivated = true;
					objLookedAt.GetComponent<ElementAction>().DoAction();
				}
			}
		} else{
			lookTimer = 0;
			objLookedAt = null;
			elementActivated = false;
		}
		slider.value = lookTimer;
		
	}
	
	
}
