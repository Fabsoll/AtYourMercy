using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    private Vector3 startPos;
    public float distance = 1f;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + distance *  new Vector3(0, Mathf.Sin(Time.time * speed), 0);
    }
}
