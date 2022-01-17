using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBehaviorBgm : MonoBehaviour
{

    public Rigidbody2D rb;
    public PolygonCollider2D pg;
    bool fadeinout = false;
    AudioSource bloodeagle_bgm;
    public float fadeintime;
    public float maxvolume;

    // Start is called before the first frame update
    void Start()
    {

        bloodeagle_bgm = GetComponent<AudioSource>();
        bloodeagle_bgm.volume = 0.0f;
        bloodeagle_bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {

        if (fadeinout == true)
        {
            if (bloodeagle_bgm.volume < maxvolume)
            {
                bloodeagle_bgm.volume += fadeintime * Time.deltaTime;
            }
        }
        if (fadeinout == false)
        {
            if (bloodeagle_bgm.volume > 0.0f)
            {
                bloodeagle_bgm.volume -= 1.5f * fadeintime * Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {


            fadeinout = true;


        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            fadeinout = false;
        }
    }

}
