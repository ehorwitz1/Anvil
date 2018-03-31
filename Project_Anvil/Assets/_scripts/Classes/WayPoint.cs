using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DotNetCoords;
using System;

public class WayPoint{
    public LatLng latLong;
    string wayPointSerialID;
    public string mWayPointName;
    string wayPointShortTitle;
    string group;
    double mLatitude;
    double mLongitude;
    public double mElevation;
    public static int lastUnassignedSerial=0;

    private GameObject blackBoard;
    private int blackBoardWayPointSerial;
    private List<WayPoint> blackBoardWayPointList;

    void Start()
    {
        blackBoard = GameObject.Find("BlackBoard");
        // blackBoardWayPointSerial = blackBoard.GetComponent<BlackBoardScript>().GetWayPointSerial();
        blackBoardWayPointSerial = 5;
        blackBoardWayPointList = blackBoard.GetComponent<BlackBoardScript>().allGameWayPoints;
    }
    public WayPoint (double latitude, double longitude, double height, string newWayPointName)
    {
        string serialString = DateTime.Now.ToShortDateString();
        string wayPointSerialID = serialString + lastUnassignedSerial.ToString();
        mLatitude = latitude;
        mLongitude = longitude;
        mElevation = height;
        mWayPointName = newWayPointName;
        lastUnassignedSerial ++;
        latLong = new LatLng(latitude, longitude, height);
        wayPointShortTitle = newWayPointName;
        PostToBlackboard();
    }

    override public string ToString()
    {
        string wptString = mWayPointName + "/" + mLatitude + "/" + mLongitude;
        return wptString;
    }

    public string LatLonString()
    {
        string wptString = mLatitude+ "\n" + mLongitude + "\n" + mElevation;
        return wptString;
    }
    //TODO method return WayPoint as KML string (https://developers.google.com/kml/documentation/kmlreference#point)

    public void SetLatLongFromXYZ(Vector3 unityCoords)
    {
        
    }

    private void PostToBlackboard()
    {
        //blackBoardWayPointList.Add(this.);
    }

    public string ToSaveString()
    {
        string saveString =
              mLatitude + "," +
        mLongitude + "," +
        mElevation + "," +
        mWayPointName ;
        return saveString;

    }

    public Vector3 ToUnityVector3()
    {
        return ConversionTool.LatLongToUnityVector3D(latLong);
    }
}
