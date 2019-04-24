using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirates : Ship
{
    // Pirate will attack a target within range
    public GameObject PlunderTarget;

    // Use this for initialization
    void Start()
    {
        Zone = GetZone();
        Damage = SetDamage();
        MaxCargo = GetCargoSize();
        Cargo = new int[MaxCargo];
        SetCargo();
        MaxHealth = SetMaxHealth();
        CurrentHealth = MaxHealth;
        Speed = SetSpeed();
        TurnSpeed = SetTurnSpeed();
        Shields = SetShields();

        DigitsTransferred = false;
        CargoDropped = false;
        BountyPrice = SetPirateBounty();
        HasFired = false;
        Attacker = null;
        PlunderTarget = null;
        RoamDestination = Destination();
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
        Pirating();
    }

    #region Pirating

    void Pirating()
    {
        if (PlunderTarget == null)
        {
            PlunderTarget = SetPlunderTarget();
        }

        if (IsBeingAttacked())
        {
            AttackTarget(Attacker);
        } 
        else if (PlunderTarget != null)
        {
            Plunder();
        }
        else
        {
            Roam();
        }
    }


    int SetPirateBounty()
    {
        int Cost = Random.Range(50, 200) * Zone;
        return Cost;
        // Sets the bounty on the pirate
    }

    void Plunder()
    {
        if (Attacker != null)
        {
            AttackTarget(Attacker);
        }
        else if (PlunderTarget != null && Attacker == null)
        {
            AttackTarget(PlunderTarget);
        }
        
    }

    GameObject SetPlunderTarget()
    {

        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        GameObject[] BountyHunters = GameObject.FindGameObjectsWithTag("Bounty Hunter");
        GameObject[] CargoShips = GameObject.FindGameObjectsWithTag("Cargo Ship");
        GameObject[] Transporters = GameObject.FindGameObjectsWithTag("Transporter");

        List<GameObject> InRange = new List<GameObject>();


        // Adds the player to the list if in range
        if (Vector3.Distance(this.gameObject.transform.position, Player.transform.position) <= 10)
        {
            InRange.Add(Player);
        }
        // Adds all Bounty Hunters in range
        foreach (GameObject Ship in BountyHunters)
        {
            if (Vector3.Distance(this.gameObject.transform.position, Ship.transform.position) <= 10)
            {
                InRange.Add(Ship);
            }
        }
        // Adds all Cargo Ships in range
        foreach (GameObject Ship in CargoShips)
        {
            if (Vector3.Distance(this.gameObject.transform.position, Ship.transform.position) <= 10)
            {
                InRange.Add(Ship);
            }
        }
        // Adds all Transporters in range
        foreach (GameObject Ship in Transporters)
        {
            if (Vector3.Distance(this.gameObject.transform.position, Ship.transform.position) <= 10)
            {
                InRange.Add(Ship);
            }
        }

        // Sorts the list of enemies in range by distance
        InRange.Sort(delegate (GameObject a, GameObject b)
        {
            return Vector3.Distance(this.transform.position, a.transform.position).CompareTo(Vector3.Distance(this.transform.position, b.transform.position));
        });
 
        if (InRange == null)
        {
            return null;
        }
        else
        {
            //foreach
            return InRange[0];
        }
    }

    void AttackTarget(GameObject Target)
    {

        float TargetDistance = Vector3.Distance(this.transform.position, Target.transform.position);

        MoveTowardsObject(Target, Speed);
        Attack();

        // pirate shoots at target (less frequent than BH)
        // if pirate rams target, they must pause for a moment before continuing)

    }



    #endregion

    // Will attack anything within range
    // Aim is to collect as much cargo as possible
    // STRETCH GOAL - Pirates move in fleets

}
