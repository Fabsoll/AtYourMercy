using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        destroyTime = GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
        Destroy(this.gameObject, destroyTime);
    }

    // Update is called once per fram
}
