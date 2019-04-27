using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject Player;
    private Player _player;

    public Text Health;
    public Text Shields;
    public Text Digits;
    public GameObject InventoryPanel;
    public Text[] InventorySlot = new Text[50];

	// Use this for initialization
	void Start ()
    {
        _player = Player.GetComponent<Player>();
        InventoryPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        DisplayHealthAndShields();
        DisplayDigits();
        DisplayInventory();
	}

    void DisplayHealthAndShields()
    {
        if (_player.CurrentHealth > 0)
        {
            Health.text = "Health: " + _player.CurrentHealth.ToString();
        }
        else
        {
            Health.text = "Ship Destroyed";
        }

        if (_player.Shields > 0)
        {
            Shields.text = "Shields: " + _player.Shields.ToString();
        }
        else
        {
            Shields.text = "No Shields!";
        }

        
    }

    void DisplayDigits()
    {
        Digits.text = "Digits: " + _player.Digits.ToString();
    }


    void DisplayInventory()
    {
        int counter1 = 0, counter2 = 0;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (InventoryPanel.activeSelf)
            {
                InventoryPanel.SetActive(false);
            }
            else
            {
                InventoryPanel.SetActive(true);
            }
        }

        while (counter1 < 50)
        {
            if (counter1 >= _player.MaxCargo)
            {
                InventorySlot[counter1].enabled = false;
            }
            else
            {
                InventorySlot[counter1].enabled = true;
            }
            counter1++;
        }

        while (counter2 < 50)
        {
            // InventorySlot[counter2].text = (counter2 + 1) + ". " + GetLootName(1 + counter2);
            if (_player.Cargo[counter2] != 0)
            {
                InventorySlot[counter2].text = (counter2 + 1) + ". " + GetLootName(_player.Cargo[counter2]);
            }
            else
            {
                InventorySlot[counter2].text = (counter2 + 1) + ". Empty slot";
            }
            counter2++;
        }
        
    }

    void ClearInventorySlot(int value)
    {
        int counter = 0;

        while (counter < 50)
        {
            if (InventorySlot[counter])
            counter++;
        }
    }

    string GetLootName(int LootID)
    {
        string Name = "";

        switch (LootID)
        {
            case 1:
                Name = "Galactic Gem";
                break;
            case 2:
                Name = "Quantum Crystal";
                break;
            case 3:
                Name = "Energised Diamond";
                break;
            case 4:
                Name = "Harbulary Battery";
                break;
            case 5:
                Name = "Super-Nova Remnant";
                break;
            case 6:
                Name = "Celestial Orb";
                break;
            case 7:
                Name = "Chaos Emerald";
                break;
            case 8:
                Name = "Crystal";
                break;
            case 9:
                Name = "Ruby";
                break;
            case 10:
                Name = "Sapphire";
                break;
            case 11:
                Name = "Emerald";
                break;
            case 12:
                Name = "Diamond";
                break;
            case 13:
                Name = "Pearl";
                break;
            case 14:
                Name = "Gold";
                break;
            case 15:
                Name = "Silver";
                break;
            case 16:
                Name = "Platinum";
                break;
            case 17:
                Name = "Nova Remnant";
                break;
            case 18:
                Name = "Positronic Brain";
                break;
            case 19:
                Name = "Fully Functioning Robot";
                break;
            case 20:
                Name = "UFO Fragment";
                break;
            case 21:
                Name = "Symbiotic Parasite";
                break;
            case 22:
                Name = "Klaxxnium";
                break;
            case 23:
                Name = "Energy Core";
                break;
            case 24:
                Name = "Obsidian";
                break;
            case 25:
                Name = "Hyperrite";
                break;
            case 26:
                Name = "Ancient Technology Part";
                break;
            case 27:
                Name = "Unkown Chemical Experiment";
                break;
            case 28:
                Name = "Electromagnetic Ward";
                break;
            case 29:
                Name = "Artificial Gravity Device";
                break;
            case 30:
                Name = "Ancient Gadget";
                break;
            case 31:
                Name = "Functioning Robot Parts";
                break;
            case 32:
                Name = "Quarnyx Battery";
                break;
            case 33:
                Name = "Cybernetic Arm";
                break;
            case 34:
                Name = "Cybernetic Leg";
                break;
            case 35:
                Name = "Burnt Out Energy Core";
                break;
            case 36:
                Name = "Stardust";
                break;
            case 37:
                Name = "Alien Plant";
                break;
            case 38:
                Name = "Engine Cooler";
                break;
            case 39:
                Name = "Alien Weapon";
                break;
            case 40:
                Name = "Assault Mechanism";
                break;
            case 41:
                Name = "Broken Robot Parts";
                break;
            case 42:
                Name = "Scrap Metal";
                break;
            case 43:
                Name = "Oxygen Cannister";
                break;
            case 44:
                Name = "Food Rations";
                break;
            case 45:
                Name = "Water";
                break;
            case 46:
                Name = "Asteroid Fragment";
                break;
            case 47:
                Name = "Fragmented Circuitry";
                break;
            case 48:
                Name = "Melted Resistor";
                break;
            case 49:
                Name = "Clothing Fabric";
                break;
            case 50:
                Name = "Military Grade Weapon";
                break;
        }

        return Name;
    }

}
