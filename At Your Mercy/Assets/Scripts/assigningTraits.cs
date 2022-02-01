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
    List<int> previousTraitsStrong = new List<int>();
    List<int> previousTraits = new List<int>();
    void Start()
    {
        enemyInfo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        getEnemy = GameObject.Find("dontDestroyThese/Valkyrie").GetComponent<PlayerCombatNew>();
        BrunnMove = GameObject.Find("dontDestroyThese/Valkyrie").GetComponent<PlayerMovement>();
        BrunnTrait = GameObject.Find("dontDestroyThese/Valkyrie").GetComponent<PlayerCombatNew>();
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
        int val = Random.Range(1, 12);
        while (previousTraits.Contains(val))
        {
            val = Random.Range(1, 12);
        }
        previousTraits.Add(val);
        TraitNumber = val;
    }
    void strongTraitNumberGenerator()
    {
        int val = Random.Range(1, 14);
        while (previousTraitsStrong.Contains(val))
        {
            val = Random.Range(1, 14);
        }
        previousTraitsStrong.Add(val);
        rareTraitNumber = val;
    }

    void normalTraits()
    {
        thisTrait.text = "This person was kind of ";
        switch (TraitNumber)
        {
            case 12:
                trait = "energetic";
                break;

            case 11:
                trait = "careful";
                break;
            case 10:
                //+2 strength, longer cd
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
                trait = "resilient";
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
            case 14:
                trait = "energetic";
                break;
            case 13:
                trait = "thoughtful";
                    break;
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
                trait = "resilient";
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
        //Debug.Log(rareTraitNumber);
    }




    public void Valhalla()
    {
        if (isEnemyStrong == true)
        {
            TraitCalc.valhallaBaseHP += 60;
        }
        else
        {
            TraitCalc.valhallaBaseHP += 25;
        }

        TraitCalc.valhallaCount ++;
        TraitCalc.valhallaTextCount += 0.5f;
        valhallaChoice.SetActive(false);
        Time.timeScale = 1;
    }

    public void Banish()
    {

        TraitCalc.oldTraits = TraitCalc.oldTraits + TraitCalc.newTrait;
        //Debug.Log("trait stored");

        if (isEnemyStrong == true)
        {
            switch (trait)
            {
                case "energetic":
                    BrunnTrait.attackCD /= 3;
                    BrunnTrait.heavyAttackCD /= 3;
                    BrunnMove.movementSpeed += 7;
                    break;
                case "thoughtful":
                    BrunnTrait.baseAttackStart += 10;

                    BrunnTrait.attackCD *= 3;
                    BrunnTrait.heavyAttackCD *= 2;
                    //longer cooldown
                    break;

                case "careful":
                    BrunnTrait.defense += 4;
                    break;
                case "strong":
                    BrunnTrait.baseAttackStart += 7;
                    break;
                case "swift":
                    BrunnMove.movementSpeed += 15;
                    break;
                case "resilient":
                    //invulnerable for 3 hits
                    TraitCalc.invulnerabilityCount += 6;
                    break;
                case "caring":
                    TraitCalc.caringTrait = true;
                    break;
                case "reckless":
                    //+20% crit rate, -2 defense
                    BrunnTrait.critNumber += 4;
                    BrunnTrait.defense -= 2;
                    break;
                case "vengeful":
                    //deal 25% damage back
                    TraitCalc.vengefulTrait = true;
                    TraitCalc.vengefulTraitNumber += 5;
                    break;
                case "independent":
                    TraitCalc.independentTrait = true;
                    break;
                case "intelligent":
                    //crit +15% speed -2
                    BrunnTrait.critNumber += 4;
                    BrunnMove.movementSpeed -= 5;
                    break;
                case "weird":
                    //+3random -3random
                    weirdTraitGenerator();
                    break;
                case "lucky":
                    //+20% evasion
                    BrunnTrait.evadeNumber += 4;
                    break;
                case "lazy":

                    BrunnMove.movementSpeed -= 10;
                    TraitCalc.lazyNumber += 20;
                    TraitCalc.lazyTrait = true;
                    break;


            }
        }
        else
        {
            switch (trait)
            {
                case "energetic":
                    BrunnTrait.attackCD /= 2;
                    BrunnTrait.heavyAttackCD /= 2;
                    BrunnMove.movementSpeed += 5;
                    break;
                case "thoughtful":
                    BrunnTrait.baseAttackStart += 10;
                    BrunnTrait.attackCD *= 3;
                    BrunnTrait.heavyAttackCD *= 2;
                    //longer cooldown
                    break;
                case "careful":
                    BrunnTrait.defense += 2;
                    break;
                case "strong":
                    BrunnTrait.baseAttackStart += 5;
                    break;
                case "swift":
                    BrunnMove.movementSpeed += 7;
                    break;
                case "resilient":
                    //invulnerable for 1 hit
                    TraitCalc.invulnerabilityCount += 3;
                    break;
                case "reckless":
                    //+5% crit rate, -1 defense
                    BrunnTrait.critNumber += 2;
                    BrunnTrait.defense -= 2;
                    break;
                case "vengeful":
                    //deal 10% damage back
                    TraitCalc.vengefulTrait = true;
                    TraitCalc.vengefulTraitNumber += 2;
                    break;
                case "intelligent":
                    //+5% crit rate -2 speed
                    BrunnTrait.critNumber += 2;
                    BrunnMove.movementSpeed -= 5;
                    break;
                case "weird":
                    //+1 random -1 random
                    weirdTraitGenerator();

                    break;
                case "lucky":
                    //+5% evasion
                    BrunnTrait.evadeNumber += 2;
                    break;
                case "lazy":
                    TraitCalc.lazyNumber += 10;
                    TraitCalc.lazyTrait = true;
                    BrunnMove.movementSpeed -= 10;
                    break;
            }
        }
        if (BrunnMove.movementSpeed <= 0)
        {
            BrunnMove.movementSpeed = 5;
        }
        if (BrunnTrait.baseAttack <= 0)
        {
            BrunnTrait.baseAttack = 1;
        }
;
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
                    BrunnTrait.baseAttackStart += 10;

                }
                else
                {
                    BrunnTrait.baseAttackStart += 5;
                }
                break;
            case 2:
                if (isEnemyStrong)
                {
                    //def +3
                    BrunnTrait.defense += 4;
                }
                else
                {
                    //def +1
                    BrunnTrait.defense += 2;
                }
                break;
            case 3:
                //speed up
                if (isEnemyStrong)
                {
                    BrunnMove.movementSpeed += 25;

                }
                else
                {
                    BrunnMove.movementSpeed += 10;
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
                        BrunnTrait.baseAttackStart -= 10;

                    }
                    else
                    {
                        BrunnTrait.baseAttackStart -= 5;
                    }
                    break;
                case 2:
                    //defense up
                    if (isEnemyStrong)
                    {
                        BrunnTrait.defense -= 4;
                    }
                    else
                    {
                        //def-1
                        BrunnTrait.defense -= 2;
                    }
                    break;
                case 3:
                    //speed up
                    if (isEnemyStrong)
                    {
                        BrunnMove.movementSpeed -= 25;
                    }
                    else
                    {
                        BrunnMove.movementSpeed -= 10;
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
