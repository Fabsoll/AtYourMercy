using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockwaveBehaviour : MonoBehaviour
{
    private float time;
    private float cooldown = 1f;

    private int test = 0;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1f * Time.deltaTime;
        if(time >= cooldown){
            time = 0;
            test++;
            Debug.Log(test);
        }
    }

    void Increase(){
        
    }

}
