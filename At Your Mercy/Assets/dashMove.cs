using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

    bool inCooldown = false;
    public float cooldown;

    private Animator playerAnim;
    Color c;


    // Start is called before the first frame update
    void Start()
    {
        c = GetComponent<Renderer>().material.color;
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!inCooldown){
            if(direction == 0){
                if(Input.GetKey(KeyCode.A) && (Input.GetKeyDown(KeyCode.F))){
                    direction = 1;
                }
                else if(Input.GetKey(KeyCode.D) && (Input.GetKeyDown(KeyCode.F))){
                    direction = 2;
                }
            }

            else{
               if(dashTime <= 0){
                   direction = 0;
                   dashTime = startDashTime;
                   rb.velocity = Vector2.zero;
                }
               else{
                   Physics2D.IgnoreLayerCollision(6, 8, true);
                   dashTime -= Time.deltaTime;
                   if(direction == 1){
                       rb.velocity = Vector2.left * dashSpeed;
                       direction = 0;
                       playerAnim.SetTrigger("dash");
                       StartCoroutine(dashCooldown());
                       StartCoroutine(invulnerable());
                       
                    }
                    else if(direction == 2){
                        rb.velocity = Vector2.right * dashSpeed;
                        direction = 0;
                        playerAnim.SetTrigger("dash");
                        StartCoroutine(invulnerable());
                        StartCoroutine(dashCooldown());
                        
                    }
                }
            }
        }
    
    }

    private IEnumerator dashCooldown(){
        inCooldown = true;
        yield return new WaitForSeconds(cooldown);
        inCooldown = false;
    }

    private IEnumerator invulnerable(){
        Physics2D.IgnoreLayerCollision(6, 8, true);
        
        //c.a = 0.5f;
        //GetComponent<Renderer>().material.color = c;
        yield return new WaitForSeconds(0.3f);
        Physics2D.IgnoreLayerCollision(6, 8, false);
        //c.a = 1f;
        //GetComponent<Renderer>().material.color = c;
    }
        
}
    

