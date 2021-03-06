using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TransitionScript : MonoBehaviour
{

    #region
    public AudioSource didYouThink;
    public AudioSource iWasntHiding;
    public AudioSource doYouEven;
    public AudioSource imTryingTo;
    public AudioSource aTyrantAnd;
    public AudioSource perhaps;
    public AudioSource youMightHave;
    public AudioSource nowYoureBarely;
    public AudioSource letsJustGet;
    public AudioSource beCrushedBeneath;
    #endregion
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
    public AudioSource transitionmusic;
    public AudioSource wotansound;
    GameObject valkyrieSound;
    Image fadetoblack;
    // Start is called before the first frame update
    void Start()
    {
        valkyrieSound = GameObject.Find("brunnhilde audio");
        valkyrieSound.SetActive(false);
        wotandialogue.SetActive(true);
        brunnhildedialogue.SetActive(false);
        brunnhildeidle.SetActive(false);
        wotanidle.SetActive(false);
        Time.timeScale = 1;
        fadetoblack = GameObject.Find("dontDestroyThese/fadetoblack").GetComponent<Image>();
        fadetoblack.color = new Color(fadetoblack.color.r, fadetoblack.color.g, fadetoblack.color.b, 0);
        objectColor = fadetoscene.GetComponent<Image>().color;
        objectColor2 = wotansign.GetComponent<Image>().color;
        objectColor3 = valhallafadeout.GetComponent<Image>().color;
        


    }
   

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 1;
        if (wotansign.GetComponent<Image>().color.a < 1)
        {
            fadeAmount = objectColor2.a + (fadeSpeed * Time.deltaTime);
            objectColor2 = new Color(objectColor2.r, objectColor2.g, objectColor2.b, fadeAmount);
            wotansign.GetComponent<Image>().color = objectColor2;
        }
        else { 
            wotan = true; }

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
        if (wotansign.GetComponent<Image>().color.a > 0)
        {
            fadeAmount = objectColor3.a - (fadeSpeed2 * Time.deltaTime);
            objectColor3 = new Color(objectColor3.r, objectColor3.g, objectColor3.b, fadeAmount);
            wotansign.GetComponent<Image>().color = objectColor3;

        }
        else
        {
            done = false;
        }
    }
    
    int textcounter = -1;
    bool text1;
    void wotantalk1()
    {
        

        switch (textcounter)
        {
            case -1:
                didYouThink.Play();
                transitionmusic.volume = 0.1f;
                wotantext.text = "Did you think you could hide from me forever?";
                textcounter += 1;
                break;
            case 0:
                didYouThink.Stop();
                iWasntHiding.Play();
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                wotanidle.SetActive(true);
                brunnhildetext.text = "i wasn't hiding from you. you dragged me here.";
                textcounter += 1;
                break;
            case 1:
                iWasntHiding.Stop();
                doYouEven.Play();
                wotangone = false;
                wotandialogue.SetActive(true);
                brunnhildedialogue.SetActive(false);
                brunnhildeidle.SetActive(true);
                wotantext.text = "Do you even know what you're doing?";
                textcounter += 1;
                break;

            case 2:
                doYouEven.Stop();
                imTryingTo.Play();
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                brunnhildetext.text = "I'm trying to end a tyrant.";
                textcounter += 1;
                break;

            case 3:
                imTryingTo.Stop();
                aTyrantAnd.Play();
                wotangone = false;
                wotandialogue.SetActive(true);
                brunnhildedialogue.SetActive(false);
                wotantext.text = "Tyrant? And what do you call yourself? The hero?";
                textcounter += 1;
                break;

            case 4:
                aTyrantAnd.Stop();
                perhaps.Play();
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                brunnhildetext.text = "perhaps.";
                textcounter += 1;
                break;
            case 5:
                perhaps.Stop();
                youMightHave.Play();
                wotangone = false;
                wotandialogue.SetActive(true);
                brunnhildedialogue.SetActive(false);
                wotantext.text = "Tch. You might have been one. Long ago.";
                textcounter += 1;
                break;
            case 6:
                youMightHave.Stop();
                nowYoureBarely.Play();
                wotantext.text = "Now you're barely more than a worm.";
                textcounter += 1;
                break;
            case 7:
                nowYoureBarely.Stop();
                letsJustGet.Play();
                wotangone = true;
                brunnhildedialogue.SetActive(true);
                brunnhildetext.text = "Let's just get this over with already.";
                textcounter += 1;
                break;
            case 8:
                letsJustGet.Stop();
                beCrushedBeneath.Play();
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
