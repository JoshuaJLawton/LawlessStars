using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirates : Ship
{
    // Pirate will attack a target within range
    public GameObject PlunderTarget;

    public bool IsOneSprite;
    public Sprite[] Ships = new Sprite[4];

    // Use this for initialization
    void Start()
    {
        Zone = GetZone();
        Damage = SetDamage();
        MaxCargo = GetCargoSize();
        Cargo = new int[MaxCargo];
        SetCargo();
        Digits = SetDigits();
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

        if (SetSprite() != null)
        {
            GetComponent<SpriteRenderer>().sprite = SetSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
        Pirating();
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

    #region Pirating

    void Pirating()
    {
        SetPlunderTarget();
        
        if (IsBeingAttacked())
        {
            MoveAwayFromObject(Attacker, Speed);
        } 
        else if (PlunderTarget != null)
        {
            Plunder();
        }
        else if (IsCargo() && Cargo[MaxCargo - 1] == 0)
        {
            LootCargo();
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
        if (PlunderTarget != null && Attacker == null)
        {
            Debug.Log("Is Attacking");
            AttackTarget(PlunderTarget);
        }

        if (Vector3.Distance(this.gameObject.transform.position, PlunderTarget.transform.position) > 20)
        {
            PlunderTarget = null;
        }
        
    }

    void SetPlunderTarget()
    {
        /*
        if (PlunderTarget == null && GetPlunderTargets() != null)
        {
            if (Vector3.Distance(this.gameObject.transform.position, GetPlunderTargets()[0].transform.position) < 15)
            {
                PlunderTarget = GetPlunderTargets()[0];
            }
            else
            {
                PlunderTarget = null;
            }
        }*/

        List<GameObject> Targets = GetPlunderTargets();

        if (Targets.Count != 0 && PlunderTarget == null)
        {
            if (Vector3.Distance(this.gameObject.transform.position, GetPlunderTargets()[0].transform.position) < 15)
            {
                PlunderTarget = GetPlunderTargets()[0];
            }
            else
            {
                PlunderTarget = null;
            }
        }

    }

    List<GameObject> GetPlunderTargets()
    {
        GameObject[] Player = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] BountyHunters = GameObject.FindGameObjectsWithTag("Bounty Hunter");
        GameObject[] CargoShips = GameObject.FindGameObjectsWithTag("Cargo Ship");
        GameObject[] Transporters = GameObject.FindGameObjectsWithTag("Transporter");

        List<GameObject> Targets = new List<GameObject>();

        // Adds the player to the list
        if (Player != null)
        {
            foreach (GameObject Ship in Player)
            {
                Targets.Add(Ship);
            }
        }
        
        // Adds all Bounty Hunters
        /*
        foreach (GameObject Ship in BountyHunters)
        {
            Targets.Add(Ship);
        } */

        // Adds all Cargo Ships
        foreach (GameObject Ship in CargoShips)
        {
            Targets.Add(Ship);
        }
        // Adds all Transporters
        foreach (GameObject Ship in Transporters)
        {
            Targets.Add(Ship);
        }

        // Sorts the list of enemies by distance
        Targets.Sort(delegate (GameObject a, GameObject b)
        {
            return Vector3.Distance(this.transform.position, a.transform.position).CompareTo(Vector3.Distance(this.transform.position, b.transform.position));
        });

        return Targets;
    }

    void AttackTarget(GameObject Target)
    {
        MoveTowardsObject(Target, Speed);
        Attack(Target);
    }

    void LootCargo()
    {
        GameObject[] AllCargo = GameObject.FindGameObjectsWithTag("Cargo");
        List<GameObject> Cargo = new List<GameObject>();

        foreach (GameObject Loot in AllCargo)
        {
            Cargo.Add(Loot);
        }

        Cargo.Sort(delegate (GameObject a, GameObject b)
        {
            return Vector3.Distance(this.transform.position, a.transform.position).CompareTo(Vector3.Distance(this.transform.position, b.transform.position));
        });

        if (Vector3.Distance(this.gameObject.transform.position, Cargo[0].transform.position) < 20)
        {
            MoveTowardsObject(Cargo[0], Speed);
        }

    }

    bool IsCargo()
    {
        GameObject[] AllCargo = GameObject.FindGameObjectsWithTag("Cargo");
        List<GameObject> Cargo = new List<GameObject>();

        foreach (GameObject Loot in AllCargo)
        {
            Cargo.Add(Loot);
        }

        Cargo.Sort(delegate (GameObject a, GameObject b)
        {
            return Vector3.Distance(this.transform.position, a.transform.position).CompareTo(Vector3.Distance(this.transform.position, b.transform.position));
        });

        if (Vector3.Distance(this.gameObject.transform.position, Cargo[0].transform.position) < 20)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    #endregion

    // Will attack anything within range
    // Aim is to collect as much cargo as possible
    // STRETCH GOAL - Pirates move in fleets

}
