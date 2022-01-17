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

    // Start is called before the first frame update
    void Start()
    {
        playerBox = GetComponent<CircleCollider2D>();
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        //playerAnim.keepAnimatorControllerStateOnDisable = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Run();
        moveX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        playerAnim.SetFloat("speed", Mathf.Abs(moveX));

        if(Input.GetKeyDown(KeyCode.Space)){
            jump = true;
            playerAnim.SetBool("isJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.LeftShift)){
            run = true;
            playerAnim.SetBool("isRunning", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) || playerRB.velocity.x == 0){
            run = false;
            playerAnim.SetBool("isRunning", false);
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
        if(other.gameObject.CompareTag("Ground")){
            playerAnim.SetBool("isJumping", false);
        }
        
    }
}
