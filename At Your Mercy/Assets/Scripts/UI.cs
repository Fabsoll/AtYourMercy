using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    bool paused = false;
    public GameObject PauseMenu;
    public GameObject Overlay;
    public GameObject healthbar;

    public int deathCounter;
    public int healthCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //PauseMenu.SetActive(false);
        //Overlay.SetActive(false);
        //paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        
    }



    void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        Overlay.SetActive(true);
        healthbar.SetActive(false);
        paused = true;
        AudioListener.volume = 0.4f;

    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Overlay.SetActive(false);
        healthbar.SetActive(true);
        paused = false;
        AudioListener.volume = 1.0f;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode){
//        Debug.Log("OnSceneLoaded: " + scene.name);
        if(SceneManager.GetActiveScene().name == "bossfight"){
            PauseMenu.SetActive(false);
            Overlay.SetActive(false);
            healthbar.SetActive(true);
        }
    }
}
