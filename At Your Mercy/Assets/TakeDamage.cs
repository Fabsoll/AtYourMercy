using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health;
    [SerializeField] Color damageColor;
    Color c;
    [SerializeField] float invulnerableTime;
    private Rigidbody2D playerRB;

    private PlayerCombat playerCombat;

    // Start is called before the first frame update
    void Start()
    {
        playerCombat = FindObjectOfType<PlayerCombat>();
        health = playerCombat.health;
        playerRB = GetComponent<Rigidbody2D>();
        c = GetComponent<Renderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        health = playerCombat.health;
        Debug.Log(health);
    }

    public void TakeDamageOnly(int damage){
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
