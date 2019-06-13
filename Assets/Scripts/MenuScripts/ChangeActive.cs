using System.Collections.Generic;
using UnityEngine;

public class ChangeActive : MonoBehaviour {

	public List<GameObject> targetsToChange;


	// Toggle active state for all objects in list
	public void ToggleActive(){
		foreach (GameObject o in targetsToChange){
			o.SetActive(!o.activeSelf);
		}
	}
	
	// Set active for all objects in list to selected state
	public void SetActive(bool active){
		foreach (GameObject o in targetsToChange){
			o.SetActive(active);
		}
	}
	
	
}
