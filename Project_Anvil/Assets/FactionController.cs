using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionController : MonoBehaviour {
    public List<Route> factionRouteList;
    public List<Route> allWayPoints;
    public List<AnvilAgent> factionAgentList;
    public List<WayPoint> allWayPointsList;

	// Use this for initialization
	void Start () {
        factionRouteList = new List<Route>();
        WayPoint waypointA0 = new WayPoint(36.58386, -121.83619, 200, "KM01");
        WayPoint waypointA1 = new WayPoint(36.58951, -121.85216, 157, "KM02");
        WayPoint waypointA2 = new WayPoint(36.58951, -121.85216, 157, "KM03");
        WayPoint waypointB0 = new WayPoint(36.58951, -121.85216, 157, "KM04");
        WayPoint waypointB1 = new WayPoint(36.58951, -121.85216, 157, "KM05");
        WayPoint waypointB2 = new WayPoint(36.58951, -121.85216, 157, "KM06");


        List<WayPoint> routeAList = new List<WayPoint> { waypointA0, waypointA1, waypointA2 };
        List<WayPoint> routeBList = new List<WayPoint> { waypointB0, waypointB1, waypointB2 };
        List<WayPoint> routeCList = new List<WayPoint> { waypointB2, waypointB1, waypointA1 };
        List<WayPoint> wayPointList = new List<WayPoint> ();
        wayPointList.Add(waypointA0);
        wayPointList.Add(waypointA1);
        wayPointList.Add(waypointA2);
        wayPointList.Add(waypointB0);
        wayPointList.Add(waypointB1);
        wayPointList.Add(waypointB2);

        Route routeA = new Route ("routeA", routeAList);
        Route routeB = new Route ("routeB", routeBList);
        Route routeC = new Route("routeC", routeCList);
        Route allRoutes = new Route("allPoints", wayPointList);//this is a workaround to show all waypoints from all routes.
        allWayPointsList = wayPointList;
        
        factionRouteList = new List<Route>();
        factionRouteList.Add(allRoutes);
        factionRouteList.Add(routeA);
        factionRouteList.Add(routeB);
        factionRouteList.Add(routeC);

        factionAgentList = new List<AnvilAgent>(gameObject.GetComponentsInChildren<AnvilAgent>());


    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
