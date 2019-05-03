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
        GetNumberOfShipsInScene();
        GetStarsInScene();

        //SpawnShips();
        SpawnStars();

        
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

    /*
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

    } */

    #endregion

    #region Ships

    void GetNumberOfShipsInScene()
    {
        GameObject[] BH = GameObject.FindGameObjectsWithTag("Bounty Hunter");
        GameObject[] P = GameObject.FindGameObjectsWithTag("Pirate");
        GameObject[] CS = GameObject.FindGameObjectsWithTag("Cargo Ship");
        GameObject[] T = GameObject.FindGameObjectsWithTag("Transporter");

        ShipsInScene.Clear();

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

    void SpawnShips()
    {
        if (ShipsInScene.Count < 10)
        {
            int Rand = Random.Range(0, 4);
            GameObject Ship = Pirate;

            switch (Rand)
            {
                case 0:
                    Ship = BountyHunter;
                    break;
                case 1:
                    Ship = Pirate;
                    break;
                case 2:
                    Ship = CargoShip;
                    break;
                case 3:
                    Ship = Transporter;
                    break;
            }
            Vector3 Spawn = new Vector3(Random.Range(-1500, 1500), Random.Range(-1500, 1500), 0);
            
            if (Vector3.Distance(this.gameObject.transform.position, Spawn) < 50 || Vector3.Distance(Player.transform.position, Spawn) < 50)
            {
                while (Vector3.Distance(this.gameObject.transform.position, Spawn) < 50 || Vector3.Distance(Player.transform.position, Spawn) < 50)
                {
                    Spawn = new Vector3(Random.Range(-1500, 1500), Random.Range(-1500, 1500), 0);
                }
            }

            GameObject SpawnShip = Instantiate(Ship, Spawn, this.transform.rotation);
        }
    }

    void SpawnStars()
    {
        bool StarInRange = false;
        if (StarsInScene.Count < 100)
        {
            Vector3 Spawn = new Vector3(Player.transform.position.x + Random.Range(-50, 50), Player.transform.position.y + Random.Range(-50, 50), 0);

            foreach (GameObject S in StarsInScene)
            {
                if (Vector3.Distance(Spawn, S.transform.position) < 5)
                {
                    StarInRange = true;
                }
            }

            if (Vector3.Distance(Player.transform.position, Spawn) < 30 || StarInRange == true)
            {
                while (Vector3.Distance(Player.transform.position, Spawn) < 30 || StarInRange == true)
                {
                    StarInRange = false;
                    Spawn = new Vector3(Player.transform.position.x + Random.Range(-50, 50), Player.transform.position.y + Random.Range(-50, 50), 0);

                    foreach (GameObject S in StarsInScene)
                    {
                        if (Vector3.Distance(Spawn, S.transform.position) < 5)
                        {
                            StarInRange = true;
                        }
                    }
                }
            }

            GameObject SpawnStar = Instantiate(Stars, Spawn, this.transform.rotation);

        }
    }

    #endregion
}
