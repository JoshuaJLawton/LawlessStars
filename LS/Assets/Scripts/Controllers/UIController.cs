using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject Player;
    private Player _player;

    public Text Health;
    public Text Digits;
    public Text Inventory;

	// Use this for initialization
	void Start ()
    {
        _player = Player.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        DisplayHealth();
        DisplayDigits();
        DisplayInventory();
	}

    void DisplayHealth()
    {
        Health.text = "Health: " + _player.CurrentHealth.ToString();
    }

    void DisplayDigits()
    {
        Digits.text = "Digits: " + _player.Digits.ToString();
    }

    void DisplayInventory()
    {
        if (_player.Inventory <= 0)
        {
            Inventory.text = "Inventory Empty";
        }
        else if (_player.Inventory >= _player.CargoHold)
        {
            Inventory.text = "Inventory Full";
        }
        else
        {
            Inventory.text = "Inventory: " + _player.Inventory.ToString() + " / " + _player.CargoHold.ToString();
        }
    }



}
