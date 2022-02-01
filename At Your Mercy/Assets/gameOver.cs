using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour




{

    public GameObject screenOne;
    public GameObject screenTwo;
    public GameObject screenThree;
    Color objectColor;
    Color objectColor2;
    Color objectColor3;
    float fadeAmount;
    public float fadeSpeed;
    bool screenOneStart;
    bool screenTwoStart;
    bool screenThreeStart;
    bool loadTitleScreen;
    public AudioSource gameoverMusic;
    // Start is called before the first frame update
    void Start()
    {
        screenOneStart = true;
        objectColor2 = screenTwo.GetComponent<Image>().color;
        objectColor3 = screenThree.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (screenOneStart)
        {
            PlayScreenOne();
        }
        if (screenTwoStart)
        {
            PlayScreenTwo();
        }
        if (screenThreeStart)
        {
            PlayScreenThree();
        }
        if (loadTitleScreen)
        {
            StartCoroutine(waitTitleScreen());

        }

    }

    IEnumerator waitTitleScreen()
    {

        yield return new WaitForSecondsRealtime(3);

        SceneManager.LoadScene("title screen");
        gameoverMusic.Stop();
        SceneManager.UnloadSceneAsync("game over");
    }
    void PlayScreenOne()
    {
        if (screenOne.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            screenOne.GetComponent<Image>().color = objectColor;
        }
        else
        {
            screenOneStart = false;
            screenTwoStart = true;
        }
    }
   
    void PlayScreenTwo()
    {
        if (screenTwo.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor2.a + (fadeSpeed * Time.deltaTime);
            objectColor2 = new Color(objectColor2.r, objectColor2.g, objectColor2.b, fadeAmount);
            screenTwo.GetComponent<Image>().color = objectColor2;
        }
        else
        {
            screenTwoStart = false;
            screenThreeStart = true;
        }
    }
    void PlayScreenThree()
    {
        if (screenThree.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor3.a + (fadeSpeed * Time.deltaTime);
            objectColor3 = new Color(objectColor3.r, objectColor3.g, objectColor3.b, fadeAmount);
            screenThree.GetComponent<Image>().color = objectColor3;
        }
        else
        {
            screenThreeStart = false;
            loadTitleScreen = true;
        }
    }
}
