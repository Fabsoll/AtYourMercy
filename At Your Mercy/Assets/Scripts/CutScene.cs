using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    GameObject valkyrie;
    GameObject valkyrieSound;
    TraitCalculator traitCalc;
    // Start is called before the first frame update
    void Start()
    {
        //traitCalc = GameObject.FindGameObjectWithTag("traitcalculator").GetComponent<TraitCalculator>();
        valkyrie = GameObject.FindGameObjectWithTag("Player");
        valkyrie.transform.position = new Vector3(0, -0, 0);
        valkyrieSound = GameObject.Find("dontDestroyThese/Valkyrie/brunnhilde audio");
        valkyrieSound.SetActive(true);

        valkyrie.GetComponent<PlayerCombatNew>().maxHealth = traitCalc.valhallaHP;

        //valkyrie.GetComponent<PlayerCombatNew>().currentHealth = traitCalc.valhallaHP;
    }
    // Update is called once per frame
    void Update()
    {

    }

    
}
