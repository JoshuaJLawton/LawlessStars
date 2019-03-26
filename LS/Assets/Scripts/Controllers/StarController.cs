using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    private Animator Anim;
    private int Rand;
    
	// Use this for initialization
	void Start ()
    {
        Anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //Anim.Play("Star", 0, 0);
        //}
        StartCoroutine(Twinkle());
    }

    IEnumerator Twinkle()
    {
        Rand = Random.Range(3, 10);
        yield return new WaitForSeconds(Rand);
        Anim.Play("Star", 0, 0);
    }
}
