using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource background;

    public AudioClip introClip;
    public AudioClip gameplayClip;

    // Start is called before the first frame update
    void Start()
    {
        background.PlayOneShot(introClip, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!background.isPlaying){
            background.clip = gameplayClip;
            background.Play();
        }
    }
}
