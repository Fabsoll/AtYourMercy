using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFly : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D bossRb;
    public float speed;
    public Vector3 offset;
    Vector2 target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bossRb = animator.GetComponent<Rigidbody2D>();
        //target = new Vector2(player.position.x, bossRb.position.y + offset.y);
        //target = new Vector2(player.position.x, bossRb.position.y + offset.y);
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, player.position.y + offset.y);
        Vector2 newPos = Vector2.MoveTowards(bossRb.position, target, speed * Time.fixedDeltaTime);
        bossRb.MovePosition(newPos);
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
