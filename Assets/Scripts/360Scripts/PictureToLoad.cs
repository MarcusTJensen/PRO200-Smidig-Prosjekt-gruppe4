using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureToLoad : MonoBehaviour{


	public Texture texture;
	
	private Material mat;


	private void Awake(){
		mat = GetComponent<MeshRenderer>().materials[0];
		mat.mainTexture = texture;
	}
}
