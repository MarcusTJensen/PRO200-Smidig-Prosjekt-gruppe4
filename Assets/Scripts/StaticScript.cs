using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScript : MonoBehaviour {



	public static float playerRotation;
	public static bool comingFromSettings;


	private void Awake(){
		DontDestroyOnLoad(gameObject);
	}
}
