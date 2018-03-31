using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SimpleTextFileManager : MonoBehaviour {

    private GameObject blackBoard;
   

    private void Start()
    {
        blackBoard = GameObject.Find("Blackboard");
    }
    public void SaveWayPointFile()
    {
        List<WayPoint> allWayPoints =  (blackBoard.GetComponent<BlackBoardScript>().allGameWayPoints);
        string timeString = DateTime.Now.ToString("yyMMddHHMMss");
        string path = "Assets/Resources/Saves/" + timeString + ".txt";
        StreamWriter writer = new StreamWriter(path);

        foreach (WayPoint thisPoint in allWayPoints)
        {
            string output = thisPoint.ToString();
            writer.WriteLine(output);
        }
        writer.Close();
    }
}
