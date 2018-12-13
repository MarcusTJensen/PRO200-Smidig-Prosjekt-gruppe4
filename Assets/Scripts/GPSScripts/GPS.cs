using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {
    
    //public static GPS Instance { set; get; }

    public Text text;

    private float latitude;
    private float longitude;

    private bool debug = false;

	
	private void Start(){
	    //Instance = this;
        //DontDestroyOnLoad(gameObject);
	    StartCoroutine(StartLocationService());
	}

    private IEnumerator StartLocationService() {
        
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        
        
        TranslateCoord();
        
        
        transform.position = new Vector3(longitude, 0, latitude);
        
    }




    private void TranslateCoord(){
        
        
        string sLat = latitude.ToString().Substring(4);
        sLat = sLat.Insert(1, ".");
        latitude = float.Parse(sLat);

        if(debug){

            float fLng = (76 - longitude) * 75;
            longitude = fLng;

        } else{
            string sLng = longitude.ToString().Substring(4);

            sLng = sLng.Insert(1, ".");

            longitude = float.Parse(sLng);
        }
        

        text.text = latitude + " : " + longitude;

    }


    public void DebugToggle(){
        debug = !debug;
    }
    
    
}
