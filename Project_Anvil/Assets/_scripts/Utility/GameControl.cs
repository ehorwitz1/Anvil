using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	void Awake () {
	
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != this) 
		{
			Destroy (gameObject);
		}
	}
	
	void OnGUI()
	{
		//OnGUI.Label(Put Lat long Data Here)
	}
}
