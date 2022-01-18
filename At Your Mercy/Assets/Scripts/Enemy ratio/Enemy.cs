using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public Color damageColor;
    public SpriteRenderer enemySprite;

    private UI userInterfaceData;


    public HealthBarBehaviour hpBar;

    // Start is called before the first frame update
    void Start()
    {
        userInterfaceData = FindObjectOfType<UI>();
        currentHealth = maxHealth;
        hpBar.SetHealth(currentHealth, maxHealth);
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
        userInterfaceData.deaths ++;
        this.gameObject.SetActive(false);
    }

    IEnumerator ApplyDamageColor(){
        enemySprite.GetComponent<SpriteRenderer>().material.color = damageColor;
        yield return new WaitForSeconds(0.5f);
        enemySprite.GetComponent<SpriteRenderer>().material.color = Color.white;
    }
}
