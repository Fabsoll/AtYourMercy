using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    [SerializeField] float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            StartCoroutine(resetPlatform());
        }
        IEnumerator resetPlatform()
        {
            yield return new WaitForSecondsRealtime(0.5f);

            effector.rotationalOffset = 0;
        }
        if(Input.GetKey(KeyCode.S))
        {
            if(waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = 0f;
            }
            else{
                waitTime -= Time.deltaTime;
            }
        }
        if(Input.GetButtonDown("Jump")||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.LeftAlt)){
            effector.rotationalOffset = 0f;
        }
    }
}
