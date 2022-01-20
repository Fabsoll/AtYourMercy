using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBehaviour : MonoBehaviour
{
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;

    private Animator anim;
    private float distance;
    private bool cooling;
    private float intTimer;
    private bool attackMode;

    bool flip = true;
    // Start is called before the first frame update
    void Start()
    {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!attackMode){
            Move();
        }

        if(!InsideOfLimits() && !inRange /*&& !anim.GetCurrentAnimatorStateInfo(0).IsName("enemy_1_attack")*/){
            SelectTarget();
        }

        Wait();
    }

    void Move(){
        anim.SetBool("canWalk", true);
        //if(!anim.GetCurrentAnimatorStateInfo(0).IsName("enemy_1_attack")){
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        //}
    }

    void Attack(){
        timer = intTimer;
        attackMode = true;
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }
    void StopAttack(){
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    private bool InsideOfLimits(){
        return transform.position.x > leftLimit.position.x && transform.position.x < rightLimit.position.x;
    }

    public void SelectTarget(){
        float distanceToLeft = Vector2.Distance(transform.position, leftLimit.position);
        float distanceToRight = Vector2.Distance(transform.position, rightLimit.position);

        if(distanceToLeft > distanceToRight){
            target = leftLimit;
        }
        else{
            target = rightLimit;
        }
        Flip();
    }

    void Wait(){
        if(Vector2.Distance(transform.position, target.position) == 0){
            Debug.Log("awdwdawdawdadaw");
        }
    }

    public void Flip(){
        Vector3 rotation = transform.eulerAngles;
        if(transform.position.x > target.position.x){
            rotation.y = 180f;
        }
        else{
            rotation.y = 0f;
        }
        transform.eulerAngles = rotation;
    }
    
    IEnumerator WaitPatrol(){
        flip = true;
        yield return new WaitForSeconds(2f);
    }
}
