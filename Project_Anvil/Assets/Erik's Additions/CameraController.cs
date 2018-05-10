using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {



	public float speed = 1f;
	public float zoomSpeed = 5f;
	public bool setSelect;


	private Transform target;
	public GameObject mainCamera;

	KeyTracker keyTracker;

	UnityEngine.UI.Button button; 

	public CameraZoom cameraZoom;

	public GameObject UIelements;

	public GameObject mainMenuPanel;


	void Start () {
		//target = GameObject.FindWithTag ("Player").transform;
		keyTracker = GetComponent(typeof(KeyTracker)) as KeyTracker;
		cameraZoom = Camera.main.gameObject.GetComponent<CameraZoom>();
		mainMenuPanel = GameObject.Find("Menu Panel");
	}

	void FixedUpdate () {


	}

	public void mapMove()
	{
	//	target = GameObject.FindGameObjectWithTag ("Player").transform;

		getDirection ();
		getButtons ();

	}


	public void getDirection()
	{
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow))
		{
			mainCamera.transform.Translate( Time.deltaTime * speed, 0 , 0);
		}
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow)) 
		{
			mainCamera.transform.Translate(-(Time.deltaTime * speed), 0, 0);
		}
		if (  Input.GetKey(KeyCode.W)  || Input.GetKey(KeyCode.UpArrow)) 
		{
			mainCamera.transform.Translate(0, Time.deltaTime * speed, 0);
		}
		else if ( Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
		{
			mainCamera.transform.Translate(0, -(Time.deltaTime * speed), 0);
		}
	}

	public void getButtons()
	{
		if (Input.GetKey(KeyCode.Plus) || Input.GetKey(KeyCode.Equals)) 
		{
			//mainCamera.transform.Translate( 0, 0 , Time.deltaTime * zoomSpeed);
			cameraZoom.ZoomIn();
		}
		if (Input.GetKey(KeyCode.Minus)) 
		{
			//mainCamera.transform.Translate( 0, 0 , -(Time.deltaTime * zoomSpeed));
			cameraZoom.ZoomOut();
		}


		if (Input.GetKeyDown (KeyCode.C)) 
		{
			Debug.Log ("Center was pressed");
			//transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);

		}
	 
		if (Input.GetKeyDown (KeyCode.B)) {
			
			//setSelect = false;
			keyTracker.selection = false;
			mainMenuPanel.gameObject.SetActive(true);
			//keyTracker.menuPoint++;
			//Debug.Log ("B was pressed" + keyTracker.selection);

			

		}
		
	}

}
