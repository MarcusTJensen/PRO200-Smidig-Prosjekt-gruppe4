
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleInteractable : MonoBehaviour {

	public List<Button> buttons;

	public void ToggleButtons(){
		foreach (Button button in buttons){
			button.interactable = !button.interactable;
		}
	}
}
