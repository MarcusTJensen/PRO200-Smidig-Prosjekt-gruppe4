using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Cam360Controller : MonoBehaviour {
    
    private bool vrEnabled = false;
    private bool cardboardView = false;

    public Text debug;
    
	private float timer, timeLim = 0.03333333333333333f;

    private void Awake(){
        //transform.rotation = Quaternion.Euler(0, StaticScript.playerRotation, 0);
        ToggleVR(true);
    }

    private void Update(){
        
	    if(!cardboardView && vrEnabled){
		    Quaternion rot = InputTracking.GetLocalRotation(XRNode.CenterEye);
            //transform.rotation = rot;
            transform.rotation = Quaternion.Euler(rot.eulerAngles + new Vector3(0, StaticScript.playerRotation, 0));
            //TODO: Fix sensitivity, check nodes for change in rotation/velocity and move only if over x or something

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
            cardboardView = false;
            XRSettings.enabled = false;
            Screen.orientation = ScreenOrientation.Portrait;
        } else{
            cardboardView = true;
            transform.rotation = Quaternion.identity;
            XRSettings.enabled = true;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
    
    
    

}
