using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour {


	public Image loadSlider;
	public float loadTime;
	public float randomInterval;
	public float freezeTime;
	[HideInInspector]
	public string sceneToLoad;

	private float loadTimer, randomTimer, freezeTimer;
	private bool freeze, sceneLoaded;
	

	private void Update(){
		if (sceneLoaded)
			return;
		randomTimer += Time.deltaTime;
		if (randomTimer > randomInterval){
			randomTimer = Random.Range(0, randomInterval);
			freeze = true;
		}

		if (freeze){
			freezeTimer += Time.deltaTime;
			if (freezeTimer > freezeTime){
				freezeTimer = 0;
				freeze = false;
			} else{
				return;
			}
		}


		if(loadTimer < loadTime + 1){
			loadTimer += Time.deltaTime;
			loadSlider.fillAmount = (loadTimer / loadTime);
		} else{
			sceneLoaded = true;
			SceneManager.LoadScene(sceneToLoad);
		}
	}
}
