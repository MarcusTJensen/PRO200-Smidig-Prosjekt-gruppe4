using UnityEngine;
using UnityEngine.XR;

public class Cam360Controller : MonoBehaviour{



    private void Update(){
        XRSettings.enabled = false;
        transform.rotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
    }

}
