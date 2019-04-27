using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    GameObject Player;
    Player _player;

    public Text[] InventorySlots = new Text[50];

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _player = Player.GetComponent<Player>();
        InventorySlots = GameObject.Find("Inventory Panel").GetComponent<ButtonController>().InventorySlots;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void ButtonPressed()
    {
        int counter = 0;
        
        

        while (counter < 50)
        {

            if (this.gameObject == InventorySlots[counter])
            {
                Debug.Log(this.gameObject + ", " + Player.GetComponent<Player>().Cargo[counter]);
                Player.GetComponent<Player>().Cargo[counter] = 0;
            }


            counter++;
        }

    }
}
