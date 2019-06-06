using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FromSettingsScript : MonoBehaviour {

	public List<GameObject> toggleObjects;
	public ButtonController.StyleFromSetting fromSettings;

	private void Update(){
		if (fromSettings == ButtonController.StyleFromSetting.Show && StaticScript.comingFromSettings){
			ToggleObjects(true);
		}
		if (fromSettings == ButtonController.StyleFromSetting.Hide && StaticScript.comingFromSettings){
			ToggleObjects(false);
		}
		if (fromSettings == ButtonController.StyleFromSetting.Show && !StaticScript.comingFromSettings){
			ToggleObjects(false);
		}
		
	}


	private void ToggleObjects(bool active){
		foreach (GameObject o in toggleObjects){
			o.SetActive(active);
		}
	}
	
	
}
