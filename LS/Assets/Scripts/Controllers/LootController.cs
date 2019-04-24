using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootController : MonoBehaviour {

    public int LootID;

    public Sprite[] Capsules = new Sprite[4];

    Rigidbody2D RB;
    float Direction, Force;

    // Use this for initialization
    void Start ()
    {
        RB = this.GetComponent<Rigidbody2D>();
        Direction = Random.Range(-20, 20);
        Force = Random.Range(-20f, 20f);
        RB.AddForce(new Vector2(Direction, Force));

        GetComponent<SpriteRenderer>().sprite = SetSprite();

        Debug.Log("CARGO SPAWNED");

    }
	
	// Update is called once per frame
	void Update ()
    {
        Rotate();
	}

    void Rotate()
    {
        RB.transform.Rotate(0, 0, (Force * 1) - 5);
    }

    Sprite SetSprite()
    {
        return Capsules[Random.Range(0, 3)];
    }

    /// LOOT GUIDE
    /// ===================================
    ///  - COSMIC TREASURE
    ///  
    ///  1. Galactic Gem         
    ///  2. Quantum Crystal
    ///  3. Energised Diamond
    ///  4. Harbulary Battery
    ///  5. Super-Nova Remnant
    ///  6. Celestial Orb
    ///  7. Chaos Emerald
    /// 
    /// ===================================
    ///  - TREASURE
    ///  
    ///  8. Crystal
    ///  9. Ruby
    ///  10. Sapphire
    ///  11. Emerald
    ///  12. Diamond
    ///  13. Pearl
    ///  14. Gold
    ///  15. Silver
    ///  16. Platinum
    ///  17. Nova Remnant
    ///  
    /// ===================================
    ///  - RARE
    ///  
    ///  18. Positronic Brain
    ///  19. Fully Functioning Robot
    ///  20. UFO Fragment
    ///  21. Symbiotic Parasite
    ///  22. Klaxxnium
    ///  23. Energy Core
    ///  24. Obsidian
    ///  25. Hyperrite
    ///  26. Ancient Technology Part
    ///  27. Unkown Chemical Experiment
    ///  28. Electromagnetic Ward
    ///  29. Artificial Gravity Device
    ///  30. Ancient Gadget
    /// 
    /// ===================================
    ///  - UNCOMMON
    ///  
    ///  31. Functioning Robot Parts
    ///  32. Quarnyx Battery
    ///  33. Cybernetic Arm
    ///  34. Cybernetic Leg
    ///  35. Burnt Out Energy Core
    ///  36. Stardust
    ///  37. Alien Plant
    ///  38. Engine Cooler
    ///  39. Alien Weapon
    ///  40. Assault Mechanism
    /// 
    /// ===================================
    ///  - COMMON
    ///  
    ///  41. Broken Robot Parts
    ///  42. Scrap Metal
    ///  43. Oxygen Cannister
    ///  44. Food Rations
    ///  45. Water
    ///  46. Asteroid Fragment
    ///  47. Fragmented Circuitry
    ///  48. Melted Resistor
    ///  49. Clothing Fabric
    ///  50. Military Grade Weapon

}
