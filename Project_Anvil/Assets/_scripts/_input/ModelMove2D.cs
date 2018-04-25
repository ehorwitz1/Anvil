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
	private float playerVelocity = 0f;
	public float maxSpeed;
	public float acceleration;
	private float step = 0f;

	private float OriginalDistanceBetween = 0;
	private float CurrentDistanceBetween = 0;
	private float Halfway = 0;
	private float Third = 0;
	private bool firstTime = true;


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

		if(firstTime && (targetPoint != transform.position))
		{
			OriginalDistanceBetween = Vector3.Distance(transform.position, targetPoint);
			Halfway = OriginalDistanceBetween / 2;
			Third = OriginalDistanceBetween / 3;
			Debug.Log("Original: " + OriginalDistanceBetween);
			Debug.Log("Halfway: " + Halfway);
			firstTime = false;
		}

		CurrentDistanceBetween = Vector3.Distance(transform.position, targetPoint);

		if (isSelected & move & (transform.position != targetPoint)) {
			//transform.position = Vector3.Lerp (transform.position, targetPoint, Time.deltaTime * 2.0f); 
			if (CurrentDistanceBetween >= Halfway)
			{
				//Debug.Log("Speeding up!");
				playerVelocity += acceleration;
				if (playerVelocity >= maxSpeed)
				{
					playerVelocity = maxSpeed;
				}
			}
			else if((CurrentDistanceBetween < Halfway) && (CurrentDistanceBetween > Third))
			{
				//Debug.Log("Slowing Down!");
				playerVelocity -= acceleration;
				if (playerVelocity <= maxSpeed * 0.75f)
				{
					playerVelocity = maxSpeed * 0.75f;
				}
			}
			else
			{
				//Debug.Log("Slowing Down!");
				playerVelocity -= acceleration;
				if (playerVelocity <= maxSpeed / 2)
				{
					playerVelocity = maxSpeed / 2;
				}
			}
			step = playerVelocity * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
		} 
		else if(transform.position == targetPoint)
		{
			playerVelocity = 0f;
			step = 0f;
			firstTime = true;
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