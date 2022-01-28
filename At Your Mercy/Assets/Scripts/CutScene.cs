using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    GameObject valkyrie;
    TraitCalculator traitCalc;
    // Start is called before the first frame update
    void Start()
    {
        //traitCalc = GameObject.FindGameObjectWithTag("traitcalculator").GetComponent<TraitCalculator>();
        valkyrie = GameObject.FindGameObjectWithTag("Player");
        valkyrie.transform.position = new Vector3(0, -0, 0);
        //valkyrie.GetComponent<PlayerCombatNew>().currentHealth = traitCalc.valhallaHP;
    }
    // Update is called once per frame
    void Update()
    {

    }

    
}
