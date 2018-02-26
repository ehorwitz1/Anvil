using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAirUnitDisplay : MonoBehaviour {

    bool isVisible = false;
    Vector3 cameraTarget;
    Vector3 navTarget;
    float altitude;
    float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // Function: ShowUI
    // changes the value of the isVisible boolean and sets the info for the Air unit UI
    public void ShowUI(Vector3 _cameraTarget, Vector3 _navTarget, float _altitude, float _speed)
    {
        isVisible = true;
        cameraTarget = _cameraTarget;
        navTarget = _navTarget;
        altitude = _altitude;
        speed = _speed;
    }

    public void HideUI()
    {
        isVisible = false;
    }

    void OnGUI(){
        if (isVisible)
        {

            GUI.Label(new Rect(10, 70, 300, 20), "Camera Target: " + cameraTarget);
            GUI.Label(new Rect(10, 120, 300, 20), "navigation Target: " + navTarget);
            GUI.Label(new Rect(10, 170, 300, 20), "Altitude: " + altitude);
            GUI.Label(new Rect(10, 220, 300, 20), "speed: " + speed);
        }
    }
}
