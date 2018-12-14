﻿using System;
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
<<<<<<< HEAD

    //location cords for: Sentrum  
    public float latitude = 59.910236f;
    public float longitude = 10.749435f;

    public Vector3 geoPos;
    public Vector3 factorUnit;
    public Vector3 posUnit;
    
    private Vector3 maxUnityCoords = new Vector3(250f, 0, 150f);
    private Vector3 minGCoords = new Vector3(59.904697f, 0, 10.725555f);
    private Vector3 maxGCoords = new Vector3(59.915819f, 0, 10.762764f);
    private Vector3 factor = new Vector3(0, 0, 0);
=======
    
    public double latitude = 59.912797f;
    public double longitude = 10.753920f;

    public Vec3D geoPos;
    
    public Vec3D factorUnit;
    public Vec3D posUnit;

    
    
    private Vec3D maxUnityCoords = new Vec3D(150f, 0, 250f);
    
    private Vec3D maxGCoords = new Vec3D(59.915819f, 0, 10.763828f);
    private Vec3D minGCoords = new Vec3D(59.904071f, 0, 10.725555f);
    private Vec3D factor = new Vec3D(0, 0, 0);
>>>>>>> 6d2293c13db5abb1050d8a589b64f04f93f9b4ea
    
    private bool debug = false;


    private void DoCalcTest(){
        double fac = maxUnityCoords.x / (maxGCoords.x - minGCoords.x);
        print(maxUnityCoords.x + " / (" + maxGCoords.x + " - " + minGCoords.x + ") = " + fac);
        
        double posi = fac * (latitude - minGCoords.x);
        print(fac + " * (" + latitude + " - " + minGCoords.x + ") = " + posi);
        
    }

	
	private void Start(){
	    //DoCalcTest();
	    //return;
	    factor.x = maxUnityCoords.x / (maxGCoords.x - minGCoords.x);
	    factor.z = maxUnityCoords.z / (maxGCoords.z - minGCoords.z);
	    factorUnit = factor;
	    //Instance = this;
        //DontDestroyOnLoad(gameObject);
	    //StartCoroutine(StartLocationService());
	    TranslateCoord();
	}

    private IEnumerator StartLocationService() {
        yield return new WaitForSeconds(3);

        while(true){
            if (!Input.location.isEnabledByUser){
                Debug.Log("User has not enabled GPS");
                yield break;
            }
    
            Input.location.Start();
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0){
                yield return new WaitForSeconds(1);
                maxWait--;
            }
    
            if (maxWait <= 0){
                Debug.Log("Timed out");
                yield break;
            }
    
            if (Input.location.status == LocationServiceStatus.Failed){
                Debug.Log("Unable to determin device location");
                yield break;
            }
    
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            
            
            TranslateCoord();
            
            
            //transform.position = new Vec3D(longitude, 0, latitude).GetVecFloat();
            
        }
        
    }

    private void TranslateCoord(){

        
<<<<<<< HEAD
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x = (geoPos.x - minGCoords.x) * factor.x;
        pos.z = (geoPos.z - minGCoords.z) * factor.z;
        posUnit = pos;

        transform.position = pos;
        
        /*if(!debug){
=======

        Vec3D pos = new Vec3D(0, 0, 0);
        pos.z = factor.x * (latitude - minGCoords.x);
        pos.x = factor.z * (longitude - minGCoords.z);
        print(longitude + " : " + minGCoords.z);
        posUnit = pos;

        transform.position = pos.GetVecFloat();

        double t = factor.x * (latitude - minGCoords.x);
        print(t + " = " + factor.x + " * (" + latitude + " - " + minGCoords.x + ")");
        /*
        if(!debug){
>>>>>>> 6d2293c13db5abb1050d8a589b64f04f93f9b4ea
            
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

<<<<<<< HEAD
        }*/
        
=======
        }
        */

>>>>>>> 6d2293c13db5abb1050d8a589b64f04f93f9b4ea
        text.text = latitude + " : " + longitude;

        if(debug){
            TranslateCoord();
        }

    }


    public void DebugToggle(){
        debug = !debug;
    }
    
    
}
