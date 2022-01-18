using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DynamicText : MonoBehaviour
{

    public TextMeshProUGUI traits;
    public TextMeshProUGUI deathcount;
    public TextMeshProUGUI hpnumber;
    int deathcounter;
    int hpnum;
   

    // Start is called before the first frame update
    void Start()
    {
        int hpnum = GameObject.Find("uiscript").GetComponent<UI>().deaths * 5;
        int deathcounter = GameObject.Find("uiscript").GetComponent<UI>().deaths;

    }

    // Update is called once per frame
    void Update()
    {
        deathcount.text = deathcounter.ToString();

        hpnumber.text = hpnum.ToString();
        
    }
}
