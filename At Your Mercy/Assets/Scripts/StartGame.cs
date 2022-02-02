using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public AudioSource titlemusic;
    bool startbutton;
    Button start;
    GameObject loadingMessage;
    // Start is called before the first frame update

    private void Start()
    {
        loadingMessage = GameObject.Find("Canvas/loading message");
        loadingMessage.SetActive(false);
        start = GameObject.Find("Canvas/startbutton").GetComponent<Button>();
    }
    public void StartGameButton()
    {

        loadingMessage.SetActive(true);
        startbutton = true;
        SceneManager.LoadSceneAsync("Main");
    }

    private void Update()
    {
        if (startbutton == true)
        {
            start.interactable = false;
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

    public void Tutorial()
    {
        SceneManager.LoadScene("tutorial");
        SceneManager.UnloadSceneAsync("title screen");
    }
    private void OnEnable()
    {
        loadingMessage.SetActive(false);
    }
}
