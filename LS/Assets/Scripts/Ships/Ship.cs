using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    [Header("Ship Stats")]
    // The Damage the ship deals per shot
    public int Damage;
    // Speed in which the ship can move
    public float Speed;
    // Speed in which the ship can turn
    public float TurnSpeed;
    // The ship's maximum amount of health
    public int MaxHealth;
    // The current health of the ship
    public float CurrentHealth;
    // The health of the ship's shields (Which protect the ship's health)
    public float Shields;
    // Current amount of Cargo being held;
    public int CurrentCargo;
    // The maximum cargo a ship can hold;
    public int MaxCargo;

    [Header("Set Up")]
    // The Zone the NPC spawns in / the Zone the player is currently in
    public int Zone;
    // The bounty on the ship (Whether a hunter will attack)
    public int BountyPrice;
    // Ship will roam to this destination
    public Vector3 RoamDestination;

    [Header("Ship Loot")]
    // The currency held by the ship
    public int Digits;
    // A check to see if the Digits have been transferred
    public bool DigitsTransferred;
    // The cargo held by the ship
    public int[] Cargo;
    // A check to see if the Cargo has been dropped
    public bool CargoDropped;


    [Header("Combat")]
    // If the hunter is attacked by another ship, it will defend itself
    public GameObject Attacker;
    // The owner of the shot which makes contact with the ship
    public GameObject HitBy;
    // If the ship has recently fired
    public bool HasFired;
    
    

    [Header("Prefabs")]
    // The Ship's Projectile
    public GameObject Projectile;
    // Signifies the ship's death
    public GameObject Smoke;
    // Dropped by the ship upon death
    public GameObject Loot;

    #region Initialisation

    #region Damage

    public int SetDamage()
    {
        int D = 1;
        int x = 2;

        switch (this.gameObject.tag)
        {
            case "Bounty Hunter":
                D = 5;
                break;
            case "Pirate":
                D = 3;
                break;
        }

        D = (D + Random.Range(-x, x)) * Zone;

        return D;
    }

    #endregion

    #region Health
    public int SetMaxHealth()
    {
        int Max;
        int x = 10, y = 10;

        switch (this.gameObject.tag)
        {
            case "Bounty Hunter":
                x = 20;
                y = 30;
                break;
            case "Pirate":
                x = 15;
                y = 25;
                break;
            case "Cargo Ship":
                x = 5;
                y = 15;
                break;
            case "Transporter":
                x = 10;
                y = 20;
                break;
        }

        Max = (Random.Range(x, y) * Zone);

        return Max;
    }
    #endregion

    #region Shields
    public int SetShields()
    {
        int Shield;
        int x = 5, y = 5, ZoneMult = 0;

        switch (this.gameObject.tag)
        {
            case "Bounty Hunter":
                x = 5;
                x = 10;

                ZoneMult = Zone;
                break;
            case "Pirate":
                x = 5;
                x = 10;
                switch (Zone)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        ZoneMult = Zone;
                        break;
                }
                break;
            case "Cargo Ship":
            case "Transporter":
                x = 2;
                x = 6;
                switch (Zone)
                {
                    case 3:
                    case 4:
                    case 5:
                        ZoneMult = Zone;
                        break;
                }
                break;
        }
        Shield = (Random.Range(x, y) * ZoneMult);

        return Shield;
    }
    #endregion

    #region Speed / Turn Speed

    public float SetSpeed()
    {
        float S;
        float x = 2.00f, y = 2.00f;

        switch (this.gameObject.tag)
        {
            case "Bounty Hunter":

                switch (Zone)
                {
                    case 1:
                        x = 2.5f;
                        y = 3f;
                        break;
                    case 2:
                        x = 2.5f;
                        y = 3.25f;
                        break;
                    case 3:
                        x = 3f;
                        y = 4f;
                        break;
                    case 4:
                        x = 3.75f;
                        y = 4.5f;
                        break;
                    case 5:
                        x = 3.75f;
                        y = 5f;
                        break;
                }
                break;

            case "Pirate":

                switch (Zone)
                {
                    case 1:
                        x = 2f;
                        y = 2.75f;
                        break;
                    case 2:
                        x = 2f;
                        y = 3.5f;
                        break;
                    case 3:
                        x = 2.75f;
                        y = 4f;
                        break;
                    case 4:
                        x = 3f;
                        y = 4.5f;
                        break;
                    case 5:
                        x = 3.5f;
                        y = 5f;
                        break;
                }

                break;
            case "Cargo Ship":
            case "Transporter":

                switch (Zone)
                {
                    case 1:
                        x = 2f;
                        y = 2.75f;
                        break;
                    case 2:
                        x = 2f;
                        y = 3f;
                        break;
                    case 3:
                        x = 2.5f;
                        y = 3.25f;
                        break;
                    case 4:
                        x = 3f;
                        y = 4;
                        break;
                    case 5:
                        x = 3.5f;
                        y = 5;
                        break;
                }
                break;
        }

        S = Random.Range(x, y);

        return S;
    }

    public float SetTurnSpeed()
    {
        int S;
        int x = 10, y = 10;

        switch (this.gameObject.tag)
        {
            case "Bounty Hunter":

                switch (Zone)
                {
                    case 1:
                        x = 4;
                        y = 6;
                        break;
                    case 2:
                        x = 4;
                        y = 7;
                        break;
                    case 3:
                        x = 5;
                        y = 7;
                        break;
                    case 4:
                        x = 6;
                        y = 8;
                        break;
                    case 5:
                        x = 7;
                        y = 10;
                        break;
                }
                break;

            case "Pirate":

                switch (Zone)
                {
                    case 1:
                        x = 3;
                        y = 4;
                        break;
                    case 2:
                        x = 3;
                        y = 5;
                        break;
                    case 3:
                        x = 3;
                        y = 7;
                        break;
                    case 4:
                        x = 4;
                        y = 8;
                        break;
                    case 5:
                        x = 5;
                        y = 9;
                        break;
                }

                break;
            case "Cargo Ship":
            case "Transporter":

                switch (Zone)
                {
                    case 1:
                        x = 3;
                        y = 5;
                        break;
                    case 2:
                        x = 3;
                        y = 6;
                        break;
                    case 3:
                        x = 4;
                        y = 8;
                        break;
                    case 4:
                        x = 6;
                        y = 8;
                        break;
                    case 5:
                        x = 7;
                        y = 10;
                        break;
                }
                break;
        }

        S = Random.Range(x, y);

        return S;
    }

    #endregion

    #region Zone
    public int GetZone()
    {
        if (Vector2.Distance(this.gameObject.transform.position, new Vector2(0, 0)) < 250)
        {
            return 1;
        }
        else if (Vector2.Distance(this.gameObject.transform.position, new Vector2(0, 0)) < 500)
        {
            return 2;
        }
        else if (Vector2.Distance(this.gameObject.transform.position, new Vector2(0, 0)) < 750)
        {
            return 3;
        }
        else if (Vector2.Distance(this.gameObject.transform.position, new Vector2(0, 0)) < 1000)
        {
            return 4;
        }
        else if (Vector2.Distance(this.gameObject.transform.position, new Vector2(0, 0)) < 1500)
        {
            return 5;
        }
        else
        {
            return 5;
        }
    }
    #endregion

    #region Bounty Price

    public int SetBountyPrice()
    {
        return Random.Range(5, 20) * (Zone * Zone * Zone);
    }

    #endregion

    #region Digits
    public int SetDigits()
    {
        return (int)Vector2.Distance(this.gameObject.transform.position, new Vector2(0, 0)) + Random.Range(-25, 25) * (1 + (Zone / 10));

    }
    #endregion

    #region Cargo

    public int GetCargoID()
    {
        int RND = Random.Range(1, 100);
        int LootID = 50;

        switch (Zone)
        {
            case 1:

                if (RND <= 10) // Rare 10% Chance
                {
                    LootID = GetRareLoot();
                }
                else if (RND <= 30) // Uncommon 20% Chance
                {
                    LootID = GetUncommonLoot();
                }
                else if (RND <= 100) // Common 60% Chance
                {
                    LootID = GetCommonLoot();
                }

                break;

            case 2:

                if (RND <= 20) // Rare 20% Chance
                {
                    LootID = GetRareLoot();
                }
                else if (RND <= 55) // Uncommon 35% Chance
                {
                    LootID = GetUncommonLoot();
                }
                else if (RND <= 100) // Common 45% Chance
                {
                    LootID = GetCommonLoot();
                }

                break;

            case 3:

                if (RND <= 3) // Treasure 3% Chance
                {
                    LootID = GetTreasureLoot();
                }
                else if (RND <= 30) // Rare 27% Chance
                {
                    LootID = GetRareLoot();
                }
                else if (RND <= 70) // Uncommon 40% Chance
                {
                    LootID = GetUncommonLoot();
                }
                else if (RND <= 100) // Common 30% Chance
                {
                    LootID = GetCommonLoot();
                }

                break;

            case 4:

                if (RND <= 1) // Cosmic Treasure 1% Chance
                {
                    LootID = GetCosmicTreasureLoot();
                }
                else if (RND <= 7) // Treasure 6% Chance
                {
                    LootID = GetTreasureLoot();
                }
                else if (RND <= 42) // Rare 35% Chance
                {
                    LootID = GetRareLoot();
                }
                else if (RND <= 85) // Uncommon 43% Chance
                {
                    LootID = GetUncommonLoot();
                }
                else if (RND <= 100) // Common 15% Chance
                {
                    LootID = GetCommonLoot();
                }

                break;

            case 5:

                if (RND <= 3) // Cosmic Treasure 3% Chance
                {
                    LootID = GetCosmicTreasureLoot();
                }
                else if (RND <= 19) // Treasure 15% Chance
                {
                    LootID = GetTreasureLoot();
                }
                else if (RND <= 59) // Rare 40% Chance
                {
                    LootID = GetRareLoot();
                }
                else if (RND <= 94) // Uncommon 35% Chance
                {
                    LootID = GetUncommonLoot();
                }
                else if (RND <= 100) // Common 7% Chance
                {
                    LootID = GetCommonLoot();
                }

                break;
        }
        return LootID;
    }

    public int GetCosmicTreasureLoot()
    {
        int RND = Random.Range(1, 7);
        return RND;
    }

    public int GetTreasureLoot()
    {
        int RND = Random.Range(8, 17);
        return RND;
    }

    public int GetRareLoot()
    {
        int RND = Random.Range(18, 30);
        return RND;
    }

    public int GetUncommonLoot()
    {
        int RND = Random.Range(31, 40);
        return RND;
    }

    public int GetCommonLoot()
    {
        int RND = Random.Range(41, 50);
        return RND;
    }

    public int GetCargoSize()
    {
        int Size = 0;

        switch (this.gameObject.tag)
        {
            case "Pirate":

                switch (Zone)
                {
                    case 1:
                        Size = Random.Range(3, 5);
                        break;

                    case 2:
                        Size = Random.Range(3, 7);
                        break;

                    case 3:
                        Size = Random.Range(4, 9);
                        break;

                    case 4:
                        Size = Random.Range(5, 10);
                        break;

                    case 5:
                        Size = Random.Range(6, 12);
                        break;
                }

                break;

            case "Cargo Ship":

                switch (Zone)
                {
                    case 1:
                        Size = Random.Range(4, 6);
                        break;

                    case 2:
                        Size = Random.Range(4, 9);
                        break;

                    case 3:
                        Size = Random.Range(5, 11);
                        break;

                    case 4:
                        Size = Random.Range(6, 13);
                        break;

                    case 5:
                        Size = Random.Range(7, 15);
                        break;
                }

                break;
        }

        return Size;
    }

    public void SetCargo()
    {
        int x = 0;
        int counter = 0;

        switch (this.gameObject.tag)
        {
            case "Pirate":
                x = 1;
                break;
            case "Cargo Ship":
                x = MaxCargo / 2;
                break;
        }

        CurrentCargo = Random.Range(x, MaxCargo);

        while (counter < CurrentCargo)
        {
            Cargo[counter] = GetCargoID();
            counter++;
        }
    }

    #endregion

    #endregion

    #region Collision

    void OnTriggerEnter2D(Collider2D Other)
    {
        switch (Other.gameObject.tag)
        {
            case "Laser":
                if (Other.GetComponent<ProjectileController>().Owner != this.gameObject)
                {
                    HitBy = Other.GetComponent<ProjectileController>().Owner;
                    Attacker = Other.GetComponent<ProjectileController>().Owner;

                    GameObject Explosion = Other.GetComponent<ProjectileController>().Explosion;
                    Instantiate(Explosion, new Vector3(Other.transform.position.x, Other.transform.position.y, 0f), Other.transform.rotation);
                    Destroy(Other.gameObject);

                    if (Shields > 0)
                    {
                        Shields = Shields - Other.GetComponent<ProjectileController>().Damage;
                        if (Shields < 0)
                        {
                            Shields = 0;
                        }
                    }
                    else
                    {
                        CurrentHealth = CurrentHealth - Other.GetComponent<ProjectileController>().Damage;
                    }
                }
                break;

            case "Cargo":

                if (this.gameObject.tag == "Player" || this.gameObject.tag == "Pirate")
                {
                    if (CurrentCargo <= MaxCargo)
                    {
                        AddToInventory(Other.gameObject.GetComponent<LootController>().LootID);
                        Destroy(Other.gameObject);
                        CurrentCargo++;
                    }
                }
                
                break;

            case "Station":

                Debug.Log("Station in view");

                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D Other)
    {
        
        switch (Other.gameObject.tag)
        {
            case "Player":
            case "Bounty Hunter":
            case "Pirate":
            case "Cargo Ship":
            case "Transporter":

                Debug.Log(this.gameObject.tag + ", " + Other.gameObject.tag);

                // Implement a funtion so collision can only cause damage periodically

                
                HitBy = Other.gameObject;
                Attacker = Other.gameObject;
                CurrentHealth = CurrentHealth - (Random.Range(1,100) * 0.1f);
                

                break;
        }
    }

    public void SortCargo()
    {
        int counter = 0;

        while (counter <= 19)
        {
            if (counter != 0)
            {
                if (Cargo[counter - 1] == 0)
                {
                    Cargo[counter - 1] = Cargo[counter];
                    Cargo[counter] = 0;
                }
            }
            counter++;
        }
    }

    public void AddToInventory(int LootID)
    {
        if (Cargo[MaxCargo - 1] == 0)
        {
            Debug.Log("LOOT ADD: " + LootID);
            Cargo[MaxCargo - 1] = LootID;
        }
    }

    #endregion

    #region Functions

    #region Moving

    // Moves ship towards a gameobject
    public void MoveTowardsObject(GameObject Target, float Speed)
    {
        // Rotate towards
        Vector3 Direction = Target.transform.position - transform.position;
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90;
        Quaternion TargetRotation = Quaternion.Euler(0, 0, Angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnSpeed);
        // Move towards
        transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
    }

    // Moves ship away from a gameobject
    public void MoveAwayFromObject(GameObject Target, float Speed)
    {
        // Rotate towards
        Vector3 Direction = Target.transform.position - transform.position;
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - 90;
        Quaternion TargetRotation = Quaternion.Euler(0, 0, Angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnSpeed);
        // Move towards
        transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
    }

    // Moves ship towards a location
    public void MoveTowardsLocation(Vector3 Target, float Speed)
    {
        // Rotate towards
        Vector3 Direction = Target - transform.position;
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90;
        Quaternion TargetRotation = Quaternion.Euler(0, 0, Angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnSpeed);
        // Move towards
        transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
    }

    // Constantly moves ship towards a random location
    public void Roam()
    {
        if (Vector3.Distance(this.transform.position, RoamDestination) < 5)
        {
            RoamDestination = Destination();
        }
        else
        {
            MoveTowardsLocation(RoamDestination, Speed);
        }
    }

    // Gets the random location
    public Vector3 Destination()
    {
        float RNDx = this.gameObject.transform.position.x + Random.Range(-100, 100);
        float RNDy = this.gameObject.transform.position.y + Random.Range(-100, 100);
        Vector3 Destination = new Vector3(RNDx, RNDy, 0);

        return Destination;
    }

    #endregion

    #region Combat

    // Starts the enemy attacking
    public void Attack(GameObject Target)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 50);

        if (this.gameObject.tag == "Player")
        {
            if (HasFired == false)
            {
                StartCoroutine(Fire());
            }
        }
        else
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == Target.tag)
                {
                    if (HasFired == false)
                    {
                        StartCoroutine(Fire());
                    }
                }
            }
        }   
    }

    // Starts the enemy firing
    IEnumerator Fire()
    {
        HasFired = true;
        GameObject Laser = Instantiate(Projectile, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
        Laser.GetComponent<ProjectileController>().Damage = Damage;
        Laser.GetComponent<ProjectileController>().Owner = this.gameObject;
        
        yield return new WaitForSeconds(0.5f);
        HasFired = false;
    }

    public bool IsBeingAttacked()
    {
        if (Attacker == null)
        {
            return false;
        }
        else if( Attacker != null && Vector3.Distance(this.gameObject.transform.position, Attacker.transform.position) > 20)
        {
            Attacker = null;
            return false;
        }
        else
        {
            return true;
        }


        
    }
    #endregion

    #endregion

    #region Death

    public void IsAlive()
    {
        if (CurrentHealth <= 0)
        {
            StartCoroutine(DestroyShip());
        }
    }

    IEnumerator DestroyShip()
    {
        Destroy(this.gameObject.GetComponent<PolygonCollider2D>());
        if (Digits != 0)
        {
            TransferDigits();
        }
        DropCargo();
        Instantiate(Smoke, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    void TransferDigits()
    {        
        if (!DigitsTransferred)
        {
            switch (this.gameObject.tag)
            {
                case "Player":
                    switch (HitBy.tag)
                    {
                        case "Bounty Hunter":
                            HitBy.GetComponent<BountyHunter>().Digits = HitBy.GetComponent<BountyHunter>().Digits + Digits;
                            break;
                        case "Pirate":
                            HitBy.GetComponent<Pirates>().Digits = HitBy.GetComponent<Pirates>().Digits + Digits;
                            break;
                    }
                    break;
                case "Bounty Hunter":
                    switch (HitBy.tag)
                    {
                        case "Player":
                            HitBy.GetComponent<Player>().Digits = HitBy.GetComponent<Player>().Digits + Digits;
                            break;
                        case "Bounty Hunter":
                            HitBy.GetComponent<BountyHunter>().Digits = HitBy.GetComponent<BountyHunter>().Digits + Digits;
                            break;
                        case "Pirate":
                            HitBy.GetComponent<Pirates>().Digits = HitBy.GetComponent<Pirates>().Digits + Digits;
                            break;
                    }
                    break;
                case "Pirate":
                    switch (HitBy.tag)
                    {
                        case "Player":
                            HitBy.GetComponent<Player>().Digits = HitBy.GetComponent<Player>().Digits + Digits;
                            break;
                        case "Bounty Hunter":
                            HitBy.GetComponent<BountyHunter>().Digits = HitBy.GetComponent<BountyHunter>().Digits + Digits;
                            break;
                        case "Pirate":
                            HitBy.GetComponent<Pirates>().Digits = HitBy.GetComponent<Pirates>().Digits + Digits;
                            break;
                    }
                    break;
                case "Transporter":
                    switch (HitBy.tag)
                    {
                        case "Player":
                            HitBy.GetComponent<Player>().Digits = HitBy.GetComponent<Player>().Digits + Digits;
                            break;
                        case "Bounty Hunter":
                            HitBy.GetComponent<BountyHunter>().Digits = HitBy.GetComponent<BountyHunter>().Digits + Digits;
                            break;
                        case "Pirate":
                            HitBy.GetComponent<Pirates>().Digits = HitBy.GetComponent<Pirates>().Digits + Digits;
                            break;
                    }
                    break;

            }
            DigitsTransferred = true;
            Debug.Log("TRANSFERRED");
        }    
    }

    public void DropCargo()
    {
        int counter = 0;
        if (!CargoDropped)
        {
            while (counter < MaxCargo)
            {
                if (Cargo[counter] != 0)
                {
                    Debug.Log("Cargo: " + Cargo[counter]);
                    GameObject LootCapsule = Instantiate(Loot, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
                    LootCapsule.GetComponent<LootController>().LootID = Cargo[counter];                    
                }
                counter++;
            }

            CargoDropped = true;
        } 
    }

    #endregion
}
