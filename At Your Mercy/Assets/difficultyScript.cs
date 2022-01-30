using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class difficultyScript : MonoBehaviour
{

    GameObject valkyrieSound;
    private GameObject[] enemies;
    //private GameObject[] enemyDamage;
    int difficultyHealth;
    public int difficultyDamage;

    TraitCalculator traitCalc;
    public bool easy;
    public bool medium;
    public bool hard;
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        
        traitCalc = GameObject.Find("dontDestroyThese/traitcalc").GetComponent<TraitCalculator>();
        this.gameObject.SetActive(true);
        valkyrieSound = GameObject.Find("dontDestroyThese/Valkyrie/brunnhilde audio");
        valkyrieSound.SetActive(false);
        enemies = GameObject.FindGameObjectsWithTag("EnemyParent");
        //enemyDamage = GameObject.FindGameObjectsWithTag("EnemyDamageDeal");
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneName == "tutorial")
        {
            Easy();

        }
    }

    public void Easy()
    {
        //how the game should be easier
        easy = true;
        medium = false;
        hard = false;
        difficultyHealth = 25;
        traitCalc.killingThreshold = 15;
        closeScreen();
        
        
    }
    public void Medium()
    {
        ////how the game should be normally
        //easy = true;
        medium = true;
        easy = false;
        hard = false;
        traitCalc.killingThreshold = 10;
        difficultyHealth = 50;
        closeScreen();
    }
    public void Hard()
    {
        ////how the game should be harder
        //easy = true;
        //medium = true;
        hard = true;
        medium = false;
        easy = false;
        traitCalc.killingThreshold = 5;
        difficultyHealth = 100;
        closeScreen();
    }

    void closeScreen()
    {
    //    int test = 0;
    //    foreach (GameObject d in enemyDamage)
    //    {
    //        test++;
    //        //DamageDeal dmg;
    //        //dmg = d.GetComponent<DamageDeal>();

    //        //if (dmg.wolfEnemy == true)
    //        //{
    //        //    difficultyDamage /= 2;
    //        //}
    //        //if (dmg.strongEnemy == true)
    //        //{
    //        //    difficultyDamage *= 2;
    //        //}
    //        //dmg.damageToPlayer = difficultyDamage;
    //    }
        foreach (GameObject e in enemies)
        {

            Enemy enemy;
            enemy = e.GetComponent<Enemy>();

            enemy.maxHealth = difficultyHealth;
            if (enemy.strongenemy == true)
            {
                enemy.maxHealth *= 2;
                
            }
            enemy.currentHealth = enemy.maxHealth;
            enemy.hpBar.SetHealth(enemy.currentHealth, enemy.maxHealth);

        }
        //Debug.Log(test);
        valkyrieSound.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
