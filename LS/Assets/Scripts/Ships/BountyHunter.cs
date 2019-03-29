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
    // If the hunter is attacked by another ship, it will defend itself
    public GameObject Attacker;

    [Header("Loot")]
    // The hunter's Digits
    public int Digits;

    [Header("Other")]
    // Holds the projectile prefab to be launched
    public GameObject Projectile;
    // The damage dealt by this ship
    public int Damage;
    // If the ship has recently fired
    bool HasFired = false;
    // The last ship to have hit this ship
    public GameObject HitBy;


    // Use this for initialization
    void Start ()
    {
        IsTracking = false;

        Damage = 5;

        SetDigits();      
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateBounty();

        Distance = Vector3.Distance(this.transform.position, Bounty.transform.position);

        HasHealth();

        if (Distance >= 10)
        {
            Debug.Log("TrackBounty");
            TrackBounty();
        }
        else
        {
            Debug.Log("AttackBounty");
            AttackBounty();
        }

        
    }

    #region Initialisation
    void SetDigits()
    {
        int x = (int)this.transform.position.x;
        if (x < 0)
        {
            x = x * -1;
        }

        int y = (int)this.transform.position.y;
        if (y < 0)
        {
            y = y * -1;
        }

        Digits = x + y;
    }

    #endregion

    #region Bounty Hunting
    void TrackBounty()
    {
        // Tracks bounty's current location
        if (!IsTracking)
        {
            StartCoroutine(Track());
        }

        // Rotate towards location
        Vector3 Direction = Tracker - transform.position;
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90;
        Quaternion TargetRotation = Quaternion.Euler(0, 0, Angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnSpeed);
        
        if (Distance < 1 && Distance > -1)
        {
            // Stop and await new coordinates
            transform.Translate(new Vector3(0, 0 * Time.deltaTime, 0));
        }
        else
        {
            // Move towards location
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
        }

    }

    void AttackBounty()
    {
        // Rotate towards bounty
        Vector3 Direction = Bounty.transform.position - transform.position;
        float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg + 90;
        Quaternion TargetRotation = Quaternion.Euler(0, 0, Angle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, TurnSpeed);

        if (Distance < 3)
        {
            // Move towards bounty at a slower speed to help aim
            transform.Translate(new Vector3(0, (-Speed * 0) * Time.deltaTime, 0));
            if (HasFired == false)
            {
                StartCoroutine(Fire());
            }
        }
        else if (Distance < 6)
        {
            // Move towards bounty at a slower speed to help aim
            transform.Translate(new Vector3(0, (-Speed / 2) * Time.deltaTime, 0));
            if (HasFired == false)
            {
                StartCoroutine(Fire());
            }
        }
        else
        {
            // Move towards bounty
            transform.Translate(new Vector3(0, -Speed * Time.deltaTime, 0));
        }
    }

    void UpdateBounty()
    {
        Bounties = GameObject.FindGameObjectsWithTag("Enemy");

        if (Bounty == null)
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

    #region Ship Functions
    IEnumerator Fire()
    {
        GameObject Laser = Instantiate(Projectile, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
        Laser.GetComponent<ProjectileController>().Damage = Damage;
        Laser.GetComponent<ProjectileController>().Owner = this.gameObject;
        HasFired = true;
        yield return new WaitForSeconds(0.5f);
        HasFired = false;
    }

    void HasHealth()
    {
        if (CurrentHealth <= 0)
        {
            StartCoroutine(DestroyShip());
        }
    }

    void TransferDigits()
    {
        switch (HitBy.tag)
        {
            case "Player":
                HitBy.GetComponent<Player>().Digits = HitBy.GetComponent<Player>().Digits + Digits;
                break;
        }
    }

    IEnumerator DestroyShip()
    {
        Instantiate(Smoke, new Vector3(this.transform.position.x, this.transform.position.y, 0f), this.transform.rotation);
        TransferDigits();
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        switch (Other.gameObject.tag)
        {
            case "Laser":
                if (Other.GetComponent<ProjectileController>().Owner != this.gameObject)
                {
                    HitBy = Other.GetComponent<ProjectileController>().Owner;
                    GameObject Explosion = Other.GetComponent<ProjectileController>().Explosion;
                    Instantiate(Explosion, new Vector3(Other.transform.position.x, Other.transform.position.y, 0f), Other.transform.rotation);
                    Destroy(Other.gameObject);
                    CurrentHealth = CurrentHealth - Other.GetComponent<ProjectileController>().Damage;
                }
                break;
        }

    }
    #endregion

    // ATTACK Bounty

    // Constantly tries to track down and attack bounty
    // Will retaliate if provoked

}
