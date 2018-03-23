using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreen : MonoBehaviour {

    Camera camera2D;
    Camera camera3D;
    int mode = 0;


	// Use this for initialization
	void Start () {
        camera2D = GameObject.Find("Main Camera").GetComponent<Camera>();
        camera3D = GameObject.Find("SecondCamera").GetComponent<Camera>();
        camera3D.enabled = false;
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 50), "Camera View"))
        {
            ChangeViewMode();
        }
    }
    // ChangeViewMode //
    // cycles between 2d, 3d and split screen camera modes
    void ChangeViewMode()
    {
        if(mode == 0)
        {
            mode++;
            camera3D.enabled = true;
            camera2D.enabled = false;
        }
        else if(mode == 1)
        {
            mode++;
            camera3D.enabled = true;
            camera2D.enabled = true;
            camera3D.rect = new Rect(0, 0, .5f, 1);
            camera2D.rect = new Rect(.5f, 0, 1, 1);
        }
        else
        {
            mode = 0;
            camera3D.enabled = false;
            camera2D.enabled = true;
            camera3D.rect = new Rect(0, 0, 1, 1);
            camera2D.rect = new Rect(0, 0, 1, 1);
        }
    }
}
