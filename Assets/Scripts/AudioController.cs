using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	

	private static AudioSource osloHavnAud;
	private static AudioSource activeMusic;

	public enum Music {
		None,
		OsloHavn
	}

	private void Awake(){
		osloHavnAud = transform.GetChild(0).GetComponent<AudioSource>();
	}

	public static void SetActiveMusic(Music newMusic){
		switch (newMusic){
			case Music.OsloHavn:
				activeMusic = osloHavnAud;
				break;
			default:
				break;
		}
	}

	public static void ToggleMusic(bool active){
		if (activeMusic == null)
			return;
		if (active){
			activeMusic.Play();
		} else{
			activeMusic.Stop();
		}
	}

}
