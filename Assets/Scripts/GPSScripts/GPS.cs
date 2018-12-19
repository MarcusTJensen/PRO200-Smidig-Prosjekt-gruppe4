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
    
    private bool debug = false;

    /*
    private void DoCalcTest(){
        
        double fac = maxUnityCoords.x / (maxGCoords.x - minGCoords.x);
        //print(maxUnityCoords.x + " / (" + maxGCoords.x + " - " + minGCoords.x + ") = " + fac);
        
        double posi = fac * (latitude - minGCoords.x);
        //print(fac + " * (" + latitude + " - " + minGCoords.x + ") = " + posi);
        
    }
    */
    
	private void Start(){
	    //DoCalcTest();
	    //return;
	    factor.x = maxUnityCoords.x / (maxGCoords.x - minGCoords.x);
	    factor.z = maxUnityCoords.z / (maxGCoords.z - minGCoords.z);
	    factorUnit = factor;
	    //Instance = this;
        //DontDestroyOnLoad(gameObject);
	    StartCoroutine(StartLocationService());
	    //TranslateCoord();
	}

    private IEnumerator StartLocationService() {
        //debugText.text = "Starting Routine";
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
                debugText.text = "Unable to determin device location";
                //debugText.text = "Unable to determin device location";
                Debug.Log("Unable to determin device location");
                yield break;
            }
    
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            /*
            switch(Input.location.status){
                case LocationServiceStatus.Failed:
                    //debugText.text = "Failed";
                    break;
                case LocationServiceStatus.Running:
                    //debugText.text = "Running";
                    break;
                case LocationServiceStatus.Stopped:
                    //debugText.text = "Stopped";
                    break;
            }
            */
            
            TranslateCoord();
            
            yield return new WaitForSeconds(0.25f);
        }
        
    }

    private void TranslateCoord(){


        Vec3D pos = new Vec3D(0, 0, 0);
        pos.z = factor.x * (latitude - minGCoords.x);
        pos.x = factor.z * (longitude - minGCoords.z);
        posUnit = pos;

        transform.position = pos.GetVecFloat();
        
        text.text = latitude + " : " + longitude;

        //double t = factor.x * (latitude - minGCoords.x);
        //print(t + " = " + factor.x + " * (" + latitude + " - " + minGCoords.x + ")");
        /*
        if(!debug){
            
            string sLat = latitude.ToString().Substring(4);
            sLat = sLat.Insert(1, ".");
            latitude = float.Parse(sLat);
        
            string sLng = longitude.ToString().Substring(4);
            sLng = sLng.Insert(1, ".");
            longitude = float.Parse(sLng);

            float fLng = longitude * 12.97f;
            float fLat = latitude * 12.97f;
            longitude = fLng;
            latitude = fLat;
            
        }
        */

    }


    public void DebugToggle(){
        debug = !debug;
    }
    
    
}
