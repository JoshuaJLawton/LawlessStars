using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

    private Animator Anim;
    private int Rand;
    private bool Twinkled;
    
	// Use this for initialization
	void Start ()
    {
        Anim = this.GetComponent<Animator>();
        Twinkled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!Twinkled)
        {
            StartCoroutine(Twinkle());
        }
        
    }

    IEnumerator Twinkle()
    {
        Twinkled = true;
        Rand = Random.Range(3, 10);
        yield return new WaitForSeconds(Rand);
        Anim.Play("Star", 0, 0);
        Twinkled = false;
    }
}
