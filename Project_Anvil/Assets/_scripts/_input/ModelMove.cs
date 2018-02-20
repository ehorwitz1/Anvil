using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script must be attached to the models

public class ModelMove : MonoBehaviour {
	
	Vector3 offset;
	GameObject textPrefab;
	GameObject hoverText;
	bool move = false;
	bool isSelected = false;
	Vector3 targetPoint;

	// Use this for initialization
	void Start () {
		offset = Vector3.up;
		textPrefab = Resources.Load("PrefabText") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			targetPoint.y = transform.position.y;
			transform.position = Vector3.Lerp (transform.position, targetPoint, Time.deltaTime * 2.0f); 
		}

	}

	public void OnSelect(Transform theTarget, string selectedName){
		if(!isSelected){
	    	hoverText = Instantiate(textPrefab, new Vector3 (theTarget.position.x + 2,
															 theTarget.position.y,
															 theTarget.position.z), Quaternion.identity);
			hoverText.transform.parent = theTarget;
			hoverText.GetComponent<TextMesh>().text = selectedName;
			isSelected = true;
		} else {
			Destroy(hoverText);
			isSelected = false;
		}
    }

    public void MoveToPoint(Vector3 point){
    	Debug.Log("the point is " + point);
    	targetPoint = point;
        targetPoint.y = 1.53f;
    	move = true;
	}
}