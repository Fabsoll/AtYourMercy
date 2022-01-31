using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageToBoss : MonoBehaviour
{
    private Boss boss;
    public int damageToBoss;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Boss"){
            boss.TakeDamage(damageToBoss);
        }
    }
}
