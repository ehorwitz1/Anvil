using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route {
    public string mRouteName;
    public Color mRouteColor;
    public bool hasHardTimeConstraint;
    public List<WayPoint> routeWayPoints = new List<WayPoint>();

    public Route (string routeName, List<WayPoint> wayPointList)
    {
        mRouteName = routeName;
        routeWayPoints = new List<WayPoint>(wayPointList);
    }

    public Route(string routeName,    Color color, List<WayPoint> wayPointList)
    {
        mRouteName = routeName;
        routeWayPoints = new List<WayPoint>(wayPointList);
        mRouteColor = color;
    }

    public int Count()
    {
    int numberOfPoints = routeWayPoints.Count;
    return numberOfPoints;
    }

    public Color GetColor()
    {
        if (mRouteColor != null)
        {
            return mRouteColor;
        }
        else { return Color.white; }
    }

    public List<WayPoint> returnWayPointList()
    {
        return routeWayPoints;
    }
}
