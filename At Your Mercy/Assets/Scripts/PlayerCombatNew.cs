using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCombatNew : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemylayers;

    public int attackDamage = 2;

    public int maxHealth = 100;
    public int currentHealth;
    public Color damageColor;
    public SpriteRenderer playerSprite;

    public bool isInvulnerable;
    public bool isAbleToAttack;
    public float attackCD;
    public float invulnerableTime;
    public GameObject wotan;
    public GameObject underlay;
    public GameObject fadetoblack;
    float fadeAmount;
    public bool fade = false;
    Color objectColor;
    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        isInvulnerable = false;
        isAbleToAttack = true;
        currentHealth = maxHealth;
        wotan.SetActive(false);
        underlay.SetActive(false);
        fadetoblack.SetActive(false);
        objectColor = fadetoblack.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("attack") && isAbleToAttack){
            StartCoroutine(attackCooling());
            Attack();
        }

        if (fade == true)
        {
            Time.timeScale = 0.2f;
            if (fadetoblack.GetComponent<Image>().color.a < 1)
            {

                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                fadetoblack.GetComponent<Image>().color = objectColor;


            }
            else
            {

                SceneManager.LoadSceneAsync("transition scene");
                SceneManager.UnloadSceneAsync("main");
                
            }
        }
        

        // if(isInvulnerable){
        //     Physics2D.IgnoreLayerCollision(6, 8, true);
        // }
    }
 
    void Attack(){
        // PLay attack anim
        animator.SetTrigger("attack");
        // Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylayers);
        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
        }
        // deal damage
    }

    private void OnDrawGizmosSelected() {
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        
        //Debug.Log("isInv");
        StartCoroutine(Invulnerability());
        StartCoroutine(ApplyDamageColor());


        if(currentHealth <= 0){
            Die();
        }
    }

    IEnumerator ApplyDamageColor(){
        playerSprite.GetComponent<SpriteRenderer>().material.color = damageColor;
        yield return new WaitForSeconds(0.5f);
        playerSprite.GetComponent<SpriteRenderer>().material.color = Color.white;
    }

    private void Die(){
        
//<<<<<<< Updated upstream
//=======
//>>>>>>> Stashed changes

        fadetoblack.SetActive(true);
        fade = true;
        Debug.Log("Player died");
    }

    IEnumerator waitBF()
    {
        yield return new WaitForSecondsRealtime(4);

//<<<<<<< Updated upstream
/////        Time.timeScale = 1;

//=======
        
//>>>>>>> Stashed changes
    }
    IEnumerator Invulnerability(){
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerableTime);
        isInvulnerable = false;
    }

    IEnumerator attackCooling(){
        isAbleToAttack = false;
        yield return new WaitForSeconds(attackCD);
        isAbleToAttack = true;
    }
}
