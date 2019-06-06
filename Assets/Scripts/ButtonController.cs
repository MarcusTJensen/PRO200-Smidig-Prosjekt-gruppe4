using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {


	[Tooltip("What happens to the button when you come here from the settings page")]
	public StyleFromSetting fromSettings;

	public enum StyleFromSetting {
		Nothing,
		Hide,
		Show
	}

	[HideInInspector]
	public string targetScene;

	private void Update(){
		if(fromSettings == StyleFromSetting.Hide && StaticScript.comingFromSettings && gameObject.activeSelf){
			gameObject.SetActive(false);
		} else if (fromSettings == StyleFromSetting.Show && StaticScript.comingFromSettings && !gameObject.activeSelf){
			gameObject.SetActive(true);
		}
	}


	public void ButtonClicked(){
		//print("Loading scene: " + targetScene);
		StaticScript.comingFromSettings = false;
		SceneManager.LoadScene(targetScene);
	}

	public void SettingsButtonClicked(){
		StaticScript.comingFromSettings = true;
		SceneManager.LoadScene(targetScene);
	}



}
