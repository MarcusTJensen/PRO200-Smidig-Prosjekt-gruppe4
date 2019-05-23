using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class OnLookController : MonoBehaviour{

	public float lookTime;
	public float lookTimer = 2f;
	
	private Camera cam;
	private GameObject objLookedAt;

	private void Awake(){
		cam = GetComponent<Camera>();
	}

	private void Update(){
		
		Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 50f)){
			if(objLookedAt != hit.transform.gameObject){
				objLookedAt = hit.transform.gameObject;
				lookTime = 0;
			}
			if(lookTime < lookTimer){
				lookTime += Time.deltaTime;
			} else{
				//TODO: Activate look action on other object
			}
		} else{
			lookTime = 0;
		}
		
	}
	
	
}
