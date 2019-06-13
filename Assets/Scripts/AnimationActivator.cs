using UnityEngine;

public class AnimationActivator : MonoBehaviour {

	public float animInterval, animTimer;


	private Animator anim;


	private void Awake(){
		anim = GetComponent<Animator>();
	}
	
	// Activate an animation based on time
	private void Update(){
		animTimer -= Time.deltaTime;
		if (animTimer <= 0){
			animTimer = animInterval;
			anim.SetTrigger("Trigger");
		}
	}
}