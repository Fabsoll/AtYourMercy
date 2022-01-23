using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternBehaviour : MonoBehaviour
{
    private Transform playerPos;

    public GameObject LightningAttack;
    public float delay;
    private float lastCast;
    bool isAbleToSpawn = true;

    public float gapBetweenLighting;

    public bool castLightning = false;
    private bool isRecharged = true;

    // Start is called before the first frame update
    void Start()
    {
        lastCast = 0;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(castLightning && isRecharged){
            StartCoroutine(SpawnLightningWithDelay());
        }
    }

    private IEnumerator SpawnLightningWithDelay(){
        isRecharged = false;
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
        yield return new WaitForSeconds(delay);
    }
}
