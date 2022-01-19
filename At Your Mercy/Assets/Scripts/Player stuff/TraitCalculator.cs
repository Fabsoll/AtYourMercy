using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitCalculator : MonoBehaviour
{

    int TraitNumber;
    int rareTraitNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void normalTraits()
    {
        switch (TraitNumber)
        {
            case 10:
                //-1 crit rate + 2 strength (kind of thoughtful)
                break;

            case 9:
                //+1 strength (kind of strong)
                break;

            case 8:
                //+1 speed (kind of swift)
                break;

            case 7:
                //invulnerable for 1 hit (kind of bold)
                break;

            case 6:
                //+1 crit rate, -2 defense (kind of reckless)
                break;

            case 5:
                //deal 10% damage back (kind of vengeful
                break;

            case 4:
                //+1 crit rate, -2 speed (kind of intelligent)
                break;

            case 3:
                // +1 random, -1 random (kind of weird)
                break;

            case 2:
                //+5% evasion (kind of lucky)
                break;

            case 1:
                //+2hp for every soul, -2 speed (kind of lazy)
                break;

        }
    }

    void rareTraits()
    {
        switch (rareTraitNumber)
        {
            case 11:
                //+3 speed (exceptionally strong)
                break;

            case 10:
                //+3 speed (exceptionally swift) 
                break;

            case 9:
                //invulnerable for 3 hits (exceptionally bold) 
                break;

            case 8:
                //+1 strength for every soul in valhalla (exceptionally caring) 
                break;

            case 7:
                //+3 crit rate -2 defense (exceptionally reckless)
                break;

            case 6:
                //deal 25% damage back (exceptionally vengeful) 
                break;

            case 5:
                //+1 strength for every soul not in valhalla (exceptionally independent)
                break;

            case 4:
                //+3 crit rate -2 speed (exceptionally intelligent)
                break;

            case 3:
                //+3 random -3 random (exceptionally weird)
                break;

            case 2:
                // +10% evasion (exceptionally lucky)
                break;

            case 1:
                //+4HP for every soul, - 2 speed (exceptionally lazy)
                break;
        }
    }


}
