using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ElementAction : MonoBehaviour {
	
	public struct Action{
		public ActionType actionType;
		public Transform movePosition;
	}

	public enum ActionType{
		PlaySound,
		StopSound,
		EnterRoom
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
		}
	}
	
}
