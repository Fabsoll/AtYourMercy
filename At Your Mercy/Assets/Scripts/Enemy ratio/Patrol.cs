using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform groundsDetection;
    private Rigidbody2D enemyRB;
    private BoxCollider2D enemyBox;

    public LayerMask whatIsGround;
        public LayerMask whatIsGround1;

    //public static bool isNotAttacking = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyBox = GetComponent<BoxCollider2D>();
        enemyRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsGrounded()){
            //if(isNotAttacking){
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            //}
            //enemyRB.velocity = Vector3.right * speed;

            RaycastHit2D groundInfo = Physics2D.Raycast(groundsDetection.position, Vector2.down, 0.1f, whatIsGround);
            if(groundInfo.collider ==  false){
                if(movingRight){
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRight = false;
                    //speed *= -1;
                }
                else{
                    
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    //speed *= -1;
                    movingRight = true;
                }
            }
        }

        if(Physics2D.Raycast(transform.position, transform.right, 2f, whatIsGround)){
            if(movingRight){
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else{
                    
                transform.eulerAngles = new Vector3(0, 0, 0);
                    //speed *= -1;
                movingRight = true;
            }
        }
        
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(enemyBox.bounds.center, enemyBox.bounds.size, 0f, Vector2.down, .1f, whatIsGround);
    }
}
