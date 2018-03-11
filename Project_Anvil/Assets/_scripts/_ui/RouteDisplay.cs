using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouteDisplay : MonoBehaviour {
    
    public static int lengthOfLineRenderer = 20;
    LineRenderer lineRenderer;
    public Vector3[] points;

    // Use this for initialization
    void Start () {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.widthMultiplier = 0.2f;
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Show(List<Vector3> _points)
    {
        points = new Vector3[_points.Count];
        for (int i = 0; i < _points.Count; i++)
        {
            points[i] = _points[i];
        }
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = _points.Count;
        lineRenderer.SetPositions(points);
        lineRenderer.enabled = true;

    }
    public void Hide()
    {
        lineRenderer.enabled = false;
        points = null;
    }
}
