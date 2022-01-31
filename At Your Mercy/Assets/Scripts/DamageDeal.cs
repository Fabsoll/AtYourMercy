using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeal : MonoBehaviour
{
    private PlayerCombatNew player;
    public int damageToPlayer;
    float destroyTime;
    //int difficultyDamage;
    difficultyScript damage;

    // Start is called before the first frame update
    void Start()
    {

        //difficultyDamage = 5;
        player = FindObjectOfType<PlayerCombatNew>();
    //    destroyTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
    }

    // Update is called once per frame
    void Update()
    {
        //if (damage.easy)
        //{

        //    if (damage.medium)
        //    {
        //        difficultyDamage *= 2;

        //        if (damage.hard)
        //        {
        //            difficultyDamage *= 2;
        //        }
        //    }
        //}
        //if (strongEnemy)
        //{
        //    difficultyDamage *= 2;

        //}
        //if (wolfEnemy)
        //{
        //    difficultyDamage /= 2;
        //}
        //damageToPlayer = difficultyDamage;


        //StartCoroutine(DestroyIfPassed());
        //if(isDestroyable){
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("Player") && !player.isInvulnerable){
            player.TakeDamage(damageToPlayer);
        }
        //if(other.gameObject.CompareTag("Raven")){
            //other.gameObject.TakeDamage(damageToPlayer);
        //}
        
    }
    

    private IEnumerator DestroyIfPassed(){
        yield return new WaitForSeconds(destroyTime);
    }

    

}
