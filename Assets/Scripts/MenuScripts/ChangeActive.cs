using UnityEngine;

public class ChangeActive : MonoBehaviour {

	public GameObject targetToChange;
	public bool newState;



	public void MakeChange(){
		newState = !newState;
		targetToChange.SetActive(newState);
	}
	
	
}
