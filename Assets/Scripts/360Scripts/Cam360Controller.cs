using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Cam360Controller : MonoBehaviour {
    
    private bool vrEnabled = false;
    private bool cardboardView = false;

    public GameObject backButton;
    public Text debug;
    

    private void Awake(){
        //transform.rotation = Quaternion.Euler(0, StaticScript.playerRotation, 0);
        ToggleVR(true);
    }

    private void Update(){
        
	    if(!cardboardView && vrEnabled){
		    Quaternion rot = InputTracking.GetLocalRotation(XRNode.CenterEye);
            //transform.rotation = Quaternion.Euler(rot.eulerAngles + new Vector3(0, StaticScript.playerRotation, 0));
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(rot.eulerAngles + new Vector3(0, StaticScript.playerRotation, 0)),
                Time.deltaTime * 6);

        }
	    
	    
	}

    public void ToggleVR(){
        if(vrEnabled){
            vrEnabled = false;
            XRSettings.LoadDeviceByName("None");
            Screen.orientation = ScreenOrientation.Portrait;
        } else{
            vrEnabled = true;
            XRSettings.LoadDeviceByName("cardboard");
        }
    }

    public void ToggleVR(bool value){
        vrEnabled = value;
        if(value){
            XRSettings.LoadDeviceByName("cardboard");
        } else{
            XRSettings.LoadDeviceByName("None");
            Screen.orientation = ScreenOrientation.Portrait;
        }
    }

    public void ToggleCardboardView(){
        if(cardboardView){
            backButton.SetActive(true);
            cardboardView = false;
            XRSettings.enabled = false;
            Screen.orientation = ScreenOrientation.Portrait;
        } else{
            backButton.SetActive(false);
            cardboardView = true;
            transform.rotation = Quaternion.identity;
            XRSettings.enabled = true;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
    
    
    

}
