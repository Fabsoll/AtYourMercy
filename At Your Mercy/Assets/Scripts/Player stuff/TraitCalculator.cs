using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitCalculator : MonoBehaviour
{
    public float valhallaTextCount;
    public bool lazyTrait;
    public int valhallaHP;
    public int valhallaBaseHP;
    public int Deathcount;
    public int valhallaCount;
    public int traitCount;
    public string newTrait;
    public string oldTraits;
    PlayerCombatNew brunnTrait;
    public bool caringTrait;
    public bool independentTrait;
    public bool vengefulTrait;
    public int vengefulTraitNumber;
    public int invulnerabilityCount;
    public int killingThreshold;
    public int caringDamage;
    public int independentDamage;
    public int lazyNumber;
    // Start is called before the first frame update
    void Start()
    {
        brunnTrait = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatNew>();
        caringDamage = 0;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(valhallaHP);

        if (caringTrait)
        {
            caringDamage = 3 * valhallaCount;
        }
        if (independentTrait)
        {
            independentDamage = 3 * traitCount;
        }
        if (lazyTrait)
        {
            valhallaHP = valhallaBaseHP + (lazyNumber * valhallaCount);
        }
        //if (caringTrait)
        //{
        //    brunnTrait.baseAttack2 = (brunnTrait.baseAttack + caringDamage);

        //}
        //if (independentTrait)
        //{
        //    brunnTrait.baseAttack += 3 * traitCount;

        //}
        //if (lazyTrait)
        //{
        //    valhallaHP += (4 * valhallaCount);
        //}
    }


}
