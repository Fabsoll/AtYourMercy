using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool isFlipped = true;
    public Transform player;
    private BossHealthbarBehaviour healthBar;
    private bool isCasting;
    private int numberOfLighning = 0;

    float time;
    float timeDelay;

    public Animator bossAnimatorController;
    public AttackPatternBehaviour attackPatternBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        time = 0f;
        timeDelay = 1f;
        healthBar = FindObjectOfType<BossHealthbarBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isCasting){
            time = time + 1f * Time.deltaTime;
            if(time >= timeDelay){
                time = 0;
                if(NumberEverySecond() == 1){
                    bossAnimatorController.SetTrigger("LightningAttack");
                    StartCoroutine(StartDelaying(bossAnimatorController.GetCurrentAnimatorStateInfo(0).length));
                    StartCoroutine(LightningDelaying(bossAnimatorController.GetCurrentAnimatorStateInfo(0).length));
                    attackPatternBehaviour.castLightning = true;
                    //numberOfLighning++;
                    //attackPatternBehaviour.castLightning = false;
                }
                if(NumberEverySecond() == 2){
                    bossAnimatorController.SetTrigger("WindAttack");
                    StartCoroutine(StartDelaying(bossAnimatorController.GetCurrentAnimatorStateInfo(0).length));
                    //attackPatternBehaviour.castLightning = false;
                }
                //attackPatternBehaviour.castLightning = false;
                //Debug.Log(numberOfLighning);
                

            }
        }
        
        if(numberOfLighning >= 2 && !isCasting){
            Debug.Log("kneel");
            bossAnimatorController.SetTrigger("kneeling");
            StartCoroutine(StartDelaying(10f));
            numberOfLighning = 0;
        }
        //if(numberOfLighning == 2){
        //    numberOfLighning = 0;
        //}
        
        
    }
    
    IEnumerator StartDelaying(float time)
    {
        isCasting = true;
        yield return new WaitForSeconds(time);
        isCasting = false;
    }
    IEnumerator LightningDelaying(float time)
    {
        isCasting = true;
        yield return new WaitForSeconds(time);
        numberOfLighning++;
        isCasting = false;
    }

    public void LookAtPlayer(){
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped){
            transform.localScale = flipped;
            transform.Rotate(0, 180f, 0);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped){
            transform.localScale = flipped;
            transform.Rotate(0, 180f, 0);
            isFlipped = true;
        }
    }

    public int NumberEverySecond(){
        int min = 1;
        int max = 10;

        int result = Random.Range(min, max);
        //Debug.Log(result);
        return result;
    }

    public IEnumerator Test(){
        NumberEverySecond();
        yield return new WaitForSeconds(1f);
    }

    public void TakeDamage(int damage){
        health -= damage;
        healthBar.SetHealth(health, maxHealth);
        StartCoroutine(ApplyDamageColor());

        if (health <= 0){
            Die();
        }
    }

    IEnumerator ApplyDamageColor(){
        GetComponentInChildren<SpriteRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        GetComponentInChildren<SpriteRenderer>().material.color = Color.white;
    }

    private void Die(){
        gameObject.SetActive(false);
    }
}
