using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour{


	public Image targetToChange;
	public Sprite newImage;



	public void MakeChange(){
		targetToChange.sprite = newImage;
	}
	

}
