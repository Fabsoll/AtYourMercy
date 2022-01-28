using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private Rigidbody2D playerRB;
    private CircleCollider2D playerBox;

    public LayerMask jumpableGround;
    //Refenrences
    public float movementSpeed = 20f;
    private float moveX;
    private Animator playerAnim;
    //public float speedMultiplier;

    private bool jump = false;
    private bool run = false;

    public GameObject icon;
    public AudioSource walk;
    public float walkVolume;
    private bool onAir = false;
    public AudioSource jumpSound;
    // Start is called before the first frame update

    void Start()
    {
        playerBox = GetComponent<CircleCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        walk.Play();
        walk.loop = true;
        walk.volume = 0;
        //playerAnim.keepAnimatorControllerStateOnDisable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!isMoving){
        //    playerRB.velocity = Vector2.zero;
        //    Debug.Log("wadawd");
        //}
        //Run();
        moveX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        playerAnim.SetFloat("speed", Mathf.Abs(moveX));

        if (playerRB.velocity.y > -1 && playerRB.velocity.y < 1 && !onAir)
        {
            walk.volume = walkVolume;
            Debug.Log("sound");
        }
        else{
            walk.volume = 0;
            Debug.Log("no sound");
        }
        

        // if (playerRB.velocity.x == 0){
        //     {
        //         run = false;
        //         //Debug.Log("stop");
        //         playerAnim.SetBool("isRunning", false);
        //     }
        // }
        if (Input.GetButtonDown("valkyrie jump")){
            onAir = true;
            jump = true;
            jumpSound.Play();
            playerAnim.SetBool("isJumping", true);
        }

        if (playerRB.velocity.x == 0)
        {
            run = false;
            playerAnim.SetBool("isRunning", false);
            walk.volume = 0;
            
        }
            if (Input.GetButtonDown("valkyrie running")){
                if (run == false)
                {
                    run = true;
                    playerAnim.SetBool("isRunning", true);
                    
                }
                else
                {
                    run = false;
                    playerAnim.SetBool("isRunning", false);
                }
        }
    }

    public void OnLanding(){
        playerAnim.SetBool("isJumping", false);
    }

    private void FixedUpdate() {
        controller.Move(moveX * Time.fixedDeltaTime, run, jump);
        jump = false;
    }

    //private void Jump()
    //{
        // Jumping block
        //if (Input.GetButtonDown("Jump") && IsGrounded())
        //{
        //    playerAnim.SetBool("isJumping", true);
        //    playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        //}
        //else if(!IsGrounded()){
        //    playerAnim.SetBool("isJumping", false);
        //}
    //}

    // private void Run()
    // {
    //     float moveX = Input.GetAxisRaw("Horizontal");
    //     //playerRB.velocity = new Vector3(moveX * movementSpeed * speedMultiplier, playerRB.velocity.y, 0);
    //     playerAnim.SetFloat("speed", Mathf.Abs(moveX));
        

    //     if(Input.GetKey(KeyCode.LeftShift) && moveX != 0){

    //     }

    //     else if (moveX < 0)
    //     {
    //         transform.eulerAngles = new Vector3(0, -180, 0);
    //     }
    //     else if (moveX > 0)
    //     {
    //         transform.eulerAngles = new Vector3(0, 0, 0);
    //     }
    // }

    // public bool IsGrounded(){
    //     return Physics2D.CircleCast(playerBox.bounds.center, playerBox.radius, Vector2.down, .1f, jumpableGround);
    // }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")||other.gameObject.CompareTag("PlatformGroun") || other.gameObject.CompareTag("fragileGirl")){
            playerAnim.SetBool("isJumping", false);
            onAir = false;
        }
        
    }
}
