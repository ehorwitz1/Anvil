using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

// Use physics raycast hit from mouse click to set agent destination
[RequireComponent(typeof(NavMeshAgent))]
public class AIMove : MonoBehaviour
{
    enum Mode { execute, route };
    NavMeshAgent m_Agent;
    RaycastHit m_HitInfo;
    Mode inputMode;
    List<Vector3> route;
    int routeIndex;

    void Start(){
        m_Agent = GetComponent<NavMeshAgent>();
        m_HitInfo = new RaycastHit();
        inputMode = Mode.execute;
        route = new List<Vector3>();
        routeIndex = 0;
    }


    // route mode lets user create a route, off executes the route
    void Update(){
        // Mode: Route
        if( inputMode == Mode.route ){
            if ( Input.GetMouseButtonDown(0) )
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    route.Add( m_HitInfo.point );
            }
        }
        // Mode: off
        if( inputMode == Mode.execute ){
            if( reachedDest() ){ 
                if( !(routeIndex >= route.Count - 1) ){
                    routeIndex++;
                    m_Agent.destination = route[routeIndex];
                }
            }
        }
    }

    bool reachedDest(){
        if (!m_Agent.pathPending)
        {
            if (m_Agent.remainingDistance <= m_Agent.stoppingDistance)
            {
                if (!m_Agent.hasPath || m_Agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    void OnGUI(){
        if( inputMode == Mode.execute ){
            if ( GUI.Button(new Rect(10, 10, 100, 40), "Mode: execute") ){
                inputMode = Mode.route;
            }
        }
        else if( inputMode == Mode.route ){
            if ( GUI.Button(new Rect(10, 10, 100, 40), "Mode: route") ){
                inputMode = Mode.execute;
            } 
        }
    }
}
