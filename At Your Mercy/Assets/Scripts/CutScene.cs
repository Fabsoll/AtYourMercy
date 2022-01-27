using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CutScene : MonoBehaviour
{
    GameObject valkyrie;
    CinemachineVirtualCamera vCam;
    // Start is called before the first frame update
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        valkyrie = GameObject.FindGameObjectWithTag("Player");
        valkyrie.transform.position = new Vector3(0.146534026f, -4.39093113f, 0);
        vCam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {

    }

    
}
