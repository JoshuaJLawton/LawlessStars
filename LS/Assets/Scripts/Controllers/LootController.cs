using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour {

    Rigidbody2D RB;
    float Direction, Force;

    // Use this for initialization
    void Start ()
    {
        RB = this.GetComponent<Rigidbody2D>();
        Direction = Random.Range(-20, 20);
        Force = Random.Range(-20f, 20f);
        RB.AddForce(new Vector2(Direction, Force));
    }
	
	// Update is called once per frame
	void Update ()
    {
        Rotate();
	}

    void Rotate()
    {
        RB.transform.Rotate(0, 0, (Force * 1) - 5);
    }

}
