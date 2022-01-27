using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    GameObject valkyrie;
    // Start is called before the first frame update
    void Start()
    {
        valkyrie = GameObject.FindGameObjectWithTag("Player");
        valkyrie.transform.position = new Vector3(0.146534026f, -4.39093113f, 0);
    }
    // Update is called once per frame
    void Update()
    {

    }

    
}
