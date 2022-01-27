using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class bossfightCamera : MonoBehaviour
{
    CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
