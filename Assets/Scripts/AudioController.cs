using UnityEngine;

public class AudioController : MonoBehaviour {

	public static bool musicPlaying;

	private static AudioSource osloHavnAud;
	private static AudioSource activeMusic;

	public enum Music {
		None,
		OsloHavn
	}

	private void Awake(){
		osloHavnAud = transform.GetChild(0).GetComponent<AudioSource>();
	}

	private void Update(){
		if (activeMusic == null)
			return;
		musicPlaying = activeMusic.isPlaying;
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

	public static void ToggleMusic(){
		if(activeMusic.isPlaying)
			ToggleMusic(false);
		else
			ToggleMusic(true);
	}

	public static void ToggleMusic(bool active){
		if (activeMusic == null)
			return;
		if (active){
			activeMusic.Play();
		} else{
			activeMusic.Pause();
		}
	}

}
