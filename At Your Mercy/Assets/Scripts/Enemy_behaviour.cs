using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_behaviour : MonoBehaviour
{
    #region Public Variables
    //public Transform rayCast;
    //public LayerMask raycastMask;
    //public float rayCastLength;
    public float attackDistance;
    public float moveSpeed;
    public float timer;
    public Transform leftLimit;
    public Transform rightLimit;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange;
    public GameObject hotZone;
    public GameObject triggerArea;
    public AudioSource attack;
    #endregion

    #region Private Variables
    //private RaycastHit2D hit;
    //private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    //private bool inRange;
    private bool cooling;
    private float intTimer;
    #endregion

    private void Awake() {
        SelectTarget();
        intTimer = timer;
        anim = GetComponent<Animator>();
    }
    

    void Update()
    {
        if(!attackMode){
            Move();
        }

        if(!InsideOfLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("enemy_1_attack")){
            SelectTarget();
        }
        

        if(inRange){
            EnemyLogic();
        }
        
    }

    void EnemyLogic(){
        distance = Vector2.Distance(transform.position, target.position);
        if(distance > attackDistance){
            //Move();
            StopAttack();
        }
        else if(distance <= attackDistance & cooling == false){
            Attack();
        }
        if(cooling){
            Cooldown();
            anim.SetBool("Attack", false);
        }
    }


    void Move(){
        anim.SetBool("canWalk", true);
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("enemy_1_attack")){
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack(){
        timer = intTimer;
        attackMode = true;
        attack.Play();
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
    }

    void StopAttack(){
        cooling = false;
        attackMode = false;
        anim.SetBool("Attack", false);
    }

    public void TriggerCooling(){
        cooling = true;
    }

    public void Cooldown(){
        timer -= Time.deltaTime;
        if(timer <= 0 && cooling && attackMode){
            cooling = false;
            timer = intTimer;
        }
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
    
}
