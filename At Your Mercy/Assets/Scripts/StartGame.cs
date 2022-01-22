using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource titlemusic;
    bool startbutton;
    // Start is called before the first frame update
   public void StartGameButton()
    {
        startbutton = true;
        
        SceneManager.LoadSceneAsync("Main");
    }

    private void Update()
    {
        if (startbutton == true)
        {
            if (titlemusic.volume >= 0.0f)
            {
                titlemusic.volume -= 0.2f * Time.deltaTime;

            }
        }
    }

    public void QuitGameFR()
    {
        Application.Quit();
    }
}