using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script must be attached to the models
// if it is an air unit, the Tag must be set to ModelAir for correct behaviour, other wise
// set it to Model

public class ModelMove2D : MonoBehaviour {

	Vector3 offset;
	GameObject textPrefab;
	GameObject hoverText;
	bool move = false;
	bool isSelected = false;
    public bool isAirUnit = false;
	Vector3 targetPoint;
    float speed = 7.0f;
	public UIAirUnitDisplay uiAirUnitDisplay;

	// Variables for a more complex movement involving acceleration
	private double currentSpeed = 0;
	public double maxSpeed;
	public double acceleration;


    // Use this for initialization
    void Start () {
		offset = Vector3.up;
		textPrefab = Resources.Load("PrefabText") as GameObject;
        if (gameObject.tag == "ModelAir")
        {
            isAirUnit = true;
            uiAirUnitDisplay = GameObject.Find("UIAirUnit").transform.gameObject.GetComponent<UIAirUnitDisplay>();
        }
	}

	// Update is called once per frame
	void Update () {
		if (isSelected & move) {
			//transform.position = Vector3.Lerp (transform.position, targetPoint, Time.deltaTime * 2.0f); 
			while(currentSpeed < maxSpeed)
			{
				currentSpeed = maxSpeed + acceleration * Time.deltaTime;
			}
			transform.position = transform.position + 
		} 

		else {
			targetPoint = transform.position;
		}
	}

    // Function OnSelect:
    // takes the Transfrom of the selected object and the name of the object.
    // instantiates a hover text on the selected object. and if the object is an air unit
    // will begin displaying the needed ui elements for that
	public void OnSelect(Transform theTarget, string selectedName){
		if(!isSelected){
			hoverText = Instantiate(textPrefab, new Vector3 (theTarget.position.x,
																theTarget.position.y,
																theTarget.position.z + 2), Quaternion.identity);
			hoverText.transform.parent = theTarget;
			hoverText.GetComponent<TextMesh>().text = selectedName;
			hoverText.transform.Rotate(new Vector3(90,0,0));
			isSelected = true;
            if (isAirUnit)
            {
                StartCoroutine(UpdateUI());
            }
		} else {
            if (isAirUnit)
            {
                uiAirUnitDisplay.HideUI();
                StopAllCoroutines();
            }
			Destroy(hoverText);
			isSelected = false;
		}
	}

    // IEnumerator UpdateUI
    // sends the cameratarget, navtarget, Altitude, and speed to the UI element for display every half second
    IEnumerator UpdateUI()
    {
        uiAirUnitDisplay.ShowUI(targetPoint, targetPoint, gameObject.transform.position.y,
                       speed);
        yield return new WaitForSeconds(.5f);
        StartCoroutine(UpdateUI());

    }

    // Function MoveToPoint 
    // Takes a Vector3 and initiates the movement of this model to that Vector3
	public void MoveToPoint(Vector3 point){
		targetPoint = point;
        targetPoint.y = 1.53f;
        move = true;
	}
}