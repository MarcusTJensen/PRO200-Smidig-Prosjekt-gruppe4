using System;
using UnityEngine;

public class ElementAction : MonoBehaviour {
	
	[Serializable]
	public struct Action{
		public ActionType actionType;
		public Transform movePosition;
		public string consoleText;
	}
	
	public enum ActionType{
		PlaySound,
		StopSound,
		EnterRoom,
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
			case ActionType.PrintConsole:
				print(action.consoleText);
				break;
		}
	}
	
}
