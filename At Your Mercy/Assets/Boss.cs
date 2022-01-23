using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool isFlipped = true;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NumberEverySecond", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
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
}
