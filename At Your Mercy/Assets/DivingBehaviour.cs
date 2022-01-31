using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingBehaviour : StateMachineBehaviour
{
    public Vector3 offset;
    public float speed;

    private Transform playerPos;
    //private Transform bossPos;
    private Rigidbody2D bossRB;
    bool isSearching = false;

    Vector2 target;
    Vector2 newPos;
    float time;
    float timeDelay;

    private Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss>();
        boss.isCasting = true;
        bossRB = animator.GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //bossPos = animator.GetComponent<Rigidbody2D>().gameObject.transform;
        target = new Vector2(bossRB.position.x, playerPos.position.y + offset.y);
        //newPos = Vector2.MoveTowards(bossRB.position, target, speed * Time.fixedDeltaTime);
        //bossRB.MovePosition(newPos);
        isSearching = true;
        timeDelay = 4f;
        time = 0;
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.isCasting = true;
        time = time + Time.deltaTime;
        if(animator.gameObject.transform.position.y < target.y - .1f && isSearching){
            target = new Vector2(playerPos.position.x, playerPos.position.y + offset.y);
            newPos = Vector2.MoveTowards(bossRB.position, target, speed * Time.fixedDeltaTime);
            bossRB.MovePosition(newPos);
            bossRB.transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
        else if(animator.gameObject.transform.position.y >= target.y - .1f && time >= timeDelay){
            time = 0;
            isSearching = false;
            bossRB.transform.eulerAngles = new Vector3(0f, 0f, 0f);
            //Debug.Log("gay");
            //isDiving = true;
            //target = new Vector2(playerPos.position.x, playerPos.position.y);
            //newPos = Vector2.MoveTowards(bossRB.position, target, speed * Time.fixedDeltaTime);
            //bossRB.MovePosition(newPos);
            bossRB.AddForce(Vector2.down * speed * 8000);
        }
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.isCasting = false;
    }

    private IEnumerator DelayDiving(){
        yield return new WaitForSeconds(4f);
        newPos = Vector2.MoveTowards(bossRB.position, playerPos.position, speed * Time.fixedDeltaTime);
        bossRB.MovePosition(newPos);
    }
}
