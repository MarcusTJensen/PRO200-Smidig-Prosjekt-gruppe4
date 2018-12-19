using UnityEngine;
using UnityEngine.XR;

public class Cam360Controller : MonoBehaviour{

    private bool vr360Enabled = false;

    
    
    private void Update(){
        if(vr360Enabled){
            XRSettings.enabled = false;
            transform.rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
        }
    }


    public void StartVR360(bool setEnabled){
        if(setEnabled){
            XRSettings.LoadDeviceByName("cardboard");
            vr360Enabled = true;
        } else{
            XRSettings.LoadDeviceByName("None");
            vr360Enabled = false;
        }
    }

    public void ToggleVr360(){
        StartVR360(vr360Enabled);
    }
    

}
