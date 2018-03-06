using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class UIClock : MonoBehaviour
{

    public string timeText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeText = DateTime.Now.ToString();
    }
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width - 300, 10, 300, 20), "Date/Time: " + timeText);
    }
}