using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour
{
    public CharacterController2D controller;

    private Rigidbody2D playerRB;
    //Refenrences
    public float movementSpeedNormal;
    public float movementSpeedHeadDown;
    public float movementSpeed;
    private float moveX;
    private Animator playerAnim;
    
    
    private bool isHeadDown = false;
    private bool isAbleToMove = true;
    public GameObject icon;
    Animator fragileGirl;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerAnim.keepAnimatorControllerStateOnDisable = false;
        fragileGirl = GameObject.FindGameObjectWithTag("fragileGirl").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerAnim.GetCurrentAnimatorClipInfo(0)[0].clip.name);
        moveX = Input.GetAxis("Horizontal") * movementSpeed;
        playerAnim.SetFloat("speed", Mathf.Abs(moveX));

        if(Input.GetButtonDown("horse head")){
            if(!isHeadDown){
                StartCoroutine(movingDelay());
            }
            isHeadDown = !isHeadDown;
        }

        if(isHeadDown){
            playerAnim.SetBool("isHeadDown", true);
            movementSpeed = movementSpeedHeadDown;
            playerRB.mass = 200;
            Physics2D.IgnoreLayerCollision(8, 9, false);
            

        }
        else if(!isHeadDown){
            Physics2D.IgnoreLayerCollision(8, 9, true);
            playerAnim.SetBool("isHeadDown", false);
            playerRB.mass = 1;
            movementSpeed = movementSpeedNormal;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("fragileGirl") && isHeadDown == true)
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Striked");
            Debug.Log("fragile girl");
        }
    }
    private void FixedUpdate() {
        if(isAbleToMove)
            controller.Move(moveX * Time.fixedDeltaTime, false, false);
        else
            playerRB.velocity = new Vector2(0, playerRB.velocity.y);
    }


    private IEnumerator movingDelay(){
        isAbleToMove = false;
        float delay = .5f;
        yield return new WaitForSeconds(delay);
        isAbleToMove = true;
    }
}
