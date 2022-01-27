using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingBehaviour : StateMachineBehaviour
{
    public Vector3 offset;
    public float speed;

    private Transform playerPos;
    private Transform bossPos;
    private Rigidbody2D bossRB;
    bool isDiving = false;
    bool isSeraching = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        bossPos = animator.GetComponent<Rigidbody2D>().transform;
        Vector2 target = new Vector2(bossPos.position.x, bossPos.position.y + offset.y);
        Vector2 newPos = Vector2.MoveTowards(bossRB.position, target, speed * Time.fixedDeltaTime);
        //bossRb.MovePosition(newPos);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
