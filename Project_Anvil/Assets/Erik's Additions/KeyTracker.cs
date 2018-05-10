using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTracker : MonoBehaviour {

	//This keeps track of what we want to select
	public int menuPoint = 3;

	CameraController cameraMove;

	public bool selection;

	//These are the buttons
    private UnityEngine.UI.Button settingButton;
	private UnityEngine.UI.Button playerButton;
	private UnityEngine.UI.Button waypointButton;
	private UnityEngine.UI.Button mapButton;

	//These hold the GUI panels to turn on or off
	private GameObject mainMenuPanel;
	private GameObject agentPanel;
	private GameObject routePanel;
	private GameObject debugPanel;
	



	void Start () {
		selection = false;
	    cameraMove = GetComponent(typeof(CameraController)) as CameraController;

		//Assigns all the panels
		getPanels();
		getButtons ();

	}
	
	// Update is called once per frame
	void Update () {
		checkMenuPoint ();
		checkCameraMove ();


	
		getInput ();
		


		checkSelected ();

		switch (menuPoint)
		{
		case 0:
			//Code for other menu
			break;
		case 1:
			//Code for other menu
			if(selection==true)
			{
			uiPicker(menuPoint);
			//agentUI();
			}
			break;
		case 2:
			//Code for other menu
			if(selection==true)
			{
			uiPicker(menuPoint);
			//waypointUI();
			}
			break;
		case 3:
			if (cameraMove.setSelect && selection==true) {
				uiPicker(menuPoint);
				//mapUI();
				cameraMove.mapMove ();
			}

			break;
		}
			
	}


	//This assigns all of the button features
	public void getButtons()
	{
		settingButton = GameObject.Find ("Setting").GetComponent<UnityEngine.UI.Button> ();
		playerButton =  GameObject.Find ("Player Actions").GetComponent<UnityEngine.UI.Button> ();
		waypointButton = GameObject.Find ("Waypoint Actions").GetComponent<UnityEngine.UI.Button> ();
		mapButton = GameObject.Find ("Map Control").GetComponent<UnityEngine.UI.Button> ();
	}


	//This allows the jump from map to settings and settings to map
	public void checkMenuPoint()
	{
		if (menuPoint > 3 ) {
			menuPoint = 0;
		} 
		else if (menuPoint < 0) {
			menuPoint = 3;
		}
	}

	//This handles the highlighting when using wasd
	public void checkSelected()
	{
		if (menuPoint == 0) {
			settingButton.OnSelect (null);
			playerButton.OnDeselect (null);
			waypointButton.OnDeselect (null);
			mapButton.OnDeselect (null);
		}
		else if (menuPoint == 1){
			playerButton.OnSelect (null);
			settingButton.OnDeselect (null);
			waypointButton.OnDeselect (null);
			mapButton.OnDeselect (null);
		}
		else if (menuPoint == 2){
			waypointButton.OnSelect (null);
			settingButton.OnDeselect (null);
			playerButton.OnDeselect (null);
			mapButton.OnDeselect (null);
		}
		else if (menuPoint == 3){
			mapButton.OnSelect (null);
			settingButton.OnDeselect (null);
			waypointButton.OnDeselect (null);
			playerButton.OnDeselect (null);
		}
	}



	public void checkCameraMove()
	{
		if (menuPoint == 3) {
			cameraMove.setSelect = true;
		} else {
			cameraMove.setSelect = false;
		}
	}


	//These are for the buttons to for clicking/touchscreen
	public void selectMap()
	{
		menuPoint = 3;
		selection = true;
		Debug.Log ("Map Selected");
		uiPicker(3);
		//mapUI();

	}

	public void selectWaypoints()
	{
		menuPoint = 2;
		uiPicker(2);
		Debug.Log ("Waypoints selected");
	}

	public void selectPlayer()
	{
		menuPoint = 1;
		//agentUI();
		uiPicker(1);
		Debug.Log ("Player selected");
	}

	public void selectSetting()
	{
		menuPoint = 0;
		Debug.Log ("Setting selected");
	}

	//This is for controlling the main selection
	public void getInput()
	{
		if (selection==false) {
		if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			Debug.Log (menuPoint);
			menuPoint--;
		}
		if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			Debug.Log (menuPoint);
			menuPoint++;
		}

		if (Input.GetKeyDown (KeyCode.C))
		{
			if (selection == false) {
				selection = true;
			} else {
				selection = false;
			}

			Debug.Log ("Setting selection" + selection);
		}
		}
	   
		if (Input.GetKeyDown (KeyCode.B))
		{
			if (selection == true) {
				selection = false;
			} else {
				selection = true;
			}

	
			cameraMove.setSelect = false;
			mainMenuUI();

			
		}
		

	}


	public void uiPicker(int pick)
	{
		switch (pick)
		{
		case 0:
			//Code for other menu
			break;
		case 1:
			//Code for other menu
			agentUI();
			break;
		case 2:
			//Code for other menu
			waypointUI();
			break;
		case 3:
				mapUI();
			break;
		}
	}

	public void mainMenuUI()
	{
		mainMenuPanel.gameObject.SetActive(true);
		agentPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
	}

	public void mapUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
	}

	public void agentUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(true);
		routePanel.gameObject.SetActive(false);
		debugPanel.gameObject.SetActive(false);
	}

	public void waypointUI()
	{
		mainMenuPanel.gameObject.SetActive(false);
		agentPanel.gameObject.SetActive(false);
		routePanel.gameObject.SetActive(true);
		debugPanel.gameObject.SetActive(false);
	}



	public void getPanels()
	{
		mainMenuPanel = GameObject.Find("Menu Panel");
		agentPanel = GameObject.Find("AgentPanel");
		routePanel = GameObject.Find("RoutePanel");
		debugPanel = GameObject.Find("DebugBlackboard");
	}

}
