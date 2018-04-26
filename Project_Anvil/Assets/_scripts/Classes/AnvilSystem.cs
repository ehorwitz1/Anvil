using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilSystem {
    private bool powerOn;
    private bool emitterOn;
    private bool mortal;
    private int systemHealth;
    private bool armed; // need to disambiguate Arming as Weapons Condition vs ESAF later
    public WayPoint targetLocation;
    public AnvilAgent targetAgent;
    public AnvilSystem targetSystem;
    public AnvilWeapon onBoardWeapon;
    private float facingDirection;
    private float weaponDirection;
    private float weaponElevation;
    private float maxspeed;
    
    // future features 
    // List of Passengers (anvilagents)
    // List of subcomponents
	// List of cargo systems
        // Use this for initialization

	void Start () {
        systemHealth = 100;
        armed = true;
        powerOn = true;
        emitterOn = true;
        mortal = true;


    }
	
	// Update is called once per frame
	void Update () {
		if (targetAgent ==null && targetSystem == null)
        {
            weaponDirection = facingDirection;
            weaponElevation = 0;
        }
	}
}
