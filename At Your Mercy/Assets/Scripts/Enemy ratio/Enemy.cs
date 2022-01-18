using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public Color damageColor;
    public SpriteRenderer enemySprite;

    private UI UIData;

    public HealthBarBehaviour hpBar;

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

        if(currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        //Debug.Log("enemy dies");
        UIData.deathCounter++;
        this.gameObject.SetActive(false);
    }

    IEnumerator ApplyDamageColor(){
        enemySprite.GetComponent<SpriteRenderer>().material.color = damageColor;
        yield return new WaitForSeconds(0.5f);
        enemySprite.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
