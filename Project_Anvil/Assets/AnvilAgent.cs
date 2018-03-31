using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DotNetCoords;

public class AnvilAgent : MonoBehaviour {
    //name,id,location, orientation, faction
    public string mAgentName;
    public string mAgentSerial;
    public LatLng mLocation;
    public string mFaction;
    public string locString;
    public bool isSelected;
    private Transform myTransform;

    public string transformString;

    public WayPoint mNavTarget;
    public WayPoint mSensorTarget;
    //Gear - links to equipments by Arrays and List of owned or accessible objects
    //Goals -links to drives and traits classes
    //working memory - unit level blackboard: navTarget, navSequence, schedule, goals, sensorTarget, sensorList
    //Senses - links to perception and awareness

    public AnvilAgent(string agentName, string agentSerial, LatLng location, string faction)
    {
        mAgentName = agentName;
        mAgentSerial = agentSerial;
        mLocation = ConversionTool.LatLongFromUnityVector3D(transform.position);
        mFaction = faction;
        locString = mLocation.ToMGRSRef().ToString();
    }
    private void Start()
    {
        myTransform = myTransform = gameObject.GetComponent<Transform>();
    }
    void Update()
    {
        transformString = myTransform.position.x.ToString() + "," + myTransform.position.y.ToString();
        mLocation = ConversionTool.LatLongFromUnityVector3D(myTransform.position);
        locString = mLocation.ToString();
       
    }

    public string ToSaveString()
    {
        string saveString =
             mAgentName + "," +
             mAgentSerial + "," +
             mLocation+ ","+
             mFaction;
        return saveString;
    }
    public LatLng getLatLong()
    {
        return mLocation = ConversionTool.LatLongFromUnityVector3D(transform.position);
    }
    public string getMGRSString()
    {
        return getLatLong().ToMGRSRef().ToString();
    }

    public void setNavTarget (WayPoint setNavPoint)
    {
        mNavTarget = setNavPoint;
    }
}
