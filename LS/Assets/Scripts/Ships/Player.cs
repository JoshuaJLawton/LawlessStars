using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship {

    Rigidbody2D RB;
    private float Turn;

    public GameObject LaserPF;

    int Damage = 10;

    public int Inventory = 0;
    public int CargoHold;

    // Use this for initialization
    void Start ()
    {
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
            GameObject Laser = Instantiate(LaserPF, new Vector3(this.transform.position.x, this.transform.position.y, 1f), this.transform.rotation);
            Laser.GetComponent<ProjectileController>().Damage = Damage;
            Laser.GetComponent<ProjectileController>().Owner = this.gameObject;
        }
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        switch (Other.gameObject.tag)
        {
            case "Laser":
                if (Other.GetComponent<ProjectileController>().Owner != this.gameObject)
                {
                    Debug.Log("LASER");
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
