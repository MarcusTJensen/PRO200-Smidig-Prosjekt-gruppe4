using UnityEngine;
using UnityEngine.XR;

public class Cam360Controller : MonoBehaviour{

    private bool vrEnabled = false;
    private bool cardboardView = false;

    private void Awake(){
        ToggleVR(true);
    }

    private void Update(){
        if(!cardboardView && vrEnabled){
            transform.rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
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
