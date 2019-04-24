using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshController : MonoBehaviour {

    public GameObject Player;

    public GameObject PFStar;

    private bool RefreshingStars;

	// Use this for initialization
	void Start ()
    {
        RefreshingStars = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.P))
        {
            CheckStars();
            SpawnStars();
        }

        if (!RefreshingStars)
        {
            StartCoroutine(RefreshStars());
        }
	}

    void CheckStars()
    {
        foreach (GameObject Star in GameObject.FindGameObjectsWithTag("Star"))
        {
            if (GameObject.FindGameObjectsWithTag("Star").Length < 200)
            {
                // Destroys the star if it is too far away from the player
                if (Vector2.Distance(Player.transform.position, Star.transform.position) > 50)
                {
                    GameObject.Destroy(Star);
                }
            }
        }
    }

    void SpawnStars()
    {
        int Counter = 0;

        while (Counter <= 99)
        {
            Instantiate(PFStar, new Vector3((Player.transform.position.x + Random.Range(-25, 25)), (this.transform.position.y + Random.Range(-25, 25)), 0f), Quaternion.identity);
            Counter++;
        }
    }

    IEnumerator RefreshStars()
    {
        RefreshingStars = true;
        CheckStars();
        SpawnStars();
        yield return new WaitForSeconds(10f);
        RefreshingStars = false;
    }
}
