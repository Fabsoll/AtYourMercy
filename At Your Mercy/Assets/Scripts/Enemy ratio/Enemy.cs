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
    public assigningTraits getEnemy2;
    public bool strongenemy;
    public bool isDead = false;
    PlayerCombatNew getEnemy;
    public HealthBarBehaviour hpBar;
    public GameObject thisEnemy;

    //valhalla choice system ui stuff vvvvvvv

    // Start is called before the first frame update
    void Start()
    {
       
        currentHealth = maxHealth;
        hpBar.SetHealth(currentHealth, maxHealth);
        UIData = FindObjectOfType<UI>();
        
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
        getEnemy2.lastEnemy = thisEnemy;
        if (currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        //Debug.Log("enemy dies");
        UIData.deathCounter++;
        isDead = true;

    }


   
    IEnumerator ApplyDamageColor(){
        enemySprite.GetComponent<SpriteRenderer>().material.color = damageColor;
        yield return new WaitForSeconds(0.5f);
        enemySprite.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
