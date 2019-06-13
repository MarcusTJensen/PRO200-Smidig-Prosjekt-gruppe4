using System;
using UnityEngine;
using UnityEngine.UI;

public class ElementAction : MonoBehaviour {
	
	[Serializable]
	public struct Action{
		public ActionType actionType;
		public Transform movePosition;
		public GameObject panel;
		public string consoleText;
		public float lookTime;
	}
	
	public enum ActionType{
		PlaySound,
		StopSound,
		EnterRoom,
		OpenPanel,
		ClosePanel,
		PrintConsole
	}

	public Slider progresBar;
	public Action action;
	
	private AudioSource aud;
	private float lookTimer;
	private bool actionDone;

	private void Awake(){
		aud = GetComponent<AudioSource>();
		progresBar.maxValue = action.lookTime;
	}


	public void Reset(){
		lookTimer = 0;
		progresBar.gameObject.SetActive(false);
		actionDone = false;
	}
	
	//Update progress bar and timer before action happens
	public void Progress(){
		if (lookTimer < action.lookTime && !actionDone){
			if (!progresBar.gameObject.activeSelf)
				progresBar.gameObject.SetActive(true);
			lookTimer += Time.deltaTime;
			progresBar.value = lookTimer;
		} else{
			if (!actionDone){
				DoAction();
				actionDone = true;
				progresBar.gameObject.SetActive(false);
			}
		}
	}
	
	//What happens with different actions
	public void DoAction(){
		switch(action.actionType){
			case ActionType.PlaySound:
				aud.Play();
				break;
			case ActionType.StopSound:
				aud.Stop();
				break;
			case ActionType.EnterRoom:
				aud.Stop();
				break;
			case ActionType.OpenPanel:
				action.panel.SetActive(true);
				break;
			case ActionType.ClosePanel:
				action.panel.SetActive(false);
				break;
			case ActionType.PrintConsole:
				print(action.consoleText);
				break;
		}
	}
	
}
