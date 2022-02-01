using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    GameObject valkyrie;
    GameObject valkyrieSound;
    TraitCalculator traitCalc;
    GameObject hpBar;
    GameObject heavybreathing;
    // Start is called before the first frame update
    void Start()
    {
        //traitCalc = GameObject.FindGameObjectWithTag("traitcalculator").GetComponent<TraitCalculator>();
        valkyrie = GameObject.FindGameObjectWithTag("Player");
        valkyrie.transform.position = new Vector3(0, -0, 0);
        valkyrieSound = GameObject.Find("dontDestroyThese/Valkyrie/brunnhilde audio");
        heavybreathing = GameObject.Find("dontDestroyThese/Valkyrie/brunnhilde audio/heavy breathing");

        valkyrieSound.SetActive(true);
        heavybreathing.SetActive(false);
        
        valkyrie.GetComponent<PlayerCombatNew>().maxHealth = traitCalc.valhallaHP;
        hpBar = GameObject.Find("dontDestroyThese/ShapeShiftingUI");
        hpBar.SetActive(true);

        //valkyrie.GetComponent<PlayerCombatNew>().currentHealth = traitCalc.valhallaHP;
    }
    // Update is called once per frame
    void Update()
    {

    }

    
}
