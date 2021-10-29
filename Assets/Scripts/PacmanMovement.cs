using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    private Vector3 firstPos;
    private Vector3 secondPos;
    private Vector3 thirdPos;
    private Vector3 fourthPos;
    private Coroutine firstRoutine;
    private Coroutine secondRoutine;
    private Coroutine thirdRoutine;
    private Coroutine fourthRoutine;
    private float counter;
    private Animator animator;
    public AudioSource playerAudio;
    public AudioClip noPellets;

    // Start is called before the first frame update
    void Start()
    {
        counter = 0.0f;
        firstPos = new Vector3(10.0f, -10.0f, 0.0f);
        secondPos = new Vector3(60.0f, -10.0f, 0.0f);
        thirdPos = new Vector3(60.0f, -50.0f, 0.0f);
        fourthPos = new Vector3(10.0f, -50.0f, 0.0f);
        animator = GetComponent<Animator>();
        animator.SetBool("Active", true);
        playerAudio.clip = noPellets;
        playerAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if(this.transform.position == firstPos && firstRoutine == null){
            firstRoutine = StartCoroutine(firstMove(counter));
            animator.SetBool("Up", false);
            animator.SetBool("Right", true);
        }
        if(this.transform.position == secondPos && secondRoutine == null){
            secondRoutine = StartCoroutine(secondMove(counter));
            animator.SetBool("Right", false);
            animator.SetBool("Down", true);
        }
        if(this.transform.position == thirdPos && thirdRoutine == null){
            thirdRoutine = StartCoroutine(thirdMove(counter));
            animator.SetBool("Down", false);
            animator.SetBool("Left", true);
        }
        if(this.transform.position == fourthPos && fourthRoutine == null){
            fourthRoutine = StartCoroutine(fourthMove(counter));
            animator.SetBool("Left", false);
            animator.SetBool("Up", true);
        }
    }

    IEnumerator firstMove(float startTime){
        float elapsedTime = counter - startTime;
        while(elapsedTime < 2.0f){
            this.transform.position = Vector3.Lerp(firstPos, secondPos, (elapsedTime/2.0f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = secondPos;
        yield return null;
        firstRoutine = null;
    }
    IEnumerator secondMove(float startTime){
        float elapsedTime = counter - startTime;
        while(elapsedTime < 2.0f){
            this.transform.position = Vector3.Lerp(secondPos, thirdPos, (elapsedTime/2.0f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = thirdPos;
        yield return null;
        secondRoutine = null;
    }
    IEnumerator thirdMove(float startTime){
        float elapsedTime = counter - startTime;
        while(elapsedTime < 2.0f){
            this.transform.position = Vector3.Lerp(thirdPos, fourthPos, (elapsedTime/2.0f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = fourthPos;
        yield return null;
        thirdRoutine = null;
    }
    IEnumerator fourthMove(float startTime){
        float elapsedTime = counter - startTime;
        while(elapsedTime < 2.0f){
            this.transform.position = Vector3.Lerp(fourthPos, firstPos, (elapsedTime/2.0f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = firstPos;
        yield return null;
        fourthRoutine = null;
    }
}
