﻿using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class DropdownSwitch : MonoBehaviour{

	public GameObject[] target;
	public Sprite[] newImage;
	public Animator animator;



	public void SwitchValues(){
		int index = GetComponent<Dropdown>().value;

		if(index > target.Length) return;
		if(target[index] != null){
			target[index].GetComponent<Image>().sprite = newImage[index];
		}
		
	}

	public void test(bool active){
		print("Test");
		animator.SetBool("Open", active);
		
	}
	
	
	

}
