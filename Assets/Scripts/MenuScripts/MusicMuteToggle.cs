using UnityEngine;
using UnityEngine.UI;

// Mute controller for the mute button on settings page.
// Used to swap between the mute images, and mute/unmute the music
public class MusicMuteToggle : MonoBehaviour {

	public Sprite musicEnable, musicDisable;

	private Image image;

	private void Awake(){
		image = GetComponent<Image>();
	}

	private void Update(){
		if (AudioController.musicPlaying){
			image.sprite = musicEnable;
		} else{
			image.sprite = musicDisable;
		}
	}


	public void ToggleMusic(){
		AudioController.ToggleMusic();
	}
	
	
}
