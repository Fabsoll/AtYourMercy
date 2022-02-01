using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public bool isWolf;
    public int maxHealth;
    public int currentHealth;
    public Color damageColor;
    public SpriteRenderer enemySprite;
    private UI UIData;
    public assigningTraits getEnemy2;
    public bool strongenemy;
    public bool isDead;
    PlayerCombatNew getEnemy;
    public HealthBarBehaviour hpBar;
    public GameObject thisEnemy;

    public AudioSource audioS;

    //valhalla choice system ui stuff vvvvvvv

    // Start is called before the first frame update
    void Start()
    {
        if (isWolf)
        {
            Debug.Log("found it");
        }

        currentHealth = maxHealth;
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

        if (isWolf == false)
        {
            getEnemy2.lastEnemy = thisEnemy;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        else
        {
            if (currentHealth <= 0)
            {
                this.gameObject.SetActive(false);
            }
        }

        Debug.Log(currentHealth);
        
    }
    private void OnDisable()
    {
        //if (isWolf)
        //{
        //    audioS.volume = 1;
        //    audioS.Play();
        //    Debug.Log("woowowo");
        //}
        isDead = false;
    }
    void Die(){
        Debug.Log("death");
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
