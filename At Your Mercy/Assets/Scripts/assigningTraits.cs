using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class assigningTraits : MonoBehaviour
{
    // Start is called before the first frame update



    PlayerCombatNew getEnemy;
    Enemy enemyInfo;
    public GameObject valhallaChoice;
    public Text thisTrait;
    public TraitCalculator TraitCalc;
    int weirdDown;
    int weirdUp;
    string trait;
    List<int> usedValues = new List<int>();
    int TraitNumber;
    int rareTraitNumber;
    PlayerCombatNew BrunnTrait;
    PlayerMovement BrunnMove;
    bool isEnemyDead;
    public GameObject lastEnemy;
    bool isEnemyStrong;
    void Start()
    {
        enemyInfo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        getEnemy = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatNew>();
        BrunnMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        BrunnTrait = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatNew>();
        valhallaChoice.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemy != null) { isEnemyDead = lastEnemy.GetComponent<Enemy>().isDead; }
        if (lastEnemy != null)
        {
            isEnemyStrong = lastEnemy.GetComponent<Enemy>().strongenemy;
        }
        if (isEnemyDead == true)
        {
            Die();

            
        }
    }


    void Die()
    {

        
        Time.timeScale = 0;
        TraitCalc.Deathcount += 1;
        if (isEnemyStrong== true)
        {
            strongTraitNumberGenerator();
            strongTraits();
        }
        else
        {

            normalTraitNumberGenerator();
            normalTraits();
        }
        valhallaChoice.SetActive(true);
        lastEnemy.SetActive(false);
        isEnemyDead = false;
    }


    void normalTraitNumberGenerator()
    {
        int val = Random.Range(1, 11);

        TraitNumber = val;
    }
    void strongTraitNumberGenerator()
    {
        int val = Random.Range(1, 12);

        rareTraitNumber = val;
    }

    void normalTraits()
    {
        thisTrait.text = "This person was kind of ";
        switch (TraitNumber)
        {

            case 11:
                trait = "careful";
                break;
            case 10:
                //-5% crit rate + 1strength (kind of thoughtful)
                trait = "thoughtful";
                break;

            case 9:
                //+1 strength (kind of strong)

                trait = "strong";
                break;

            case 8:
                //+1 speed (kind of swift)

                trait = "swift";
                break;

            case 7:
                //invulnerable for 1 hit (kind of bold)
                trait = "bold";
                break;

            case 6:
                //+5% crit rate, -2 defense (kind of reckless)
                trait = "reckless";
                break;

            case 5:
                //deal 10% damage back (kind of vengeful
                trait = "vengeful";
                break;

            case 4:
                //+5% crit rate, -2 speed (kind of intelligent)
                trait = "intelligent";
                break;

            case 3:
                // +1 random, -1 random (kind of weird)
                trait = "weird";
                break;

            case 2:
                //+5% evasion (kind of lucky)
                trait = "lucky";
                break;

            case 1:
                //+2hp for every soul, -2 speed (kind of lazy)

                trait = "lazy";
                break;

        }

        thisTrait.text += trait;
        TraitCalc.newTrait = "kind of " + trait + "\n";
    }

    void strongTraits()
    {

        switch (rareTraitNumber)
        {
            case 12:
                trait = "careful";
                break;
            case 11:
                //+3 speed (exceptionally strong)
                trait = "strong";
                break;

            case 10:
                //+3 speed (exceptionally swift) 
                trait = "swift";
                break;

            case 9:
                //invulnerable for 3 hits (exceptionally bold) 
                trait = "bold";
                break;

            case 8:
                //+1 strength for every soul in valhalla (exceptionally caring) 
                trait = "caring";
                break;

            case 7:
                //+3 crit rate -2 defense (exceptionally reckless)
                trait = "reckless";
                break;

            case 6:
                //deal 25% damage back (exceptionally vengeful) 
                trait = "vengeful";
                break;

            case 5:
                //+1 strength for every soul not in valhalla (exceptionally independent)
                trait = "independent";
                break;

            case 4:
                //+3 crit rate -2 speed (exceptionally intelligent)
                trait = "intelligent";
                break;

            case 3:
                //+3 random -3 random (exceptionally weird)
                trait = "weird";
                break;

            case 2:
                // +10% evasion (exceptionally lucky)
                trait = "lucky";
                break;

            case 1:
                //+4HP for every soul, - 2 speed (exceptionally lazy)
                trait = "lazy";
                break;

        }
        thisTrait.text = "This person was exceptionally " + trait;
        TraitCalc.newTrait = "exceptionally " + trait + "\n";
        Debug.Log(rareTraitNumber);
    }




    public void Valhalla()
    {
        if (isEnemyStrong == true)
        {
            TraitCalc.valhallaHP += 15;
        }
        else
        {
            TraitCalc.valhallaHP += 5;
        }

        TraitCalc.valhallaCount ++;
        TraitCalc.valhallaTextCount += 0.5f;
        valhallaChoice.SetActive(false);
        Time.timeScale = 1;
    }

    public void Banish()
    {

        TraitCalc.oldTraits = TraitCalc.oldTraits + TraitCalc.newTrait;
        Debug.Log("trait stored");

        if (isEnemyStrong == true)
        {
            switch (trait)
            {
                case "careful":
                    BrunnTrait.defense += 3;
                    break;
                case "strong":
                    BrunnTrait.baseAttack += 3;
                    break;
                case "swift":
                    BrunnMove.movementSpeed += 3f;
                    break;
                case "bold":
                    //invulnerable for 3 hits
                    break;
                case "caring":
                    TraitCalc.caringTrait = true;
                    break;
                case "reckless":
                    //+15% crit rate, -2 defense
                    BrunnTrait.critNumber += 3;
                    BrunnTrait.defense -= 2;
                    break;
                case "vengeful":
                    //deal 25% damage back
                    break;
                case "independent":
                    TraitCalc.independentTrait = true;
                    break;
                case "intelligent":
                    //crit +15% speed -2
                    BrunnTrait.critNumber += 3;
                    BrunnMove.movementSpeed -= 2;
                    break;
                case "weird":
                    //+3random -3random
                    weirdTraitGenerator();
                    break;
                case "lucky":
                    //+10% evasion
                    BrunnTrait.evadeNumber += 2;
                    break;
                case "lazy":
                    TraitCalc.lazyTrait = true;
                    BrunnMove.movementSpeed -= 2;
                    break;


            }
        }
        else
        {
            switch (trait)
            {
                case "careful":
                    BrunnTrait.defense += 1;
                    break;
                case "strong":
                    BrunnTrait.baseAttack += 1;
                    break;
                case "swift":
                    BrunnMove.movementSpeed += 1;
                    break;
                case "bold":
                    //invulnerable for 1 hit
                    break;
                case "reckless":
                    //+5% crit rate, -1 defense
                    BrunnTrait.critNumber += 1;
                    BrunnTrait.defense -= 1;
                    break;
                case "vengeful":
                    //deal 10% damage back
                    break;
                case "intelligent":
                    //+5% crit rate -2 speed
                    BrunnTrait.critNumber += 1;
                    BrunnMove.movementSpeed -= 2;
                    break;
                case "weird":
                    //+1 random -1 random
                    weirdTraitGenerator();

                    break;
                case "lucky":
                    //+5% evasion
                    BrunnTrait.evadeNumber += 1;
                    break;
                case "lazy":
                    TraitCalc.valhallaHP += 2 * TraitCalc.valhallaCount;
                    BrunnMove.movementSpeed -= 2;
                    break;
            }
        }

        TraitCalc.traitCount += 1;
        valhallaChoice.SetActive(false);
        Time.timeScale = 1;
    }

    void weirdTraitGenerator()
    {
        weirdUp = Random.Range(1, 3);
        switch (weirdUp)
        {
            case 1:
                if (isEnemyStrong)
                {
                    BrunnTrait.baseAttack += 3;

                }
                else
                {
                    BrunnTrait.baseAttack += 1;
                }
                break;
            case 2:
                if (isEnemyStrong)
                {
                    //def +3
                    BrunnTrait.defense += 3;
                }
                else
                {
                    //def +1
                    BrunnTrait.defense += 1;
                }
                break;
            case 3:
                //speed up
                if (isEnemyStrong)
                {
                    BrunnMove.movementSpeed += 3;

                }
                else
                {
                    BrunnMove.movementSpeed += 1;
                }
                break;


        }
        getRandomDown();


    }


    void getRandomDown()
    {
        weirdDown = Random.Range(1, 3);
        if (weirdDown != weirdUp)
        {
            switch (weirdDown)
            {
                case 1:
                    //strength down
                    if (isEnemyStrong)
                    {
                        BrunnTrait.baseAttack -= 3;

                    }
                    else
                    {
                        BrunnTrait.baseAttack -= 1;
                    }
                    break;
                case 2:
                    //defense up
                    if (isEnemyStrong)
                    {
                        BrunnTrait.defense -= 3;
                    }
                    else
                    {
                        //def-1
                        BrunnTrait.defense -= 1;
                    }
                    break;
                case 3:
                    //speed up
                    if (isEnemyStrong)
                    {
                        BrunnMove.movementSpeed -= 3;
                    }
                    else
                    {
                        BrunnMove.movementSpeed -= 1;
                    }
                    break;
            }
        }
        else
        {
            getRandomDown();
        }

    }
    void GetTrait()
    {

    }

}
