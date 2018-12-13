using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {
    
    //public static GPS Instance { set; get; }

    public Text text;

    private float latitude = 59.912666f;
    private float longitude = 10.746467f;

    private bool debug = false;

	
	private void Start(){
	    //Instance = this;
        //DontDestroyOnLoad(gameObject);
	    //StartCoroutine(StartLocationService());
	    TranslateCoord();
            
            
	    transform.position = new Vector3(longitude, 0, latitude);
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
        
        text.text = latitude + " : " + longitude;
        
        
    }


    public void DebugToggle(){
        debug = !debug;
    }
    
    
}
