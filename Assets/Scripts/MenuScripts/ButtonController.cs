using System;
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

	public AudioController.Music musicType;

	private void Update(){
		if(fromSettings == StyleFromSetting.Hide && StaticScript.comingFromSettings && gameObject.activeSelf){
			gameObject.SetActive(false);
		} else if (fromSettings == StyleFromSetting.Show && StaticScript.comingFromSettings && !gameObject.activeSelf){
			gameObject.SetActive(true);
		}
	}

	public void MusicToggle(bool active){
		AudioController.ToggleMusic(active);
	}

	public void ButtonClicked(){
		if(DoButtonClick())
			StaticScript.comingFromSettings = false;
	}

	public void SettingsButtonClicked(){
		if(DoButtonClick())
			StaticScript.comingFromSettings = true;
	}

	private bool DoButtonClick(){
		if (targetScene == String.Empty)
			return false;
		if (musicType != AudioController.Music.None){
			AudioController.SetActiveMusic(musicType);
			AudioController.ToggleMusic(true);
		}
		SceneManager.LoadScene(targetScene);
		return true;
	}


}
