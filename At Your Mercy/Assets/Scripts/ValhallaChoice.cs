using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ValhallaChoice : MonoBehaviour
{
    
    public Text slain;
    public TextMeshProUGUI valhallaHP;
    int lastName;
    string name;
    public TraitCalculator TraitCalc;
    public TextMeshProUGUI valhallaCount;
    public TextMeshProUGUI traitlist;
    public GameObject shapeControllerUI;
    public GameObject underlay;
    public TextMeshProUGUI killCount;
    public AudioSource boom;
    public AudioSource walk;
    List<string> nameList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        walk.volume = 0;
        AudioListener.volume = 0.4f;
        underlay.SetActive(true);
        boom.volume = 1f;
        boom.Play();
        shapeControllerUI.SetActive(false);
        nameList.Add("Odger");
        nameList.Add("Arne");
        nameList.Add("Gudrun");
        nameList.Add("Hilda");
        nameList.Add("Halfdan");
        nameList.Add("Torsten");
        nameList.Add("Thurid");
        nameList.Add("svend");
        nameList.Add("Revna");
        nameList.Add("Yrsa");
        nameList.Add("skarde");
        nameList.Add("Leif");
        nameList.Add("Thyra");
        nameList.Add("Ivar");
        nameList.Add("Ragnar");
        nameList.Add("Gyndolfr");
        nameList.Add("Hallbjorn");
        nameList.Add("Nanettyr");
        RandomNameGenerator();
        slain.text = name + " slain.";
        valhallaHP.text = TraitCalc.valhallaHP.ToString();
        int i = 0;
        while (i < TraitCalc.valhallaCount)
        {
            valhallaCount.text +="1";
            i++;
        }
        killCount.text = TraitCalc.Deathcount.ToString();

        if (TraitCalc.oldTraits != "")
        {
            traitlist.text = TraitCalc.oldTraits;
        }
        

    }
    private void OnDisable()
    {
        underlay.SetActive(false);
        shapeControllerUI.SetActive(true);
    }
    public void RandomNameGenerator()
    {
        int nameIndex = Random.Range(0, 11);
        if (lastName == nameIndex)
        {
            RandomNameGenerator();
        }
        else
        {
            name = (nameList[nameIndex]);
        }

       
    }

}
