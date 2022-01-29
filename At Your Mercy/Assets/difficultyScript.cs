using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyScript : MonoBehaviour
{

    GameObject valkyrieSound;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
        valkyrieSound = GameObject.Find("dontDestroyThese/Valkyrie/brunnhilde audio");
        valkyrieSound.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Easy()
    {
        //how the game should be easier
        closeScreen();
        
        
    }
    public void Medium()
    {
        //how the game should be normally
        closeScreen();
    }
    public void Hard()
    {
        //how the game should be harder
        closeScreen();
    }

    void closeScreen()
    {
        valkyrieSound.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
