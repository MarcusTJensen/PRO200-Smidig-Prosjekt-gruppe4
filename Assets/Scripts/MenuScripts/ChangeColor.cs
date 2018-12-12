using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	public GameObject targetToChange;
	public bool newState;



	public void MakeChange(){
		targetToChange.SetActive(newState);
	}
	
	
}
