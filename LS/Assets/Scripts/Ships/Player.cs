using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship {

    private float Turn;

    public int CargoHold;

    int LayerMaskName;

// Use this for initialization
void Start ()
    {
        Digits = 0;

        CurrentCargo = 0;
        MaxCargo = 20;
        Cargo = new int[MaxCargo];
        Damage = 5;
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
        Speed = 5;
        TurnSpeed = 5;
        Shields = 5;

        HasFired = false;
        LayerMaskName = LayerMask.GetMask("Pirate", "Bounty Hunter");

        BountyPrice = 500;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        IsAlive();
        Zone = GetZone();

        SortCargo();

        Debug.DrawRay(this.gameObject.transform.position, transform.up * -20);

        

        
        
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
            Attack(this.gameObject);
        }
    }

}
