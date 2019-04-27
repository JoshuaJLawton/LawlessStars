using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : Ship
{
    // Ship will constantly move towards a destination
    public GameObject PassengerDestination;
    // Direction the ship turns
    public int TurnDirection;

    public bool IsOneSprite;
    public Sprite[] Ships = new Sprite[4];

    // Use this for initialization
    void Start()
    {
        Zone = GetZone();
        Digits = SetDigits();
        MaxHealth = SetMaxHealth();
        CurrentHealth = MaxHealth;
        Speed = SetSpeed();
        TurnSpeed = SetTurnSpeed();
        Shields = SetShields();

        DigitsTransferred = false;
        CargoDropped = false;
        Attacker = null;
        PassengerDestination = GameObject.FindGameObjectWithTag("Station");
        TurnDirection = GetDirection();

        if (SetSprite() != null)
        {
            GetComponent<SpriteRenderer>().sprite = SetSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
        Deliver();
        BountyPrice = 0;
    }

    Sprite SetSprite()
    {
        if (IsOneSprite)
        {
            return Ships[Random.Range(0, 4)];
        }
        else
        {
            return null;
        }
    }

    #region Carry Passengers

    void Deliver()
    {
        if (IsBeingAttacked())
        {
            MoveAwayFromObject(Attacker, Speed);
        }
        else
        {
            MoveShip();
        }
    }

    void MoveShip()
    {
        // Rotate around station
        Vector3 Direction = PassengerDestination.transform.position - transform.position;
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + TurnDirection;
        Quaternion TargetRotation = Quaternion.Euler(0, 0, Angle + 90);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnSpeed);
        transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
    }

    int GetDirection()
    {
        bool boolValue = (Random.Range(0, 2) == 0);
        if (boolValue)
        {
            return 90;
        }
        else
        {
            return -90;
        }
    }

    #endregion

}
