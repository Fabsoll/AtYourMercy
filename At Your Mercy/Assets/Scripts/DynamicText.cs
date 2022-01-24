using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class DynamicText : MonoBehaviour
{

    public TextMeshProUGUI traits;
    public TextMeshProUGUI deathcount;
    public TextMeshProUGUI hpnumber;
    public TextMeshProUGUI deathcounttotal;
    public TraitCalculator traitCalc;
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

        hpnumber.text = traitCalc.valhallaHP.ToString();
        
        deathcounttotal.text = traitCalc.Deathcount.ToString();
        //hpnumber.text = hpnum.ToString();
        string result = new string('1', traitCalc.valhallaCount) ;
        deathcount.text = result;
    }
    private void OnEnable()
    {
        //for (int i = 0; i < traitCalc.valhallaCount; i++)
        //{
        //    deathcount.text = "1";

    //}
    traits.text = traitCalc.oldTraits;
    }

}
