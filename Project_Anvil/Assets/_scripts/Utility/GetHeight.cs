using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Map;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.MeshGeneration.Data;

public class GetHeight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public double HeightForPrefab(double lat, double lon, BasicMap _map)
    {
        //get tile ID
        Debug.Log("lat: " + lat + ", long: " + lon);
        var tileIDUnwrapped = TileCover.CoordinateToTileId(new Mapbox.Utils.Vector2d(lat, lon), 15);
        Debug.Log(tileIDUnwrapped);
        //get tile
        UnityTile tile = _map._mapVisualizer.GetUnityTileFromUnwrappedTileId(tileIDUnwrapped);

        //lat lon to meters because the tiles rect is also in meters
        Vector2d v2d = Conversions.LatLonToMeters(new Mapbox.Utils.Vector2d(lat, lon));
        //get the origin of the tile in meters
        Vector2d v2dcenter = tile.Rect.Center - new Mapbox.Utils.Vector2d(tile.Rect.Size.x / 2, tile.Rect.Size.y / 2);
        //offset between the tile origin and the lat lon point
        Vector2d diff = v2d - v2dcenter;

        //maping the diffetences to (0-1)
        float Dx = (float)(diff.x / tile.Rect.Size.x);
        float Dy = (float)(diff.y / tile.Rect.Size.y);

        //height in unity units
        var h = tile.QueryHeightData(Dx, Dy);

        //lat lon to unity units
        Vector3 location = Conversions.GeoToWorldPosition(lat, lon, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        //replace y in position
        location = new Vector3(location.x, h, location.z);
        Debug.Log("our height is: " + h);
        return h;
    }
}
