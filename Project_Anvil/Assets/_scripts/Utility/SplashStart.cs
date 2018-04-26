using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mapbox.Unity.Utilities;
using Mapbox.Map;
using Mapbox.Unity.Map;
using Mapbox.Utils;


public class SplashStart : MonoBehaviour {

    public Text myLat;
    public Text myLong;
    public Text header;

    public double prefabHeight;

    public Vector2 myCoords;

    public Vector2d coords2d;

    GameObject splashCanvas;
    GameObject myMain;
    AISpawner aiSpawner;
    GetHeight getHeight;

    public GetLocation getLocation;
    public BasicMap basicMap;
    



	// Use this for initialization
	void Start () {

        splashCanvas = GameObject.Find("SplashCanvas");
        myMain = GameObject.Find("Main Camera");
        myMain.SetActive(false);

        aiSpawner = GameObject.Find("AISpawner").GetComponent<AISpawner>();
        getHeight = GetComponent<GetHeight>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void GetLocation()
    {
        myCoords = getLocation.GetLoc();
        if(myCoords.x == 0)
        {
            myLat.text = "Sorry, GPS error, or value not initialized";
            myLong.text = " ";
        } else
        {
            myLat.text = "Your latitude is: " + myCoords.x;
            myLong.text = "Your longitude is: " + myCoords.y;
        }
    }


    // public void LoadCity (int)
    // for now it takes in a variable that was assigned to a button in the inspector. this is to
    // tell it which city to start in.
    public void LoadCity(int temp)
    {
        if (temp == 1) // San Diego
        {
            coords2d = new Vector2d(32.7157, -117.1611);
            basicMap.Initialize(coords2d, 15);
            prefabHeight = getHeight.HeightForPrefab(coords2d.x, coords2d.y, basicMap);
            StartCoroutine("CameraSwitch");
        }
        else if (temp == 2) // Laramie
        {
            coords2d = new Vector2d(41.3114, -105.5911);
            basicMap.Initialize(coords2d, 15);
            prefabHeight = getHeight.HeightForPrefab(coords2d.x, coords2d.y, basicMap);
            StartCoroutine("CameraSwitch");
        }
        else if (temp == 3) // Denver
        {
            coords2d = new Vector2d(39.742043, -104.991531);
            basicMap.Initialize(coords2d, 15);
            prefabHeight = getHeight.HeightForPrefab(coords2d.x, coords2d.y, basicMap);
            StartCoroutine("CameraSwitch");
        }
        else if (temp == 4) // Los Angeles
        {
            coords2d = new Vector2d(34.052235, -118.243683);
            basicMap.Initialize(coords2d, 15);
            prefabHeight = getHeight.HeightForPrefab(coords2d.x, coords2d.y, basicMap);
            StartCoroutine("CameraSwitch");
        }
    }
    // IEnumerator Camera Switch ()
    // Delays the camera from displaying the game level until everything should have loaded
    IEnumerator CameraSwitch()
    {
        header.text = "Please wait...";
        yield return new WaitForSeconds(3);
        aiSpawner.BeginPlacing(prefabHeight);
        yield return new WaitForSeconds(2);
        myMain.transform.position = new Vector3(myMain.transform.position.x, myMain.transform.position.y + (float)prefabHeight,
            myMain.transform.position.z);
        myMain.SetActive(true);
        splashCanvas.SetActive(false);
        gameObject.SetActive(false);
    }
}
