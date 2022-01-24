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
        if(other.gameObject.tag == "Player"){
            Rigidbody2D otherRB = other.gameObject.GetComponent<Rigidbody2D>();
            //otherRB.AddForce((Vector2.up) * pushForce);
            Vector3 direction =  new Vector3(Mathf.Cos(90 - transform.eulerAngles.z * Mathf.Deg2Rad), 0 ,Mathf.Sin(90 - transform.eulerAngles.y * Mathf.Deg2Rad) * -1);
            otherRB.AddForce(direction * pushForce);
            //StartCoroutine(StopDash(otherRB));
        }
    }

    private IEnumerator StopDash(Rigidbody2D otherRB){
        yield return new WaitForSeconds(0.3f);
        otherRB.velocity = Vector2.zero;
    }
}
