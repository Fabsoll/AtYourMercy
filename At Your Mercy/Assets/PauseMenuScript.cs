using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    bool paused = false;
    public GameObject PauseMenu;
    public GameObject Overlay;
    public GameObject healthbar;
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Overlay.SetActive(false);
        healthbar.SetActive(true);
        paused = false;
        AudioListener.volume = 1.0f;
    }

    public void QuitGame()
    {
        SceneManager.LoadSceneAsync("title screen");
        SceneManager.UnloadSceneAsync("Main");
        
    }
    }
