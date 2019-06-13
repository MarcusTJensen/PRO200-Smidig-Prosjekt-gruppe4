using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {
    
    [Serializable]
    public struct Vec3D{
        public double x;
        public double y;
        public double z;

        public Vec3D(double x, double y, double z){
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector3 GetVecFloat(){
            return new Vector3((float) x, (float) y, (float) z);
        }
    }
    
    //public static GPS Instance { set; get; }
    
    public Text text;

    [Header("Dont edit, just debug")]
    
    public Text debugText;
    
    public double latitude = 59.912797f;
    public double longitude = 10.753920f;

    public Vec3D geoPos;
    
    public Vec3D factorUnit;
    public Vec3D posUnit;

    private Vec3D maxUnityCoords = new Vec3D(150f, 0, 250f);
    
    private Vec3D maxGCoords = new Vec3D(59.915819f, 0, 10.763828f);
    private Vec3D minGCoords = new Vec3D(59.904071f, 0, 10.725555f);
    private Vec3D factor = new Vec3D(0, 0, 0);

    private float lastHeading = 0;
    
    private bool debug = false;
    
	private void Start(){
	    factor.x = maxUnityCoords.x / (maxGCoords.x - minGCoords.x);
	    factor.z = maxUnityCoords.z / (maxGCoords.z - minGCoords.z);
	    factorUnit = factor;
        Input.compass.enabled = true;
	    StartCoroutine(StartLocationService());
	}

    private void Update(){
        float newHeading = Input.compass.magneticHeading;

        StaticScript.playerRotation = Mathf.LerpAngle(StaticScript.playerRotation, newHeading, Time.deltaTime * 2);
        
        transform.rotation = Quaternion.Euler(0,  StaticScript.playerRotation + 45, 0);
        //debugText.text = StaticScript.playerRotation + "";
        lastHeading = newHeading;
        
    }
    
    
    //Co-routine to get GPS coords from the phone
    private IEnumerator StartLocationService() {
        yield return new WaitForSeconds(2);
        
        if (!Input.location.isEnabledByUser){
            //debugText.text = "User has not enabled GPS";
            Debug.Log("User has not enabled GPS");
            yield break;
        }
    
        Input.location.Start();
        
        
        
        int maxWait = 10;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
            //debugText.text = "Waiting.. " + maxWait;
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        
        if (maxWait <= 0){
            //debugText.text = "Timed out";
            Debug.Log("Timed out");
            yield break;
        }

        while(true){
    
            if (Input.location.status == LocationServiceStatus.Failed){
                debugText.gameObject.SetActive(true);
                debugText.text = "Unable to determine device location";
                Debug.Log("Unable to determine device location");
                yield break;
            }
    
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            
            TranslateCoord();
            
            yield return new WaitForSeconds(0.25f);
        }
        
    }

    //Calculate where to put th marker in the unity world.
    //This is also dependent on how big the map snippet is, and will need a change if
    // the map is changed. Best thing is to replace this with some plugin to get google maps
    // directly into unity.
    private void TranslateCoord(){


        Vec3D pos = new Vec3D(0, 0, 0);
        pos.z = factor.x * (latitude - minGCoords.x);
        pos.x = factor.z * (longitude - minGCoords.z);
        posUnit = pos;

        transform.position = pos.GetVecFloat();
        
        text.text = latitude + " : " + longitude;

    }


    public void DebugToggle(){
        debug = !debug;
    }
    
    
}
