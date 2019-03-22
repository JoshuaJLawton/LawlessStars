using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public GameObject Owner;
    public GameObject Explosion;
    public float Damage;



    private Vector3 Velocity;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(DestroyProjectile());
    }
	
	// Update is called once per frame
	void Update ()
    {
        ForwardMotion();
	}

    void ForwardMotion()
    {
        transform.Translate(new Vector3(0, -20 * Time.deltaTime, 0));
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(1.75f);
        Destroy(this.gameObject);
    }
}
