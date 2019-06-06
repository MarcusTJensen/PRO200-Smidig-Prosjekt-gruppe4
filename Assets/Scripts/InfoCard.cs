using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoCard : MonoBehaviour {


	public GameObject infoCard;
	public Text infoHeader, infoText;

	private string targetScene;

	public void SetActive(bool active){
		infoCard.SetActive(active);
	}

	public void SetInfo(string header, string info, string scene){
		infoHeader.text = header;
		infoText.text = info;
		targetScene = scene;
	}

	public void Start360(){
		SceneManager.LoadScene(targetScene);
	}



}
