using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOpacity : MonoBehaviour {

	public List<Image> imageList;
	public List<Text> textList;
	public float alphaLow, alphaHigh;
	public bool setAlphaHigh;


	public void ToggleAlpha(){
		if (setAlphaHigh){
			setAlphaHigh = false;
			SetAlpha(alphaHigh);
		} else{
			setAlphaHigh = true;
			SetAlpha(alphaLow);
		}
	}

	private void SetAlpha(float alpha){
		foreach (Image image in imageList){
			Color col = image.color;
			col.a = alpha;
			image.color = col;
		}
		foreach (Text text in textList){
			Color col = text.color;
			col.a = alpha;
			text.color = col;
		}
	}


}