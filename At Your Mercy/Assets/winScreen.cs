using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winScreen : MonoBehaviour
{
    public Image runes;
    public Image words;
    float fadeAmount;
    public float fadeSpeed;
    Color objectColor;
    Color objectColor2;
    bool fadeDone;
    bool runesDone;
    // Start is called before the first frame update
    void Start()
    {
        objectColor = runes.color;
        objectColor2 = words.color;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (runes.GetComponent<Image>().color.a < 1 && runesDone!=true)
        {
            fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            runes.GetComponent<Image>().color = objectColor;
        }
        else
        {
            runesDone = true;
        }
        if (words.GetComponent<Image>().color.a < 1)
        {
            if (runesDone)
            {

                fadeAmount = objectColor2.a + (fadeSpeed * Time.deltaTime);
                objectColor2 = new Color(objectColor2.r, objectColor2.g, objectColor2.b, fadeAmount);
                words.GetComponent<Image>().color = objectColor2;
            }
        }
        else
        {
            fadeDone = true;
        }
        if (fadeDone)
        {
            StartCoroutine("waitForTitleScreen");
        }
    }

    IEnumerator waitForTitleScreen()
    {
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadScene("title screen");
    }
}
