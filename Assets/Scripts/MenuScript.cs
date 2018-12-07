using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour{
	
	public GameObject[] targets;
	[Header("Values")]
	public int[] intValues;
	public float[] floatValues;
	public string[] stringValues;
	public Sprite[] spriteValues;
	
	
	
	public void SetIntValues(){
		print("Yay");
	}
	
	public void SetFloatValues(){
		print("Yay");
	}
	
	public void SetStringValues(){
		for(int i = 0; i < targets.Length; i++){
			Text text = targets[i].GetComponent<Text>();
			if(text != null){
				text.text = stringValues[i];
				Dropdown d;
			}
		}
	}
	
	public void SetSpriteValues(){
		print("Yay");
	}


}
