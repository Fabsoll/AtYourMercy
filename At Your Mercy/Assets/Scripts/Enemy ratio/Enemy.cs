using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public Color damageColor;
    public SpriteRenderer enemySprite;
    private UI UIData;

    List<int> usedValues = new List<int>();
    int TraitNumber;
    int rareTraitNumber;
    public bool strong;



    //valhalla choice system ui stuff vvvvvvv
    public GameObject valhallaChoice;
    public Text thisTrait;
    public TraitCalculator TraitCalc;

    public HealthBarBehaviour hpBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        hpBar.SetHealth(currentHealth, maxHealth);
        UIData = FindObjectOfType<UI>();
        valhallaChoice.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hpBar.SetHealth(currentHealth, maxHealth);
        StartCoroutine(ApplyDamageColor());

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        //Debug.Log("enemy dies");
        UIData.deathCounter++;
        Time.timeScale = 0;

        if (strong == true)
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


    }


    void normalTraitNumberGenerator()
    {
        int val = Random.Range(1, 10);
       
        TraitNumber = val;
    }
    void strongTraitNumberGenerator()
    {
        int val = Random.Range(1, 11);
        
        TraitNumber = val;
    }

    void normalTraits()
    {
        thisTrait.text = "This person was kind of ";
        switch (TraitNumber)
        {
           
            case 10:
                //-1 crit rate + 2 strength (kind of thoughtful)
                thisTrait.text += "thoughtful";
                break;

            case 9:
                //+1 strength (kind of strong)
                thisTrait.text += "strong";

                break;

            case 8:
                //+1 speed (kind of swift)
                thisTrait.text += "swift";
                break;

            case 7:
                //invulnerable for 1 hit (kind of bold)
                thisTrait.text += "bold";
                break;

            case 6:
                //+1 crit rate, -2 defense (kind of reckless)
                thisTrait.text += "reckless";
                break;

            case 5:
                //deal 10% damage back (kind of vengeful
                thisTrait.text += "vengeful";
                break;

            case 4:
                //+1 crit rate, -2 speed (kind of intelligent)
                thisTrait.text += "intelligent";
                break;

            case 3:
                // +1 random, -1 random (kind of weird)
                thisTrait.text += "weird";
                break;

            case 2:
                //+5% evasion (kind of lucky)
                thisTrait.text += "lucky";
                break;

            case 1:
                //+2hp for every soul, -2 speed (kind of lazy)
                thisTrait.text += "lazy";
                break;

        }
    }

    void strongTraits()
    {
        thisTrait.text = "This person was exceptionally ";
        switch (rareTraitNumber)
        {
            case 11:
                //+3 speed (exceptionally strong)
                thisTrait.text = "strong";
                break;

            case 10:
                //+3 speed (exceptionally swift) 

                thisTrait.text = "swift";
                break;

            case 9:
                //invulnerable for 3 hits (exceptionally bold) 

                thisTrait.text = "bold";
                break;

            case 8:
                //+1 strength for every soul in valhalla (exceptionally caring) 

                thisTrait.text = "caring";
                break;

            case 7:
                //+3 crit rate -2 defense (exceptionally reckless)

                thisTrait.text = "reckless";
                break;

            case 6:
                //deal 25% damage back (exceptionally vengeful) 

                thisTrait.text = "vengeful";
                break;

            case 5:
                //+1 strength for every soul not in valhalla (exceptionally independent)

                thisTrait.text = "independent";
                break;

            case 4:
                //+3 crit rate -2 speed (exceptionally intelligent)

                thisTrait.text = "intelligent";
                break;

            case 3:
                //+3 random -3 random (exceptionally weird)

                thisTrait.text = "weird";
                break;

            case 2:
                // +10% evasion (exceptionally lucky)

                thisTrait.text = "lucky";
                break;

            case 1:
                //+4HP for every soul, - 2 speed (exceptionally lazy)

                thisTrait.text = "lazy";
                break;
        }
    }




    public void Valhalla()
    {
        if (strong == true)
        {
            TraitCalc.valhallaHP += 15;
        }
        else
        {
            TraitCalc.valhallaHP += 5;
        }
        
        valhallaChoice.SetActive(false);
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    void GetTrait()
    {

    }

    IEnumerator ApplyDamageColor(){
        enemySprite.GetComponent<SpriteRenderer>().material.color = damageColor;
        yield return new WaitForSeconds(0.5f);
        enemySprite.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
