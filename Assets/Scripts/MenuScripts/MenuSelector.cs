using UnityEngine;

public class MenuSelector : MonoBehaviour{


	public Color selectedBG, unselectedBG;
	public Color selectedTxt, unselectedTxt;
	public MenuItem languageSelected;
	public MenuItem[] languages;
	
	

	public void ChangeToLanguage(MenuItem newLanguage){
		print("Change Language");
		languageSelected.SetValues(newLanguage);
		for(int i = 0; i < languages.Length; i++){
			if(languages[i] == null) continue;
			if(languages[i] == newLanguage){
				languages[i].SetToggle(selectedTxt, selectedBG);
			} else{
				languages[i].SetToggle(unselectedTxt, unselectedBG);
			}
		}
		
	}
	


	private void Start(){
		languages[0].SetToggle(selectedTxt, selectedBG);
		for(int i = 1; i < languages.Length; i++){
			if(languages[i] == null) continue;
			languages[i].SetToggle(unselectedTxt, unselectedBG);
		}
	}
}
