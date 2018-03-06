using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// place this script on a camera and then zooming becomes a breeze.

public class CameraZoom : MonoBehaviour
{

    bool zoom = false;
    float currentTime = 2.5f;
    float timeToMove = 1.0f;
    float camSize;
    float newCamSize;
    Camera myCam;

    // Use this for initialization
    void Start()
    {
        myCam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zoom)
        {
            if (currentTime <= timeToMove)
            {
                currentTime += Time.deltaTime;
                myCam.orthographicSize = Mathf.Lerp(camSize, newCamSize, currentTime / timeToMove);
            }
        }
    }

    public void ZoomIn()
    {
        zoom = true;
        currentTime = 0f;
        camSize = myCam.orthographicSize;
        newCamSize = myCam.orthographicSize - 2;
    }
    public void ZoomOut()
    {
        zoom = true;
        currentTime = 0f;
        camSize = myCam.orthographicSize;
        newCamSize = myCam.orthographicSize + 2;
    }
}
