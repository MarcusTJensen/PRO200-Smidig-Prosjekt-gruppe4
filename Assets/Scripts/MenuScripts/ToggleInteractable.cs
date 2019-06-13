
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInteractable : MonoBehaviour {

	public List<Button> buttons;

	// Toggle a list of buttons to be interactive or not
	// Set to the opposite of what they was before
	public void ToggleButtons(){
		foreach (Button button in buttons){
			button.interactable = !button.interactable;
		}
	}
}
