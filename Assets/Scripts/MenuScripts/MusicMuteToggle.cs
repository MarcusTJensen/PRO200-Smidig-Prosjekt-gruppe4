using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
