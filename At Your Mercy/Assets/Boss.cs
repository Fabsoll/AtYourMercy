using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isFlipped = true;
    public Transform player;

    float time;
    float timeDelay;

    public Animator bossAnimatorController;
    public AttackPatternBehaviour attackPatternBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        timeDelay = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1f * Time.deltaTime;
        if(time >= timeDelay){
            time = 0;
            if(NumberEverySecond() == 1){
                bossAnimatorController.SetTrigger("LightningAttack");
                attackPatternBehaviour.castLightning = true;
                //attackPatternBehaviour.castLightning = false;
            }
            //attackPatternBehaviour.castLightning = false;
        
        }
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
        int min = 0;
        int max = 10;

        int result = Random.Range(min, max);
        Debug.Log(result);
        return result;
    }

    public IEnumerator Test(){
        NumberEverySecond();
        yield return new WaitForSeconds(1f);
    }
}
