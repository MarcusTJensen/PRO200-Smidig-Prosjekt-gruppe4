using System.Collections.Generic;
using UnityEngine;

public class ChangeActive : MonoBehaviour {

	public List<GameObject> targetsToChange;


	public void ToggleActive(){
		foreach (GameObject o in targetsToChange){
			o.SetActive(!o.activeSelf);
		}
	}

	public void SetActive(bool active){
		foreach (GameObject o in targetsToChange){
			o.SetActive(active);
		}
	}
	
	
}
