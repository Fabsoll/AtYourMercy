using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCombat : MonoBehaviour
{
    [SerializeField] float pushForce;
    [SerializeField] float invulnerableTime;
    [SerializeField] Color damageColor;
    private Rigidbody2D playerRB;
    private float timeBtwAttack;
    private Animator playerAnim;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask whatIsEnemy;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;
    public string valhalla;

    Color c;

    

    public int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        c = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

        if(health <= 0){
            Debug.Log("Death");
            SceneManager.LoadScene("bossfight");
        }
    }



   



    private void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("attack");
                Collider2D[] enemiesDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemy);
                playerAnim.SetTrigger("attack");
                for (int i = 0; i < enemiesDamage.Length; i++)
                {
                    if(enemiesDamage[i].gameObject.tag == "Enemy"){
                        enemiesDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                        enemiesDamage[i].GetComponent<Rigidbody2D>().AddForce((enemiesDamage[i].transform.position - this.transform.position) * pushForce);
                    }
                }
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPos.position, new Vector2(attackRangeX, attackRangeY));    
    }

    public void TakeDamage(int damage){
        health -= damage;
        StartCoroutine(DamageColor());
        StartCoroutine(GetInvulnerable());
        StartCoroutine(StopMoving());
    }

    IEnumerator DamageColor(){
        gameObject.GetComponent<SpriteRenderer>().color = damageColor;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    IEnumerator GetInvulnerable(){
        Physics2D.IgnoreLayerCollision(7, 8, true);
        c.a = 0.5f;
        GetComponent<Renderer>().material.color = c;
        yield return new WaitForSeconds(invulnerableTime);
        Physics2D.IgnoreLayerCollision(7, 8, false);
        c.a = 1f;
        GetComponent<Renderer>().material.color = c;
    }

    IEnumerator StopMoving(){
        yield return new WaitForSeconds(0.1f);
        playerRB.velocity = Vector2.zero;
    }


}
