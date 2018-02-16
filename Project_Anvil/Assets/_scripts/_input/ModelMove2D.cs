using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script must be attached to the models

public class ModelMove2D : MonoBehaviour {

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
		if (isSelected & move) {
			transform.position = Vector3.Lerp (transform.position, targetPoint, Time.deltaTime * 2.0f); 
		} 

		else {
			targetPoint = transform.position;
		}
	}

	public void OnSelect(Transform theTarget, string selectedName){
		Debug.Log("okay");
		if(!isSelected){
			hoverText = Instantiate(textPrefab, new Vector3 (theTarget.position.x,
																theTarget.position.y,
																theTarget.position.z + 2), Quaternion.identity);
			hoverText.transform.parent = theTarget;
			hoverText.GetComponent<TextMesh>().text = selectedName;
			hoverText.transform.Rotate(new Vector3(90,0,0));
			isSelected = true;
		} else {
			Destroy(hoverText);
			isSelected = false;
		}
	}

	public void MoveToPoint(Vector3 point){
		Debug.Log("the point is " + point);
		targetPoint = point;
		//targetPoint.y += 2;
		move = true;
	}
}