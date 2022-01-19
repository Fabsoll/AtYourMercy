using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
<<<<<<< Updated upstream
using UnityEngine.UI;


public class ValhallaChoice : MonoBehaviour
{
    
    public Text slain;
    int lastName;
    string name;
    
    List<string> nameList = new List<string>();
=======

public class ValhallaChoice : MonoBehaviour
{

    public TextMeshProUGUI slain;

>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        nameList.Add("Odger");
        nameList.Add("Arne");
        nameList.Add("Gudrun");
        nameList.Add("Hilda");
        nameList.Add("Halfdan");
        nameList.Add("Torsten");
        nameList.Add("Thurid");
        nameList.Add("Bjorn");
        nameList.Add("Svend");
        nameList.Add("Revna");
        nameList.Add("Yrsa");
        nameList.Add("Skarde");
        RandomNameGenerator();
        slain.text = name + " slain.";
    }

    // Update is called once per frame
    void Update()
    {
        
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
