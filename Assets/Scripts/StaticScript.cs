using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticScript : MonoBehaviour {



	public static float playerRotation;


	private void Awake(){
		DontDestroyOnLoad(gameObject);
	}
}
