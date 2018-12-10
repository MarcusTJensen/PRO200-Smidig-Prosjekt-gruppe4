using UnityEngine;
using UnityEngine.UI;

public class ChangeInteractive : MonoBehaviour {

	public Button targetToChange;
	public bool newState;
	public bool swap;



	public void MakeChange(){
		if(swap){
			targetToChange.interactable = !targetToChange.interactable;
		} else{
			targetToChange.interactable = newState;
		}
	}
	
	
	
}
