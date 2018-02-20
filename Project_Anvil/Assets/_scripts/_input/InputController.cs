using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// only works with one model for now

public class InputController : MonoBehaviour {

	bool isSelected = false;
	Plane myPlane;
	Vector3 targetPoint;
	public ModelMove ModelMove;

	// Use this for initialization
	void Start () {
		myPlane = new Plane(Vector3.up, transform.position);

	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonUp(0)){
	    	RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){ // get the object using a raycast
				if (hit.transform.name == "MapHitDetector")
                { // if statement to move object, assuming it is selected
                    Debug.Log("3d input hit map");
                    float hitDist;
					if (myPlane.Raycast(ray, out hitDist)){
						targetPoint = ray.GetPoint(hitDist);
						Debug.Log(targetPoint);
						if(ModelMove != null){
							ModelMove.MoveToPoint(targetPoint);
						}
					}
				} else if (hit.transform.tag == "Model"){ // if statement to select model objects
						ModelMove = hit.transform.gameObject.GetComponent<ModelMove>();
					if(!isSelected){
						isSelected = true;
						string selectedName; 
						Transform theTarget;
						selectedName = hit.collider.name;
						theTarget = hit.transform;
						ModelMove.OnSelect(theTarget, selectedName);
					} else {
						string selectedName; 
						Transform theTarget;
						selectedName = hit.collider.name;
						theTarget = hit.transform;
						ModelMove.OnSelect(theTarget, selectedName);
						ModelMove = null;
						isSelected = false;
					}
				}
			}
        }
    }
}