using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float pushForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
        otherRB.AddForce((other.transform.position - this.transform.position).normalized * pushForce);
    }
}
