using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicText : MonoBehaviour
{

    public TextMeshProUGUI traits;
    public TextMeshProUGUI deathcount;
    public TextMeshProUGUI hpnumber;
    //int deathcounter;
    //int hpnum;

    //public UI UIData;
    private PlayerCombatNew player;
    private GameObject[] enemies;
   

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerCombatNew>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Debug.Log(UIData.deathCounter);

    }

    // Update is called once per frame
    void Update()
    {
        hpnumber.text = player.currentHealth.ToString();

        //hpnumber.text = hpnum.ToString();
        
    }
}
