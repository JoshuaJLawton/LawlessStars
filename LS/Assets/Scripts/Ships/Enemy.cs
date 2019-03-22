using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
	// Use this for initialization
	void Start ()
    {
        MaxHealth = 50;
        CurrentHealth = MaxHealth;

	}
	
	// Update is called once per frame
	void Update ()
    {
        HasHealth();
	}

    void OnTriggerEnter2D(Collider2D Other)
    {
        switch (Other.tag)
        {
            case "Laser":
                Debug.Log("LASER");
                GameObject Explosion = Other.GetComponent<ProjectileController>().Explosion;
                Instantiate(Explosion, new Vector3(Other.transform.position.x, Other.transform.position.y, -1f), Other.transform.rotation);
                Destroy(Other.gameObject);
                CurrentHealth = CurrentHealth - Other.GetComponent<ProjectileController>().Damage;
                break;
        }

    }

    void HasHealth()
    {
        if (CurrentHealth <= 0)
        {
            StartCoroutine(DestroyShip());
        }
    }

    IEnumerator DestroyShip()
    {
        Instantiate(Smoke, new Vector3(this.transform.position.x, this.transform.position.y, -1f), this.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

}
