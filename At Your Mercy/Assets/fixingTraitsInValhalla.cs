using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixingTraitsInValhalla : MonoBehaviour
{
    public PlayerCombatNew brunnStats;
    public TraitCalculator traitCalc;
    // Start is called before the first frame update
    void Start()
    {
        brunnStats.currentHit = 0;
        brunnStats.currentHealth = traitCalc.valhallaHP;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
