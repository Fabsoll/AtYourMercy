using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroyOnLoad : MonoBehaviour
{
    public static dontDestroyOnLoad instance;
    public static GameObject importantStuff;
    string sceneName;
    Scene currentScene;
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
    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "title screen")
        {
            Destroy(this.gameObject);
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
