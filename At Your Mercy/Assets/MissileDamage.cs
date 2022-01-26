using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileDamage : MonoBehaviour
{
     private PlayerCombatNew player;
     public int damageToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCombatNew>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && !player.isInvulnerable){
            player.TakeDamage(damageToPlayer);
        }
        Destroy(GetComponentInParent<Rigidbody2D>().gameObject);
    }
}
