using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {
    
    //public static GPS Instance { set; get; }

    public Text text;

    [Header("Dont edit, just debug")]
    
    public float latitude = 59.912227f;
    public float longitude = 10.757912f;

    public Vector3 geoPos;
    
    public Vector3 factorUnit;
    public Vector3 posUnit;

    
    
    private Vector3 maxUnityCoords = new Vector3(250f, 0, 150f);
    
    private Vector3 minGCoords = new Vector3(59.904697f, 0, 10.725555f);
    private Vector3 maxGCoords = new Vector3(59.915819f, 0, 10.762764f);
    private Vector3 factor = new Vector3(0, 0, 0);
    
    private bool debug = false;

	
	private void Start(){
	    factor.x =  maxUnityCoords.x / (maxGCoords.x - minGCoords.x);
	    factor.z =  maxUnityCoords.z / (maxGCoords.z - minGCoords.z);
	    factorUnit = factor;
	    //Instance = this;
        //DontDestroyOnLoad(gameObject);
	    //StartCoroutine(StartLocationService());
	    TranslateCoord();
	}

    private IEnumerator StartLocationService() {

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
            
            
            transform.position = new Vector3(longitude, 0, latitude);
        }
        
    }




    private void TranslateCoord(){
        
        Vector3 pos = new Vector3(0, 0, 0);
        pos.x = (geoPos.x - minGCoords.x) * factor.x;
        pos.z = (geoPos.z - minGCoords.z) * factor.z;
        posUnit = pos;

        transform.position = pos;
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
        
        text.text = latitude + " : " + longitude;
        
        
    }


    public void DebugToggle(){
        debug = !debug;
    }
    
    
}
