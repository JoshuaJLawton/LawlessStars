using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Ship
{
    public GameObject LootPF;

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
                Instantiate(Explosion, new Vector3(Other.transform.position.x, Other.transform.position.y, 0f), Other.transform.rotation);
                Destroy(Other.gameObject);
                CurrentHealth = CurrentHealth - Other.GetComponent<ProjectileController>().Damage;

                // TEMP
                float interpolation = - 4 * Time.deltaTime;

                Vector3 Position = this.transform.position;
                Position.x = Mathf.Lerp(this.transform.position.x, Other.GetComponent<ProjectileController>().Owner.transform.position.x, interpolation);
                Position.y = Mathf.Lerp(this.transform.position.y, Other.GetComponent<ProjectileController>().Owner.transform.position.y, interpolation);

                this.transform.position = Position;
                //

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
        Instantiate(Smoke, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        int count = Random.Range(1,5);
        while (count > 0)
        {
            Instantiate(LootPF, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
            count--;
        }
        Destroy(this.gameObject);
    }

}
