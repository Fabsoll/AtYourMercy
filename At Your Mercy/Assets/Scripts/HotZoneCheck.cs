using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotZoneCheck : MonoBehaviour
{
    private Enemy_behaviour enemyParent;
    private bool inRange;
    private Animator anim;

    private void Awake() {
        enemyParent = GetComponentInParent<Enemy_behaviour>();
        anim = GetComponentInParent<Animator>();
    }

    private void Update() {
        if(inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("enemy_1_attack")){
            enemyParent.Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Boss")){
            inRange = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Boss")){
            inRange = false;
            gameObject.SetActive(false);
            enemyParent.triggerArea.SetActive(true);
            enemyParent.inRange = false;
            enemyParent.SelectTarget();
        }
    }
}
