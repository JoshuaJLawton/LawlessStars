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

    public bool IsOneSprite;
    public Sprite[] Ships = new Sprite[4];

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
        Bounties = new GameObject[20];

        if (SetSprite() != null)
        {
            GetComponent<SpriteRenderer>().sprite = SetSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // To prevent bounties going up
        BountyPrice = 0; 

        IsAlive();
        Hunt();        
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

    #region Bounty Hunting

    void Hunt()
    {
        if (IsBeingAttacked())
        {
            AttackTarget(Attacker);
        }
        else if (Bounty != null)
        {
            if (Distance > 15)
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
        else if(Bounty == null)
        {
            if (UpdateBounty() == null)
            {
                Roam();
            }
            else
            {
                Bounty = UpdateBounty();
            }
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

            Attack(Target);
        }
        else if (TargetDistance < 6)
        {
            // Move towards bounty at a slower speed to help aim
            MoveTowardsObject(Target, Speed/2);

            Attack(Target);
        }
        else
        {
            // Move towards bounty
            MoveTowardsObject(Target, Speed);
        }
    }

    GameObject UpdateBounty()
    {
        GameObject HighBounty = null;
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] Pirates = GameObject.FindGameObjectsWithTag("Pirate");

        Bounties = Pirates;

        if (Bounties[0] != null)
        {
            HighBounty = Bounties[0];

            foreach (GameObject Ship in Bounties)
            {
                if (Ship.GetComponent<Pirates>().BountyPrice > HighBounty.GetComponent<Pirates>().BountyPrice)
                {
                    HighBounty = Ship;
                }
            }
        }
        
        if (Player != null && HighBounty != null)
        {
            if (Player.GetComponent<Player>().BountyPrice > HighBounty.GetComponent<Pirates>().BountyPrice)
            {
                HighBounty = Player;
            }
        }

        return HighBounty;
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
