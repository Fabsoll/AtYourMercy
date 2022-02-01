using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendcounter : MonoBehaviour
{

    TraitCalculator traitCalc;
    int friendAmount;
    public GameObject[] friends;
    // Start is called before the first frame update
    void Start()
    {
        traitCalc = GameObject.Find("dontDestroyThese/traitcalc").GetComponent<TraitCalculator>();
        friendAmount = (10- traitCalc.valhallaCount);
        
        for (int i = 0;  i <= friendAmount; i++)
        {
            friends[i].SetActive(false);
            Debug.Log(i);
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(friends.Length);
        Debug.Log(friendAmount);
    }
}
