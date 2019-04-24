using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHunter : Ship
{
    [Header("Bounty Hunting")]
    // List of hunter's potential bounties
    public GameObject[] Bounties;
    // The hunter's current bounty
    public GameObject Bounty;
    // The last known location of the bounty
    public Vector3 Tracker;
    // If the Hunter is moving towards the last known location
    public bool IsTracking;
    // The current distance between the Hunter and its bounty
    public float Distance;

    // Use this for initialization
    void Start()
    {
        Zone = GetZone();
        Digits = SetDigits();
        Damage = SetDamage();
        MaxHealth = SetMaxHealth();
        CurrentHealth = MaxHealth;
        Speed = SetSpeed();
        TurnSpeed = SetTurnSpeed();
        Shields = SetShields();

        IsTracking = false;
        HasFired = false;
        Attacker = null;
        RoamDestination = Destination();
    }

    // Update is called once per frame
    void Update()
    {
        // To prevent bounties going up
        BountyPrice = 0; 

        IsAlive();
        Hunt();        
    }

    #region Bounty Hunting

    void Hunt()
    {
        UpdateBounty();

        if (IsBeingAttacked())
        {
            AttackTarget(Attacker);
        }
        else if (Bounty != null)
        {
            if (Distance > 10)
            {
                Debug.Log("TrackBounty");
                TrackBounty();
            }
            else
            {
                Debug.Log("AttackBounty");
                AttackTarget(Bounty);
            }
        }
        else
        {
            Roam();
        }

    }


    void TrackBounty()
    {
        // Tracks bounty's current location
        if (!IsTracking)
        {
            StartCoroutine(Track());
        }
        
        if (Distance < 1 && Distance > -1)
        {
            // Stop and await new coordinates
            MoveTowardsLocation(Tracker, 0);
        }
        else
        {
            // Move towards location
            MoveTowardsLocation(Tracker, Speed);
        }

    }

    void AttackTarget(GameObject Target)
    {

        float TargetDistance = Vector3.Distance(this.transform.position, Target.transform.position);

        if (TargetDistance < 3)
        {
            // Move towards bounty at a slower speed to help aim
            MoveTowardsObject(Target, 0);

            Attack();
        }
        else if (TargetDistance < 6)
        {
            // Move towards bounty at a slower speed to help aim
            MoveTowardsObject(Target, Speed/2);

            Attack();
        }
        else
        {
            // Move towards bounty
            MoveTowardsObject(Target, Speed);
        }
    }

    void UpdateBounty()
    {
        Bounties = GameObject.FindGameObjectsWithTag("Enemy");

        if (Bounty != null)
        {
            Distance = Vector3.Distance(this.transform.position, Bounty.transform.position);
        }

        if (Bounty == null && Bounties.Length > 0)
        {
            Bounty = Bounties[Random.Range(0,Bounties.Length)];
        }
    }

    
    IEnumerator Track()
    {
        Debug.Log("Track");
        IsTracking = true;
        Tracker = Bounty.transform.position;
        yield return new WaitForSeconds(10);
        
        IsTracking = false;
    }
    #endregion
}
