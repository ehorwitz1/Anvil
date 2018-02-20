using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DotNetCoords;
using Mapbox.Map;
using Mapbox.Unity;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class ConversionTool : MonoBehaviour {

	public GameObject player;
	public Text CurrentPos;
	private BasicMap MyMap;
	private Vector2d InitRef2D;
	private Vector3 UnityPos3D; 
	private Vector2d InitUnityPos2D;
	private string InitRef;
	public string LatLongString;
	public string MGRS_Coordinates;
	public string UTM_Coordinates;
	public string MGRS_Back_To_LatLong;

	void Start () {
		MyMap = BasicMap.FindObjectOfType<BasicMap>();
	}

	void Update () {

		//Convert the game object's Unity position into a Lat Long
		UnityPos3D = player.transform.position;
		InitUnityPos2D.x =  UnityPos3D.x;
		InitUnityPos2D.y = UnityPos3D.z;
		InitUnityPos2D = MyMap.CenterMercator + (InitUnityPos2D * MyMap.WorldRelativeScale);

		InitRef2D = Mapbox.Unity.Utilities.Conversions.MetersToLatLon(InitUnityPos2D);

		LatLng latLng = new LatLng(InitRef2D.x, InitRef2D.y);
		LatLongString = latLng.ToString();


		MGRSRef mgrsRef = latLng.ToMGRSRef();
		MGRS_Coordinates = mgrsRef.ToString();

		UTMRef utmRef = latLng.ToUtmRef(); 
		UTM_Coordinates = utmRef.ToString();

		// MGRS Coordinates back to Lat / Long (for testing purposes)

		LatLng back2LatLng = mgrsRef.ToLatLng (); 
		MGRS_Back_To_LatLong = back2LatLng.ToString ();

		CurrentPos.text = "Lat / Long: " + LatLongString + "\n" + "UTM: " + UTM_Coordinates + "\n" + "MGRS: " + MGRS_Coordinates;

	}
		
}
