using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExplosionAudio : MonoBehaviour
{
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        //Invoke("PlaySound", 1f);
    }

    // Update is called once per frame
    public void PlaySound()
    {
        audio.PlayOneShot(audio.clip, 0.5f);
    }
    
}
