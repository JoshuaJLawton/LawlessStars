using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject Player;

    public List<GameObject> ShipsInScene = new List<GameObject>();
    public bool SpawnedStars;
    public List<GameObject> StarsInScene = new List<GameObject>();

    [Header("Prefabs")]
    public GameObject Stars, BountyHunter, Pirate, CargoShip, Transporter;

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.Find("Player");

        SpawnedStars = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetStarsInScene();
        //TrimStars();
	}

    #region Stars

    void GetStarsInScene()
    {
        GameObject[] S = GameObject.FindGameObjectsWithTag("Star");

        // Adds all Transporters
        foreach (GameObject Star in S)
        {
            StarsInScene.Add(Star);
        }
    }

    void TrimStar()
    {
        StarsInScene.Sort(delegate (GameObject a, GameObject b)
        {
            return Vector3.Distance(Player.transform.position, a.transform.position).CompareTo(Vector3.Distance(Player.transform.position, b.transform.position));
        });

        foreach (GameObject S in StarsInScene)
        {
            if (Vector3.Distance(Player.transform.position, S.transform.position) > 300)
            {
                Destroy(S.gameObject);
            }
        }
    }

    void SpawningStars()
    {
        if (!SpawnedStars)
        {
            StartCoroutine(SpawnStars());
        }
    }

    IEnumerator SpawnStars()
    {
        
        yield return new WaitForSeconds(10f);

    }

    #endregion

    #region Ships

    void GetNumberOfShipsInScene()
    {
        GameObject[] BH = GameObject.FindGameObjectsWithTag("Bounty Hunter");
        GameObject[] P = GameObject.FindGameObjectsWithTag("Pirate");
        GameObject[] CS = GameObject.FindGameObjectsWithTag("Cargo Ship");
        GameObject[] T = GameObject.FindGameObjectsWithTag("Transporter");


        foreach (GameObject BountyHunter in BH)
        {
            ShipsInScene.Add(BountyHunter);
        }
        foreach (GameObject Pirate in P)
        {
            ShipsInScene.Add(Pirate);
        }
        foreach (GameObject CargoShip in CS)
        {
            ShipsInScene.Add(CargoShip);
        }
        foreach (GameObject Transporter in T)
        {
            ShipsInScene.Add(Transporter);
        }
    }

    void TrimShips()
    {
        ShipsInScene.Sort(delegate (GameObject a, GameObject b)
        {
            return Vector3.Distance(Player.transform.position, a.transform.position).CompareTo(Vector3.Distance(Player.transform.position, b.transform.position));
        });



    }


    #endregion
}
