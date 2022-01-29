using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveBehaviour : MonoBehaviour
{
    private float time;
    public float cooldown = 1f;
    private int test = 0;

    private Vector3 spawnPos1;
    private Vector3 spawnPos2;
    public float distance = 1f;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        spawnPos1 = transform.position;
        spawnPos2 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        time = time + 1f * Time.deltaTime;
        if(time >= cooldown){
            time = 0;
            Vector3 newPosRight = spawnPos1 + new Vector3(distance, 0f, 0f);
            Vector3 newPosLeft = spawnPos2 - new Vector3(distance, 0f, 0f);
            spawnPos1 = newPosRight;
            spawnPos2 = newPosLeft;
            //Debug.Log(spawnPos2);
            //Debug.Log("==============================");
            Instantiate(explosion, new Vector2(spawnPos1.x, spawnPos1.y), Quaternion.identity);
            //spawnPos = newPosLeft;
            Instantiate(explosion, new Vector2(spawnPos2.x, spawnPos2.y), Quaternion.identity);
            //Debug.Log(spawnPos);

            if(newPosRight.x >= (transform.position + new Vector3(30f, 0, 0)).x){
                Destroy(gameObject);
            }
        }
    }

}
