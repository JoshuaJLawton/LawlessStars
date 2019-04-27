using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour {

    public int[] Price = new int[50];

	// Use this for initialization
	void Start ()
    {
        SetPrices();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void SetPrices()
    {
        int counter = 0;

        while (counter < 50)
        {
            int Range = GetRootPrice(counter) / 4;


            Price[counter] = (int)GetRootPrice(counter) + Random.Range(-Range, Range);
            counter++;
        }
    }


    int GetRootPrice(int LootID)
    {
        if (LootID < 8)
        {
            return 2000;
        }
        else if (LootID < 18)
        {
            return 1000;
        }
        else if (LootID < 30)
        {
            return 300;
        }
        else if (LootID < 41)
        {
            return 100;
        }
        else
        {
            return 60;
        }
    }

}
