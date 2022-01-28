using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCombatNew : MonoBehaviour
{
    public Animator animator;

    #region audio
    public AudioSource heavyBreath;
    public AudioSource hitOne;
    public AudioSource hitTwo;
    public AudioSource missOne;
    public AudioSource missTwo;
    public AudioSource death;
    public AudioSource enemyDmg1;
    public AudioSource enemyDmg2;
    public AudioSource getHit;
    #endregion

    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemylayers;
    public int baseAttackStart;
    int attackDamage;
    public int baseAttack;
    int critDamage;
    public int defense = 2;
    public int maxHealth = 100;
    public int currentHealth;
    public Color damageColor;
    public SpriteRenderer playerSprite;
    public GameObject Overlay;
    public bool isInvulnerable;
    public bool isAbleToAttack;
    public float attackCD;
    public float invulnerableTime;
    public GameObject fadetoblack;
    float fadeAmount;
    public bool fade = false;
    Color objectColor;
    public float fadeSpeed;
    int hitCount;
    int missCount;
    int doesItCrit;
    int critRate;
    public int critNumber;
    int doesItEvade;
    public int evadeNumber;
    int evadeChance;
    public GameObject shapeUI;
    public TraitCalculator traitCalc;
    int vengefulTraitNumberConverted;
    public assigningTraits thisEnemy;
    int currentHit;
    bool BrunnhildeDied;
    // Start is called before the first frame update
    void Start()
    {
        currentHit = 0;
        isInvulnerable = false;
        isAbleToAttack = true;
        currentHealth = maxHealth;
        fadetoblack.SetActive(false);
        objectColor = fadetoblack.GetComponent<Image>().color;
        hitCount = 1;
        missCount = 1;
        heavyBreath.playOnAwake = true;
        heavyBreath.loop = true;
        heavyBreath.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {

        baseAttack = baseAttackStart + traitCalc.caringDamage + traitCalc.independentDamage;
        if (Input.GetButtonDown("attack") && isAbleToAttack){
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
                fade = false;
                Time.timeScale = 1;
                SceneManager.LoadSceneAsync("transition scene");
                SceneManager.UnloadSceneAsync("main");
                
            }
        }
        if (traitCalc.Deathcount >= traitCalc.killingThreshold)
        {
            Die();
        }

        // if(isInvulnerable){
        //     Physics2D.IgnoreLayerCollision(6, 8, true);
        // }
    }
    
    void Attack(){
        // PLay attack anim
        animator.SetTrigger("attack");
        switch (missCount)
        {
            case 1:
                missOne.Play();
                missCount++;
                break;
            case 2:
                missTwo.Play();
                missCount--;
                break;



        }
        if (critNumber >= 6)
        {
            critNumber = 6;
        }
        //calculate critrate
        switch (critNumber)
        {
            case 0:
                critRate = 10000000;
                break;
            case 1:
                critRate = 20;
                break;
            case 2:
                critRate = 10;
                break;
            case 3:
                critRate = 7;
                break;
            case 4:
                critRate = 5;
                break;
            case 5:
                critRate = 4;
                break;
            case 6:
                critRate = 2;
                break;
        
        }
        //calculate if it crits
        doesItCrit = Random.Range(1, critRate);
        if (doesItCrit == 1)
        {
            attackDamage = 2 * baseAttack;
            Debug.Log("crit lol");
        }
        else
        {
            attackDamage = baseAttack;
        }
        // Detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylayers);
        foreach(Collider2D enemy in hitEnemies){
            if(enemy.gameObject.CompareTag("Enemy")){
                enemy.GetComponentInParent<Enemy>().TakeDamage(attackDamage);
                switch (hitCount)
                {
                    case 1:
                        hitOne.Play();
                        enemyDmg1.Play();
                        hitCount++;
                        break;
                    case 2:
                        hitTwo.Play();
                        enemyDmg2.Play();
                        hitCount--;
                        break;
                }
            }
            else if(enemy.gameObject.CompareTag("Boss")){
                //Debug.Log("damage?");
                enemy.GetComponent<Boss>().TakeDamage(attackDamage);
            }
            else if(enemy.gameObject.CompareTag("RavenMissle")){
                //Debug.Log("damage?");
                Destroy(enemy.GetComponentInParent<Rigidbody2D>().gameObject);
            }

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
        if (evadeNumber >= 6)
        {
            evadeNumber = 6;
        }
        switch (evadeNumber)
        {
            case 0:
                evadeChance = 10000000;
                break;
            case 1:
                evadeChance = 20;
                break;
            case 2:
                evadeChance = 10;
                break;
            case 3:
                evadeChance = 7;
                break;
            case 4:
                evadeChance = 5;
                break;
            case 5:
                evadeChance = 4;
                break;
            case 6:
                evadeChance = 3;
                break;
        }

        doesItEvade = Random.Range(1, evadeChance);
        if (doesItEvade != 1)
        {
            if (currentHit < traitCalc.invulnerabilityCount)
            {
                currentHit += 1;
                
            }
            else
            {
                currentHealth -= (damage - defense);
                if (traitCalc.vengefulTrait == true)
                {
                    if (traitCalc.vengefulTraitNumber >= 5)
                    {
                        traitCalc.vengefulTraitNumber = 5;
                    }
                    switch (traitCalc.vengefulTraitNumber)
                    {
                        case 1:
                            vengefulTraitNumberConverted = 5;
                            break;
                        case 2:
                            vengefulTraitNumberConverted = 4;
                            break;
                        case 3:
                            vengefulTraitNumberConverted = 3;
                            break;
                        case 4:
                            vengefulTraitNumberConverted = 2;
                            break;
                        case 5:
                            vengefulTraitNumberConverted = 1;
                            break;

                    }
                    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemylayers);
                    foreach (Collider2D enemy in hitEnemies)
                    {
                        if (enemy.gameObject.CompareTag("Enemy"))
                        {



                            enemy.GetComponentInParent<Enemy>().TakeDamage(damage / vengefulTraitNumberConverted);
                            Debug.Log("dealt damage back");
                        }
                    }
                }
                getHit.Play();
                //Debug.Log("isInv");
                StartCoroutine(Invulnerability());
                StartCoroutine(ApplyDamageColor());
            }
            

        }
        else
        {
            Debug.Log("evaded!!");
        }
       

        if (currentHealth <= 10)
        {
            heavyBreath.volume = 1;
        }
        if(currentHealth <= 0){
            BrunnhildeDied = true;
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
        shapeUI.SetActive(false);

        currentHealth += traitCalc.valhallaHP;
        maxHealth = currentHealth;
        if (BrunnhildeDied)
        {
            heavyBreath.Stop();
            death.Play();
            Debug.Log("Player died");
        }
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
