using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraitCalculator : MonoBehaviour
{

    public int valhallaHP;
    public int Deathcount;
    public int valhallaCount;
    public string newTrait;
    public string oldTraits;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(valhallaHP);
    }


}
