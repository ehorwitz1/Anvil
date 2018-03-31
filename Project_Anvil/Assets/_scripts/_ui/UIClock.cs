using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIClock : MonoBehaviour
{

    public Text timeText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = DateTime.UtcNow.ToString("yyyy-MM-ddT") + "\n" + DateTime.UtcNow.ToString("HH:mm:ss") + "/Z";
    }
    //void OnGUI()
    //{
    //    GUI.Label(new Rect(Screen.width - 300, 10, 300, 20), "Date/Time: " + timeText);
    //}
}