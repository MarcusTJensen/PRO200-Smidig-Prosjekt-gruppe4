using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorScript : MonoBehaviour {
	private void Awake(){
		transform.rotation = Quaternion.Euler(0, StaticScript.playerRotation, 0);
	}
}
