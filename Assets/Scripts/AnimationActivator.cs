using UnityEngine;

public class AnimationActivator : MonoBehaviour {

	public float animInterval, animTimer;


	private Animator anim;


	private void Awake(){
		anim = GetComponent<Animator>();
	}

	private void Update(){
		animTimer -= Time.deltaTime;
		if (animTimer <= 0){
			animTimer = animInterval;
			anim.SetTrigger("Trigger");
		}
	}
}