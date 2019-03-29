using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship {

    Rigidbody2D RB;
    private float Turn;

    public GameObject LaserPF;

    int Damage = 10;

    public int Digits;
    public int Inventory;
    public int CargoHold;

    // Use this for initialization
    void Start ()
    {
        CurrentHealth = 50;
        Digits = 0;
        Inventory = 0;
        CargoHold = 20;

        RB = this.GetComponent<Rigidbody2D>();
        Speed = 5;
        TurnSpeed = 5;
	}

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        HasHealth();
    }

    void PlayerControls()
    {
        // Rotate Ship
        Turn = (UnityEngine.Input.GetAxisRaw("Horizontal") * -TurnSpeed);
        transform.Rotate(0, 0, Turn);
        // Move Forward
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, - Speed * Time.deltaTime, 0));
        }
        // Fire Laser
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject Laser = Instantiate(LaserPF, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
            Laser.GetComponent<ProjectileController>().Damage = Damage;
            Laser.GetComponent<ProjectileController>().Owner = this.gameObject;
        }
    }


    void HasHealth()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        switch (Other.gameObject.tag)
        {
            case "Laser":
                if (Other.GetComponent<ProjectileController>().Owner != this.gameObject)
                {
                    GameObject Explosion = Other.GetComponent<ProjectileController>().Explosion;
                    Instantiate(Explosion, new Vector3(Other.transform.position.x, Other.transform.position.y, 0f), Other.transform.rotation);
                    Destroy(Other.gameObject);
                    CurrentHealth = CurrentHealth - Other.GetComponent<ProjectileController>().Damage;
                }
                break;

            case "Cargo":
                if (Inventory < CargoHold)
                {
                    Inventory++;
                    Destroy(Other.gameObject);
                }
                break;
        }
    }

}
