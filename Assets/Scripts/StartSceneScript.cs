using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour {


	public Slider loadSlider;
	public float loadTime;
	[HideInInspector]
	public string sceneToLoad;
	
	private float loadTimer;

	private void Awake(){
		loadSlider.maxValue = loadTime;
	}

	private void Update(){
		if(loadTimer < loadTime + 1){
			loadTimer += Time.deltaTime;
			loadSlider.value = loadTime;
		} else{
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}
