using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    float currentHealth;
    float maxHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0){
            //gameObject.SetActive(false);
        }
    }
}
