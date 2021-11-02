using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource background;
    public AudioSource pacSound;
    public AudioClip introClip;
    public AudioClip gameplayClip;
    public AudioClip pacEat;
    public AudioClip pacWalk;
    private PacStudentController pacController;

    // Start is called before the first frame update
    void Start()
    {
        background.PlayOneShot(introClip, 1.0f);
        pacController = GameObject.FindWithTag("Player").GetComponent<PacStudentController>();
        pacSound.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!background.isPlaying){
            background.clip = gameplayClip;
            background.Play();
        }
        if(pacController.levelMap[pacController.playerPosy, pacController.playerPosx] == 5 && pacSound.clip != pacEat){
            playEating();
        }
        if(pacController.levelMap[pacController.playerPosy, pacController.playerPosx] == 0 && pacSound.clip != pacWalk){
            playWalking();
        }
    }

    void playEating(){
        pacSound.clip = pacEat;
        pacSound.Play();
    }

    void playWalking(){
        pacSound.clip = pacWalk;
        pacSound.Play();
    }
}
