using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship {

    [Header("Player Levels")]
    public int LvlSpeed, LvlTurnSpeed, LvlDamage, LvlShields, LvlHealth, LvlCargo;

    [Header("Other")]

    private float Turn;

    public int CargoHold;

    public bool IsNearStation;

// Use this for initialization
    void Start ()
    {
        LvlSpeed = 1;
        LvlTurnSpeed = 1;
        LvlDamage = 1;
        LvlShields = 1;
        LvlHealth = 1;
        LvlCargo = 1;

        Digits = 0;

        SetPlayerStats();
        Cargo = new int[MaxCargo];
        CurrentHealth = MaxHealth;

        /*
        CurrentCargo = 0;
        MaxCargo = 20;
        Cargo = new int[MaxCargo];
        Damage = 5;
        MaxHealth = 20;
        CurrentHealth = MaxHealth;
        Speed = 5;
        TurnSpeed = 5;
        Shields = 5;
        */



        HasFired = false;
        DigitsTransferred = false;
        CargoDropped = false;


        BountyPrice = 0;
        IsNearStation = false;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerControls();
        IsAlive();
        Zone = GetZone();

        SortCargo();

        SetPlayerStats();

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

    public void SetPlayerStats()
    {
        switch (LvlSpeed)
        {
            case 1:
                Speed = 5;
                break;
            case 2:
                Speed = 6;
                break;
            case 3:
                Speed = 7;
                break;
            case 4:
                Speed = 9;
                break;
            case 5:
                Speed = 10;
                break;
        }
        switch (LvlTurnSpeed)
        {
            case 1:
                TurnSpeed = 2.5f;
                break;
            case 2:
                TurnSpeed = 3.5f;
                break;
            case 3:
                TurnSpeed = 4.5f;
                break;
            case 4:
                TurnSpeed = 5.5f;
                break;
            case 5:
                TurnSpeed = 6.5f;
                break;
        }
        switch (LvlDamage)
        {
            case 1:
                Damage = 5;
                break;
            case 2:
                Damage = 10;
                break;
            case 3:
                Damage = 15;
                break;
            case 4:
                Damage = 20;
                break;
            case 5:
                Damage = 30;
                break;
        }
        switch (LvlShields)
        {
            case 1:
                Shields = 10;
                break;
            case 2:
                Shields = 20;
                break;
            case 3:
                Shields = 30;
                break;
            case 4:
                Shields = 40;
                break;
            case 5:
                Shields = 50;
                break;
        }
        switch (LvlHealth)
        {
            case 1:
                MaxHealth = 25;
                break;
            case 2:
                MaxHealth = 50;
                break;
            case 3:
                MaxHealth = 100;
                break;
            case 4:
                MaxHealth = 125;
                break;
            case 5:
                MaxHealth = 150;
                break;
        }
        switch (LvlCargo)
        {
            case 1:
                MaxCargo = 10;
                break;
            case 2:
                MaxCargo = 20;
                break;
            case 3:
                MaxCargo = 30;
                break;
            case 4:
                MaxCargo = 40;
                break;
            case 5:
                MaxCargo = 50;
                break;
        }

    }
}


