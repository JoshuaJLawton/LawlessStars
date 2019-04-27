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

    public Text IsNearStation;
    public GameObject StationPanel, PawnBrokerPanel, ShipsRUsPanel;

    [Header("Ships R Us")]
    public int[] Prices = new int[6];
    public Text[] UpgradePrices = new Text[6];
    public Text[] UpgradeButtons = new Text[6];


    // Use this for initialization
    void Start ()
    {
        

        InventoryPanel.SetActive(false);
        StationPanel.SetActive(false);
        IsNearStation.gameObject.SetActive(false);
        ShipsRUsPanel.SetActive(false);
        PawnBrokerPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        _player = Player.GetComponent<Player>();

        DisplayHealthAndShields();
        DisplayDigits();
        DisplayInventory();
        DisplayStation();
        ShipsRUs();
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

        if (!StationPanel.activeSelf || !PawnBrokerPanel.activeSelf || !ShipsRUsPanel.activeSelf)
        {
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

        while (counter2 < _player.MaxCargo)
        {
            // InventorySlot[counter2].text = (counter2 + 1) + ". " + GetLootName(1 + counter2);
            if (_player.Cargo[counter2] == 0)
            {
                InventorySlot[counter2].text = (counter2 + 1) + ". Empty slot";
            }
            else
            {
                InventorySlot[counter2].text = (counter2 + 1) + ". " + GetLootName(_player.Cargo[counter2]);
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

    #region Station

    void DisplayStation()
    {
        if (_player.IsNearStation)
        {
            if (StationPanel.activeSelf || PawnBrokerPanel.activeSelf || ShipsRUsPanel.activeSelf)
            {
                IsNearStation.gameObject.SetActive(false);
            }
            else
            {
                IsNearStation.gameObject.SetActive(true);
            }
                
            if (Input.GetKey(KeyCode.Return))
            {
                InventoryPanel.SetActive(false);
                StationPanel.SetActive(true);
            }
        }
        else
        {
            IsNearStation.gameObject.SetActive(false);
        }
    }

    public void CloseStation()
    {
        StationPanel.SetActive(false);
    }

    public void OpenShipsRUs()
    {
        StationPanel.SetActive(false);
        ShipsRUsPanel.SetActive(true);
        Debug.Log(this.gameObject.name);
    }

    public void OpenPawnBroker()
    {
        StationPanel.SetActive(false);
        PawnBrokerPanel.SetActive(true);
        Debug.Log(this.gameObject.name);
    }

    public void ReturnToMenu()
    {
        ShipsRUsPanel.SetActive(false);
        PawnBrokerPanel.SetActive(false);
        StationPanel.SetActive(true);
    }

    public void NewGalaxy()
    {
        // Saves all player stats and opens the main menu
    }

    public void SaveAndExit()
    {
        // Saves all player stats and opens the main menu
    }

    #endregion

    #region Ships'R'Us

    void ShipsRUs()
    {
        UpdatePrices();
        DisplayPrices();
    }

    void UpdatePrices()
    {
        switch(_player.LvlHealth)
        {
            case 1:
                Prices[0] = 250;
                break;
            case 2:
                Prices[0] = 500;
                break;
            case 3:
                Prices[0] = 1000;
                break;
            case 4:
                Prices[0] = 2500;
                break;
        }

        switch (_player.LvlShields)
        {
            case 1:
                Prices[1] = 250;
                break;
            case 2:
                Prices[1] = 500;
                break;
            case 3:
                Prices[1] = 1000;
                break;
            case 4:
                Prices[1] = 2500;
                break;
        }

        switch (_player.LvlDamage)
        {
            case 1:
                Prices[2] = 250;
                break;
            case 2:
                Prices[2] = 500;
                break;
            case 3:
                Prices[2] = 1000;
                break;
            case 4:
                Prices[5] = 2500;
                break;
        }

        switch (_player.LvlSpeed)
        {
            case 1:
                Prices[3] = 250;
                break;
            case 2:
                Prices[3] = 500;
                break;
            case 3:
                Prices[3] = 1000;
                break;
            case 4:
                Prices[5] = 2500;
                break;
        }

        switch (_player.LvlTurnSpeed)
        {
            case 1:
                Prices[4] = 250;
                break;
            case 2:
                Prices[4] = 500;
                break;
            case 3:
                Prices[4] = 1000;
                break;
            case 4:
                Prices[4] = 2500;
                break;
        }

        switch (_player.LvlCargo)
        {
            case 1:
                Prices[5] = 250;
                break;
            case 2:
                Prices[5] = 500;
                break;
            case 3:
                Prices[5] = 1000;
                break;
            case 4:
                Prices[5] = 2500;
                break;
        }
    }

    void DisplayPrices()
    {
        if (_player.LvlHealth < 5)
        {
            UpgradePrices[0].text = Prices[0] + " Digits";
        }
        else
        {
            UpgradePrices[0].text = "MAXED";
            UpgradeButtons[0].enabled = false;
        }

        if (_player.LvlShields < 5)
        {
            UpgradePrices[1].text = Prices[1] + " Digits";
        }
        else
        {
            UpgradePrices[1].text = "MAXED";
            UpgradeButtons[1].enabled = false;
        }

        if (_player.LvlDamage < 5)
        {
            UpgradePrices[2].text = Prices[2] + " Digits";
        }
        else
        {
            UpgradePrices[2].text = "MAXED";
            UpgradeButtons[2].enabled = false;
        }

        if (_player.LvlSpeed < 5)
        {
            UpgradePrices[3].text = Prices[3] + " Digits";
        }
        else
        {
            UpgradePrices[3].text = "MAXED";
            UpgradeButtons[3].enabled = false;
        }

        if (_player.LvlTurnSpeed < 5)
        {
            UpgradePrices[4].text = Prices[4] + " Digits";
        }
        else
        {
            UpgradePrices[4].text = "MAXED";
            UpgradeButtons[4].enabled = false;
        }

        if (_player.LvlCargo < 5)
        {
            UpgradePrices[5].text = Prices[5] + " Digits";
        }
        else
        {
            UpgradePrices[5].text = "MAXED";
            UpgradeButtons[5].enabled = false;
        }
    }

    public void UpgradeHealth()
    {
        if (_player.Digits >= Prices[0] && _player.LvlHealth < 5)
        {
            _player.Digits = _player.Digits - Prices[0];
            _player.LvlHealth++;
            _player.SetPlayerStats();
            _player.CurrentHealth =_player.MaxHealth;
            
        }
    }

    public void UpgradeShields()
    {
        if (_player.Digits >= Prices[1] && _player.LvlShields < 5)
        {
            _player.Digits = _player.Digits - Prices[1];
            _player.LvlShields++;
            _player.SetPlayerStats();
        }
    }

    public void UpgradeDamage()
    {
        if (_player.Digits >= Prices[2] && _player.LvlDamage < 5)
        {
            _player.Digits = _player.Digits - Prices[2];
            _player.LvlDamage++;
            _player.SetPlayerStats();
        }
    }

    public void UpgradeSpeed()
    {
        if (_player.Digits >= Prices[3] && _player.LvlSpeed < 5)
        {
            _player.Digits = _player.Digits - Prices[3];
            _player.LvlSpeed++;
            _player.SetPlayerStats();
        }
    }

    public void UpgradeTurnSpeed()
    {
        if (_player.Digits >= Prices[4] && _player.LvlTurnSpeed < 5)
        {
            _player.Digits = _player.Digits - Prices[4];
            _player.LvlTurnSpeed++;
            _player.SetPlayerStats();
        }
    }

    public void UpgradeCargoHold()
    {
        if (_player.Digits >= Prices[5] && _player.LvlCargo < 5)
        {
            _player.Digits = _player.Digits - Prices[5];
            _player.LvlCargo++;
            _player.Cargo = new int[_player.MaxCargo];
            _player.SetPlayerStats();

        }
    }

    #endregion

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
