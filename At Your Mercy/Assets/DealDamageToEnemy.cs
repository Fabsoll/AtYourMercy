using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToEnemy : MonoBehaviour
{
    public int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D enemy) {
        if(enemy.gameObject.CompareTag("Enemy")){
            enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
        }
        else if(enemy.gameObject.CompareTag("Boss")){
            //Debug.Log("damage?");
            enemy.GetComponent<Boss>().TakeDamage(attackDamage);
        }
    }
}
