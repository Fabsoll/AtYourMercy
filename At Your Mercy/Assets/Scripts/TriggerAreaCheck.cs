using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAreaCheck : MonoBehaviour
{
    private Enemy_behaviour enemyParent;
    public bool isAlly;
    // Start is called before the first frame update
    void Awake()
    {
        enemyParent = GetComponentInParent<Enemy_behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && !isAlly){
            gameObject.SetActive(false);
            enemyParent.target = other.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
         else if(other.gameObject.CompareTag("Boss") && isAlly){
            gameObject.SetActive(false);
            enemyParent.target = other.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
