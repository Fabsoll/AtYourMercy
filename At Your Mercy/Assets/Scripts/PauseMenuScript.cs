using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    bool paused;
    public GameObject PauseMenu;
    public GameObject Overlay;
    public GameObject healthbar;
    private void Awake()
    {

        gameObject.SetActive(false);
        Overlay.SetActive(false);
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

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
