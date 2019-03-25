using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour {

    public int Rand;

	// Use this for initialization
	void Start ()
    {
        Rand = Random.Range(1, 360);
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, Rand * Time.deltaTime));
        transform.Translate(new Vector3(0, -2.5f * Time.deltaTime, 0));
    }
}
