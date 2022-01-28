using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    private float maxHealth;
    PlayerCombatNew playerCombatNew;

    public UI UIData;

    // Start is called before the first frame update
    void Awake()
    {
        healthBar = GetComponent<Image>();
        playerCombatNew = FindObjectOfType<PlayerCombatNew>();
    }

    private void Start() {
        currentHealth = playerCombatNew.maxHealth;
        maxHealth = playerCombatNew.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = playerCombatNew.currentHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }
}
