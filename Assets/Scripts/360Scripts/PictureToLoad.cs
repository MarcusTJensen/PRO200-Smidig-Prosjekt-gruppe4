using UnityEngine;

public class PictureToLoad : MonoBehaviour{


	public Texture texture;
	
	private Material mat;


	//Change the source image of the material to change image on load
	private void Awake(){
		mat = GetComponent<MeshRenderer>().materials[0];
		mat.mainTexture = texture;
	}
}
