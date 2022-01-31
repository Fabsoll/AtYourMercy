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
    public GameObject dashParticles;
    public CharacterController2D playerController;



    // Start is called before the first frame update
    void Start()
    {
        dashParticles = GameObject.Find("dontDestroyThese/Valkyrie/dash particles");

        dashParticles.GetComponent<ParticleSystem>().Stop();
        //playerController = FindObjectOfType<CharacterController2D>();
        c = GetComponent<Renderer>().material.color;
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("is player faced right: " + playerController.m_FacingRight);
        if(!inCooldown){
            if(direction == 0){
                if(Input.GetButtonDown("dash")){
                    direction = 1;
                }
            }

            else{
               if(dashTime <= 0){
                   direction = 0;
                   dashTime = startDashTime;
                   rb.velocity = Vector2.zero;
                }
               else{
                   Physics2D.IgnoreLayerCollision(8, 7, true);
                   Physics2D.IgnoreLayerCollision(8, 13, true);
                   dashTime -= Time.deltaTime;
                   if(direction == 1){
                       if(playerController.m_FacingRight){
                            rb.AddForce(Vector2.right * dashSpeed);
                       }
                       else if(!playerController.m_FacingRight){
                           rb.AddForce(Vector2.left * dashSpeed);
                       }
                       
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
        Physics2D.IgnoreLayerCollision(8, 7, true);
        Physics2D.IgnoreLayerCollision(8, 13, true);
        //c.a = 0.5f;
        //GetComponent<Renderer>().material.color = c;
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreLayerCollision(8, 7, false);
        Physics2D.IgnoreLayerCollision(8, 13, false);
        //c.a = 1f;
        //GetComponent<Renderer>().material.color = c;
    }
        
}
    

