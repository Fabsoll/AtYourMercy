using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternBehaviour : MonoBehaviour
{
    private Transform playerPos;
    private Transform bossPos;

    public GameObject LightningAttack;
    public GameObject RavenAttack;
    public float delay;

    public float gapBetweenLighting;

    public bool castLightning = false;
    public bool castRavens = false;
    private bool isRecharged = true;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        bossPos = GameObject.FindGameObjectWithTag("Boss").transform;
        SpawnFriends();
    }

    // Update is called once per frame
    void Update()
    {
        if(castLightning && isRecharged){
            StartCoroutine(SpawnLightningWithDelay());
        }
        if(castRavens && isRecharged){
            //StartCoroutine(SpawnRavensWithDelay());
            SpawnRavens();
        }
    }

    private IEnumerator SpawnLightningWithDelay(){
        //isRecharged = false;
        castLightning = false;
        int i = -1;
        Vector3 spawnPos = new Vector3(playerPos.position.x + (i * gapBetweenLighting), LightningAttack.transform.position.y, 0f);
        GameObject lightningInstance = Instantiate(LightningAttack, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        isRecharged = true;
        i++;
        spawnPos = new Vector3(playerPos.position.x + (i * gapBetweenLighting), LightningAttack.transform.position.y, 0f);
        lightningInstance = Instantiate(LightningAttack, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(delay);
        i++;
        spawnPos = new Vector3(playerPos.position.x + (i * gapBetweenLighting), LightningAttack.transform.position.y, 0f);
        lightningInstance = Instantiate(LightningAttack, spawnPos, Quaternion.identity);
        Debug.Log("SPAWN LIGHTNING");
        yield return new WaitForSeconds(delay);
    }
    // private IEnumerator SpawnRavensWithDelay(){
    //     //isRecharged = false;
    //     castRavens = false;
    //     float angle = -45f;
    //     Vector3 rotationOnSpawn = new Vector3(0, 0, angle);
    //     GameObject ravenInstance = Instantiate(RavenAttack, bossPos.position, Quaternion.identity);
    //     ravenInstance.transform.Rotate(rotationOnSpawn);
    //     //Debug.Log("SPAWN RAVEN");
    //     yield return new WaitForSeconds(delay);
    //     angle = 0f;
    //     rotationOnSpawn = new Vector3(0, 0, angle);
    //     ravenInstance = Instantiate(RavenAttack, bossPos.position, Quaternion.identity);
    //     ravenInstance.transform.Rotate(rotationOnSpawn);
    //     yield return new WaitForSeconds(delay);
    //     angle = 45f;
    //     rotationOnSpawn = new Vector3(0, 0, angle);
    //     ravenInstance = Instantiate(RavenAttack, bossPos.position, Quaternion.identity);
    //     ravenInstance.transform.Rotate(rotationOnSpawn);
    //     Debug.Log("SPAWN RAVEN");
    //     yield return new WaitForSeconds(delay);
    // }

    private void SpawnRavens(){
        castRavens = false;
        float angle;
        angle = -45f;
        GameObject ravenInstance = Instantiate(RavenAttack, bossPos.position, Quaternion.identity);
        ravenInstance.transform.Rotate(new Vector3(0, 0, angle));
        angle = 0f;
        ravenInstance = Instantiate(RavenAttack, bossPos.position, Quaternion.identity);
        ravenInstance.transform.Rotate(new Vector3(0, 0, angle));
        angle = 45f;
        ravenInstance = Instantiate(RavenAttack, bossPos.position, Quaternion.identity);
        ravenInstance.transform.Rotate(new Vector3(0, 0, angle));
        Debug.Log("SPAWN RAVENS");
        
    }

    private void SpawnFriends(){
        int numberOfFriends = GameObject.Find("traitcalc").GetComponent<TraitCalculator>().valhallaCount;
        Debug.Log("friends to spawn: " + numberOfFriends);
    }
}
