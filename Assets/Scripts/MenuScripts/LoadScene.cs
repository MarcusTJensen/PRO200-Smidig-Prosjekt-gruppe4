using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour{

	[Header("Set index -1 or empty string to not use it")]
	public int sceneIndex = -1;
	public string sceneName;


	public void LoadSelectedScene(){
		if(sceneIndex >= 0){
			SceneManager.LoadScene(sceneIndex);
		} else if(sceneName != ""){
			SceneManager.LoadScene(sceneName);
		}
	}


}
