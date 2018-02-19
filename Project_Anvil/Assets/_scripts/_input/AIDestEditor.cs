using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ShowAIDest))]
public class AIDestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ShowAIDest myScript = (ShowAIDest)target;
        if(GUILayout.Button("Show AI Destination"))
        {
            myScript.Show();
        }
    }
}