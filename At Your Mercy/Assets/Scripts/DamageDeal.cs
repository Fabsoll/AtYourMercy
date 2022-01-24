using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeal : MonoBehaviour
{
    private PlayerCombatNew player;
    public int damageToPlayer;

    float destroyTime;
    bool isDestroyable = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCombatNew>();
    //    destroyTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(DestroyIfPassed());
        //if(isDestroyable){
        //    Destroy(gameObject);
        //}
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") && !player.isInvulnerable){
            player.TakeDamage(damageToPlayer);
        }
        
    }

    private IEnumerator DestroyIfPassed(){
        yield return new WaitForSeconds(destroyTime);
        isDestroyable = true;
    }

    

}
