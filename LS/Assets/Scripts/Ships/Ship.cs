using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    [Header("Ship Stats")]
    // Speed in which the ship can move
    public float Speed;
    // Speed in which the ship can turn
    public float TurnSpeed;
    // The ship's maximum amount of health
    public int MaxHealth;
    // The current health of the ship
    public float CurrentHealth;
    // The health of the ship's shields (Which protect the ship's health)
    public float Shields;

    // Spawns when Ship dies
    public GameObject Smoke;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
