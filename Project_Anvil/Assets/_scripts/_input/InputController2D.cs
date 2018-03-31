using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// only works with one model for now
// model must have tag of "Model" for it to respond to the raycasts

public class InputController2D : MonoBehaviour
{
    bool showRoutes = false;
    bool isSelected = false;
    bool displayCheckpointList = false;
    bool displayRouteList = false;
    Plane myPlane;
    Vector3 targetPoint;
    public ModelMove2D ModelMove2D;
    public RouteDisplay routeDisplay;
    public CameraZoom cameraZoom;
    int i = 0;


    // Use this for initialization
    void Start()
    {
        myPlane = new Plane(Vector3.up, transform.position);
        cameraZoom = Camera.main.gameObject.GetComponent<CameraZoom>();
        routeDisplay = GameObject.Find("UIRoute").GetComponent<RouteDisplay>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            { // get the object using a raycast
                if (hit.transform.name == "MapHitDetector")
                { // if statement to move object, assuming it is selected
                    float hitDist;
                    if (myPlane.Raycast(ray, out hitDist))
                    {
                        targetPoint = ray.GetPoint(hitDist);
                        Debug.Log(targetPoint);
                        if (ModelMove2D != null)
                        {
                            ModelMove2D.MoveToPoint(targetPoint);
                        }
                    }
                }
                else if (hit.transform.tag == "Model" || hit.transform.tag == "ModelAir")
                { // if statement to select model objects
                    ModelMove2D = hit.transform.gameObject.GetComponent<ModelMove2D>();
                    if (!isSelected)
                    {
                        isSelected = true;
                        string selectedName;
                        Transform theTarget;
                        selectedName = hit.collider.name;
                        theTarget = hit.transform;
                        ModelMove2D.OnSelect(theTarget, selectedName);
                    }
                    else
                    {
                        string selectedName;
                        Transform theTarget;
                        selectedName = hit.collider.name;
                        theTarget = hit.transform;
                        ModelMove2D.OnSelect(theTarget, selectedName);
                        ModelMove2D = null;
                        isSelected = false;
                    }
                }
            }
        }
    }
    

    void OnGUI()
    {
        if (!displayCheckpointList && !displayRouteList)
        {
            if (GUI.Button(new Rect(10, 200, 200, 50), "show checkpoints"))
            {
                // TODO: get checkpoints for selected unit. 
                displayCheckpointList = true;
                i = 0;
            }
            if (GUI.Button(new Rect(10, 300, 200, 50), "display routes"))
            {
                // TODO: Get route from selected unit. hopefully a list of Vector3 points
                // for now just use dummy values

                if (showRoutes == false)
                {
                    List<Vector3> dummyList = new List<Vector3>();
                    dummyList.Add(new Vector3(5, 4, 3));
                    dummyList.Add(new Vector3(15, 4, 13));
                    dummyList.Add(new Vector3(12, 4, 1));
                    routeDisplay.Show(dummyList);
                    showRoutes = true;
                } else
                {
                    routeDisplay.Hide();
                    showRoutes = false;
                }
            }
            //if (GUI.Button(new Rect(10, Screen.height - 50, 100, 50), "ZOOM IN"))
            //{
            //    cameraZoom.ZoomIn();
            //}
            //if (GUI.Button(new Rect(115, Screen.height - 50, 100, 50), "ZOOM OUT"))
            //{
            //    cameraZoom.ZoomOut();
            //}

        }
        if (displayCheckpointList)
        {
            if (GUI.Button(new Rect(10,10, 100, 100), "Return to Map"))
            {
                displayCheckpointList = false;
            }

            // TODO: update for checking bounds and using a list of checkpoints once we have them.
            if (GUI.Button(new Rect(Screen.width / 2 + 5, Screen.height - 100, (Screen.width / 2) - 5, 100), "next"))
            {
                i++;
            }
            if (GUI.Button(new Rect(10, Screen.height - 100, (Screen.width / 2) - 5, 100), "back"))
            {
                i--;
            }

            // using a button to display the checkpoint. clicking the button selects the checkpoint and
            // will show on the map.
            if (GUI.Button(new Rect(Screen.width / 4, Screen.height / 2, Screen.width / 2, Screen.height / 8),
                "This is checkpoint: #" + i))
            {
                // TODO: select the checkpoint shown (show checkpoint on map).
            }
        }
    }
}