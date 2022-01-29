using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroyOnLoad : MonoBehaviour
{
    public static dontDestroyOnLoad instance;
    public static GameObject importantStuff;
    // Start is called before the first frame update
    private void Awake()
    {
        importantStuff = this.gameObject;
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(importantStuff);
        }
    }
    //private void Update()
    //{
    //    if (SceneManager.GetActiveScene().name == "title screen")
    //    {
    //        Destroy(gameObject);
    //    }
    //}

}
