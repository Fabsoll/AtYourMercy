using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitCalculator : MonoBehaviour
{

    public int valhallaHP;
    public int Deathcount;
    public int valhallaCount;
    public int traitCount;
    public string newTrait;
    public string oldTraits;
    PlayerCombatNew brunnTrait;
    public bool caringTrait;
    public bool independentTrait;
    // Start is called before the first frame update
    void Start()
    {
        brunnTrait = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombatNew>();
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
            brunnTrait.baseAttack += 1 * valhallaCount;

        }
        if (independentTrait)
        {
            brunnTrait.baseAttack += 1 * traitCount;

        }
    }


}
