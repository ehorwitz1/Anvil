using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAIDest : MonoBehaviour {

	InputController2D InputController2D;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// function: Show
	// is triggered by a button click in the editor and will display the destination
	// of the currently selected model.
	public void Show(){
		// Get the selected models destination and display it.
		Debug.Log("Reveal the selected AIs destination");
	}
}
