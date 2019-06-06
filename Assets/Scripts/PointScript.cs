using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour {

	public InfoCard infoCard;
	
	[HideInInspector]
	public string targetScene;

	public string header;
	public string info;

	
	
	public void PointClick(){
		infoCard.SetInfo(header, info, targetScene);
		infoCard.SetActive(true);
	}




}
