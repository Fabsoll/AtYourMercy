using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenMovement : MonoBehaviour
{
    public CharacterController2D controller;
    private ShapesController shapesController;

    private Rigidbody2D playerRB;
    //Refenrences
    public float movementSpeed = 20f;
    private float moveX;
    private Animator playerAnim;
    public float pushForce;


    private bool isDashing = false;
    private bool isInitialDashing = false;
    private bool isDiving = false;
    public float dashDuration;

    private int numberOfDashes;
    public int maxNumberOfDashes;
    private bool numberIncreased;

    public GameObject icon;
    // Start is called before the first frame update
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        shapesController = FindObjectOfType<ShapesController>();
    }
    private void Start() {
        playerRB.velocity = Vector2.zero;
        //isDashing = true;
        //if(isDashing){
        //    playerAnim.SetBool("isDashingUp", true);
        //    VerticalDashUp();
        //    StartCoroutine(DashEnd());
        //}
        //playerAnim.keepAnimatorControllerStateOnDisable = false;
    }

    private void OnEnable() {
        isDashing = true;
        playerAnim.SetBool("isDashingUp", true);
        numberOfDashes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(numberOfDashes < maxNumberOfDashes){
            moveX = Input.GetAxis("Horizontal") * movementSpeed;
            if(Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.F)){
                isDashing = true;
                //playerAnim.SetBool("isDashingUp", true);
                numberOfDashes++;
            }
            //numberOfDashes++;
        //}
        if(Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.F)){
            isDiving = true;
            playerAnim.SetBool("isDashingDown", true);
        }
        
    }

    private void FixedUpdate() {
        controller.Move(moveX * Time.fixedDeltaTime, false, false);
        if(isDashing && numberOfDashes <= maxNumberOfDashes){
            playerAnim.SetBool("isDashingUp", true);
            VerticalDashUp();
            StartCoroutine(DashEnd());
        }
        else if(isDiving){
            VerticalDashDown();
        }
    }

    public void OnLanding(){
        isDiving = false;
        shapesController.EnableOne(2);
    }
    public void OnUpping(){
        isDashing = false;
    }

    private void VerticalDashUp(){
        transform.Translate(Vector3.up * pushForce * Time.deltaTime);
    }

    private void VerticalDashDown(){
        transform.Translate(Vector2.down * pushForce * Time.deltaTime);
    }

    private IEnumerator DashEnd(){
        yield return new WaitForSeconds(dashDuration);
        //numberOfDashes++;
        playerAnim.SetBool("isDashingUp", false);
        playerRB.velocity = Vector2.zero;
        isDashing = false;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Ground"){
            isDiving = false;
            shapesController.EnableOne(2);

            //Debug.Log("awdawdawdawdawd");
        }
    }

    
    //public bool IsGrounded(){
    //    return Physics2D.BoxCast(playerBox.bounds.center, playerBox.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    //}
}
