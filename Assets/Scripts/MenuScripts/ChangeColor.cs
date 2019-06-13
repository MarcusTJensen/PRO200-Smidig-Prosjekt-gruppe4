using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	public Renderer targetToChange;
	public Color originalColor, targetColor;
	public bool switchToTargetColor = true;


	public void ToggleColor(){
		if (switchToTargetColor){
			targetToChange.material.color = targetColor;
			switchToTargetColor = false;
		} else{
			targetToChange.material.color = originalColor;
			switchToTargetColor = true;
		}
	}
	
	
}
