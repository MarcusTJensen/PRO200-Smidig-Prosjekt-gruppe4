using UnityEngine;
using UnityEngine.UI;

public class MenuItem : MonoBehaviour{

	public Text text;
	public Image background;
	public Image flag;





	public void SetToggle(Color txtColor, Color bgColor){
		text.color = txtColor;
		background.color = bgColor;
	}

	
	public void SetValues(MenuItem selectedItem){
		text.text = selectedItem.text.text;
		flag.sprite = selectedItem.flag.sprite;
	}
	


}
