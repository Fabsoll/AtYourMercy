using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ravenSpawner : MonoBehaviour
{
    private Transform bossPosition;
    public GameObject homingRaven;
    // Start is called before the first frame update
    void Start()
    {
        bossPosition = GameObject.Find("wotan").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
        
            float angle;
            angle = -45f;
            GameObject ravenInstance = Instantiate(homingRaven, bossPosition.position, Quaternion.identity);
            ravenInstance.transform.Rotate(new Vector3(0, 0, angle));
            angle = 0f;
            //isRecharged = true;
            ravenInstance = Instantiate(homingRaven, bossPosition.position, Quaternion.identity);
            ravenInstance.transform.Rotate(new Vector3(0, 0, angle));
            angle = 45f;
            ravenInstance = Instantiate(homingRaven, bossPosition.position, Quaternion.identity);
            ravenInstance.transform.Rotate(new Vector3(0, 0, angle));
            Debug.Log("SPAWN RAVENS");

        
        transform.position = bossPosition.position;
    }
}
