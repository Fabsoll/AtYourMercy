using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TransitionScript : MonoBehaviour
{
    public GameObject wotandialogue;
    public GameObject brunnhildedialogue;
    public GameObject fadetoscene;
    public GameObject wotansign;
    public GameObject wotanidle;
    public GameObject brunnhildeidle;
    public GameObject valhallafadeout;
    float fadeAmount;
    Color objectColor;
    Color objectColor2;
    Color objectColor3;
    public float fadeSpeed;
    public float fadeSpeed2;
    bool done;
    bool wotan;
    bool valhallafade;
    bool starttalking;
    public Text brunnhildetext;
    public Text wotantext;
    bool wotangone;
    // Start is called before the first frame update
    void Start()
    {
        wotandialogue.SetActive(false);
        brunnhildedialogue.SetActive(false);
        brunnhildeidle.SetActive(false);
        wotanidle.SetActive(false);
        Time.timeScale = 1;
        objectColor = fadetoscene.GetComponent<Image>().color;
        objectColor2 = wotansign.GetComponent<Image>().color;
        objectColor3 = valhallafadeout.GetComponent<Image>().color;
        wotantext.text = "Did you think you could hide from me forever?";


    }

    // Update is called once per frame
    void Update()
    {

        if (wotansign.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor2.a + (fadeSpeed * Time.deltaTime);
            objectColor2 = new Color(objectColor2.r, objectColor2.g, objectColor2.b, fadeAmount);
            wotansign.GetComponent<Image>().color = objectColor2;
        }
        else { wotan = true; }

        if (wotan)
        {

            wotanvoid();
            
        }
        


        if (done)
        {
            donevoid();
        
        }

        if (wotangone)
        {
            wotandialogue.SetActive(false);
        }
        if (Input.GetButtonDown("text"))
        {
            wotantalk1();
        }
    }


    void wotanvoid()
    {
        if (fadetoscene.GetComponent<Image>().color.a >= 0)
        {
            fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);
            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            fadetoscene.GetComponent<Image>().color = objectColor;

        }
        else
        {

            wotan = false;
            done = true;
        }
    }

    void donevoid()
    {
        wotandialogue.SetActive(true);
        done = false;
    }
    
    int textcounter = 0;
    bool text1;
    void wotantalk1()
    {
        

        switch (textcounter)
        {
            
            case 0:
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                wotanidle.SetActive(true);
                brunnhildetext.text = "I wasn't hiding from you. You dragged me here.";
                textcounter += 1;
                break;
            case 1:
                wotangone = false;
                wotandialogue.SetActive(true);
                brunnhildedialogue.SetActive(false);
                brunnhildeidle.SetActive(true);
                wotantext.text = "Do you even know what you're doing?";
                textcounter += 1;
                break;

            case 2:
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                brunnhildetext.text = "I'm trying to end a tyrant.";
                textcounter += 1;
                break;

            case 3:
                wotangone = false;
                wotandialogue.SetActive(true);
                brunnhildedialogue.SetActive(false);
                wotantext.text = "Tyrant? And what do you call yourself? The hero?";
                textcounter += 1;
                break;

            case 4:
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                brunnhildetext.text = "perhaps.";
                textcounter += 1;
                break;
            case 5:
                wotangone = false;
                wotandialogue.SetActive(true);
                brunnhildedialogue.SetActive(false);
                wotantext.text = "Tch. You might have been one. Long ago.";
                textcounter += 1;
                break;
            case 6:
                wotantext.text = "Now you're barely more than a worm.";
                textcounter += 1;
                break;
            case 7:
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                brunnhildetext.text = "Let's just get this over with already.";
                textcounter += 1;
                break;
            case 8:
                wotangone = false;
                wotandialogue.SetActive(true);
                brunnhildedialogue.SetActive(false);
                wotantext.text = "Be crushed beneath my boot then, worm.";
                textcounter += 1;
                break;
            case 9:
                SceneManager.LoadScene("bossfight");
                
                SceneManager.UnloadSceneAsync("transition scene");
                break;
        }


    }
}
