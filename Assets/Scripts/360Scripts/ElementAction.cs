using System;
using UnityEngine;
using UnityEngine.Internal.UIElements;

public class ElementAction : MonoBehaviour {
	
	[Serializable]
	public struct Action{
		public ActionType actionType;
		public Transform movePosition;
		public GameObject panel;
		public string consoleText;
	}
	
	public enum ActionType{
		PlaySound,
		StopSound,
		EnterRoom,
		OpenPanel,
		ClosePanel,
		PrintConsole
	}
	
	public Action action;
	
	private AudioSource aud;

	private void Awake(){
		aud = GetComponent<AudioSource>();
	}

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
				//todo	
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
