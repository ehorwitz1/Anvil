using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFloatingElements : MonoBehaviour {
    private Camera cam;
    private AnvilAgent activeAgent;
    private WayPoint activeWayPoint;
    public Texture highlighter;
    public Texture boxReticle;
    public int xTweak;
    public int yTweak;
    public int sizeX;
    public int sizeY;

    void Start()
    {
        cam = Camera.main;
        xTweak = 10;
        yTweak = 10;
        sizeX = 100;
        sizeY = 50;
    }

    public static Vector3 ScreenPointFromTansform(Vector3 unityPositionVector3D)
    {
        Camera thisCamera = Camera.main;
        Vector3 screenPos = thisCamera.WorldToScreenPoint(unityPositionVector3D);

        return screenPos;
    }
    private void OnGUI()
    {
        //TODO build precheck code to verify active agent not null
        if (activeAgent != null)
        {
            DrawAgentCursor();
        }
    }

    private void DrawAgentCursor()
    {
        int reticleSize = 30;
        activeAgent = GetComponent<UserControlScript>().selectedAgent;
        Vector3 screenPosition = ScreenPointFromTansform(activeAgent.transform.position);
        Rect screenCoordRect = new Rect(screenPosition.x + -(reticleSize / 2), Screen.height - screenPosition.y + -(reticleSize / 2), reticleSize, reticleSize);
        GUI.DrawTexture(screenCoordRect, highlighter);
    }

    private void DrawWayPointCursor()
    {
        int reticleSize = 30;
        activeWayPoint = GetComponent<UserControlScript>().activeWayPoint;
        Vector3 screenPosition = ScreenPointFromTansform(activeAgent.transform.position);
        Rect screenCoordRect = new Rect(screenPosition.x + -(reticleSize / 2), Screen.height - screenPosition.y + -(reticleSize / 2), reticleSize, reticleSize);
    
        GUI.DrawTexture(screenCoordRect, boxReticle);
    }


}
