using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    public AudioSource background;
    public AudioSource pacSound;
    public AudioSource collisionSource;
    public AudioClip introClip;
    public AudioClip gameplayClip;
    public AudioClip pacEat;
    public AudioClip pacWalk;
    public AudioClip pacCollision;
    public AudioClip scaredBackground;
    private PacStudentController pacController;
    public GameObject manager;
    private GhostController ghostController;

    // Start is called before the first frame update
    void Start()
    {
        pacController = GameObject.FindWithTag("Player").GetComponent<PacStudentController>();
        ghostController = manager.GetComponent<GhostController>();
        pacSound.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(((ghostController.ghost4Anim.GetBool("Scared") || ghostController.ghost4Anim.GetBool("Scared") || ghostController.ghost4Anim.GetBool("Scared") || ghostController.ghost4Anim.GetBool("Scared")) || pacController.recoveringGhosts) && background.isPlaying && background.clip != scaredBackground){
            background.Stop();
            playScared();
        }

        if(!ghostController.ghost4Anim.GetBool("Scared") && !ghostController.ghost4Anim.GetBool("Scared") && !ghostController.ghost4Anim.GetBool("Scared") && !ghostController.ghost4Anim.GetBool("Scared") && !ghostController.ghost4Anim.GetBool("Recovering") && !ghostController.ghost4Anim.GetBool("Recovering") && !ghostController.ghost4Anim.GetBool("Recovering") && !ghostController.ghost4Anim.GetBool("Recovering") && background.clip == scaredBackground){
            background.Stop();
            backgroundMusic();
        }

        if(!background.isPlaying){
            backgroundMusic();
        }

        if(!collisionSource.isPlaying){
            if(!pacSound.isPlaying && pacController.animator.GetBool("Active") == true){
                pacSound.Play();
            }
            if(pacController.levelMap[pacController.playerPosy, pacController.playerPosx] == 5 && pacSound.clip != pacEat && pacController.animator.GetBool("Active") == true){
                playEating();
            }
            if(pacController.levelMap[pacController.playerPosy, pacController.playerPosx] == 0 && pacSound.clip != pacWalk && pacController.animator.GetBool("Active") == true){
                playWalking();
            }
        }
    }
    public void backgroundMusic(){
        background.volume = 0.5f;
        background.clip = gameplayClip;
        background.Play();
    }
    public void playScared(){
        background.volume = 1.0f;
        background.clip = scaredBackground;
        background.Play();
    }
    public void playEating(){
        pacSound.clip = pacEat;
        pacSound.Play();
    }

    public void playWalking(){
        pacSound.clip = pacWalk;
        pacSound.Play();
    }

    public void playCollision(){
        collisionSource.clip = pacCollision;
        collisionSource.Play();
        pacSound.Pause();
    }
}
