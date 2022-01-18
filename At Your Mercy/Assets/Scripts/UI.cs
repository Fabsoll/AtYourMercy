using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    bool paused = false;
    public GameObject PauseMenu;
    public GameObject Overlay;
    public GameObject healthbar;

    public int deaths;
    
    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
        PauseMenu.SetActive(false);
        Overlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(deaths);
        if (Input.GetKeyDown(KeyCode.P))
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
}
