using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
private Animator animator;

    private Vector3 pos;
    private float movementSqrMagnitude;
    private Coroutine rightRoutine;
    private Coroutine leftRoutine;
    private Coroutine upRoutine;
    private Coroutine downRoutine;
    private float timer;
    private int input;
    private int currentInput;
    private int lastInput;
    private int[,] levelMap =
        {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
        };
    private int playerPosx;
    private int playerPosy;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        pos = this.transform.position;
        animator = GetComponent<Animator>();
        input = 0;
        currentInput = 0;
        lastInput = 0;
        playerPosx = 1;
        playerPosy = 1;

        rightRoutine = null;
        leftRoutine = null;
        upRoutine = null;
        downRoutine = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(lastInput);
        timer+= Time.deltaTime;
        CheckInput();

        //Debug.Log("X: " + playerPosx + " Y: " + playerPosy);
        Debug.Log(currentInput);

        //User control functionality
        // if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow)){
        //     animator.SetBool("Active", false);
        //     animator.SetBool("Up", false);
        //     animator.SetBool("Down", false);
        //     animator.SetBool("Left", false);
        //     animator.SetBool("Right", false);
        // }
        // if(lastInput == 1){
        //     if(upRoutine == null){
        //         upRoutine = StartCoroutine(moveUp());
        //     }
        // }
        // if(lastInput == 2){
        //     if(downRoutine == null){
        //         downRoutine = StartCoroutine(moveDown());
        //     }
        // }
        // if(lastInput == 3){
        //     if(leftRoutine == null){
        //         leftRoutine = StartCoroutine(moveLeft());
        //     }
        // }
        // if(lastInput == 4){
        //     if(rightRoutine == null){
        //         rightRoutine = StartCoroutine(moveRight());
        //     }
        // }
        // if(Input.GetKey(KeyCode.Space)){
        //     animator.SetTrigger("Dead");
        // }
    }

    public void CheckInput(){
        if(currentInput == 0){
            animator.SetBool("Active", false);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        if(Input.GetKey(KeyCode.W) || lastInput == 1){
            lastInput = 1;
            if(upRoutine == null && downRoutine == null && leftRoutine == null && rightRoutine == null){
                if(CheckValidInput(lastInput)){
                    upRoutine = StartCoroutine(moveUp());
                }
                else if(currentInput == 2){
                    downRoutine = StartCoroutine(moveDown());
                }
                else if(currentInput == 3){
                    leftRoutine = StartCoroutine(moveLeft());
                }
                else if(currentInput == 4){
                    rightRoutine = StartCoroutine(moveRight());
                }
                else{
                    currentInput = 0;
                }
            }
        }
        if(Input.GetKey(KeyCode.S) || lastInput == 2){
            lastInput = 2;
            if(upRoutine == null && downRoutine == null && leftRoutine == null && rightRoutine == null){
                if(CheckValidInput(lastInput)){
                    downRoutine = StartCoroutine(moveDown());
                }
                else if(currentInput == 1){
                    upRoutine = StartCoroutine(moveUp());
                }
                else if(currentInput == 3){
                    leftRoutine = StartCoroutine(moveLeft());
                }
                else if(currentInput == 4){
                    rightRoutine = StartCoroutine(moveRight());
                }
                else{
                    currentInput = 0;
                }
            }
        }
        if(Input.GetKey(KeyCode.A) || lastInput == 3){
            lastInput = 3;
            if(upRoutine == null && downRoutine == null && leftRoutine == null && rightRoutine == null){
                if(CheckValidInput(lastInput)){
                    leftRoutine = StartCoroutine(moveLeft());
                }
                else if(currentInput == 1){
                    upRoutine = StartCoroutine(moveUp());
                }
                else if(currentInput == 2){
                    downRoutine = StartCoroutine(moveDown());
                }
                else if(currentInput == 4){
                    rightRoutine = StartCoroutine(moveRight());
                }
                else{
                    currentInput = 0;
                }
            }
        }
        if(Input.GetKey(KeyCode.D) || lastInput == 4){
            lastInput = 4;
            if(upRoutine == null && downRoutine == null && leftRoutine == null && rightRoutine == null){
                if(CheckValidInput(lastInput)){
                    rightRoutine = StartCoroutine(moveRight());
                }
                else if(currentInput == 1){
                    upRoutine = StartCoroutine(moveUp());
                }
                else if(currentInput == 2){
                    downRoutine = StartCoroutine(moveDown());
                }
                else if(currentInput == 3){
                    leftRoutine = StartCoroutine(moveLeft());
                }
                else{
                    currentInput = 0;
                }
            }
        }
    }

    public bool CheckValidInput(int input){
        int tempX = playerPosx;
        int tempY = playerPosy;
        if(lastInput == 1){
            tempY -= 1;
        }
        else if(lastInput == 2){
            tempY += 1;
        }
        else if(lastInput == 3){
            tempX -= 1;
        }
        else if(lastInput == 4){
            tempX += 1;
        }
        // Debug.Log(levelMap[tempX, tempY]);
        // Debug.Log(tempX);
        // Debug.Log(tempY);
        if(levelMap[tempY, tempX] == 0 || levelMap[tempY, tempX] == 5 || levelMap[tempY, tempX] == 6){
            return true;
        }
        return false;
    }
    IEnumerator moveUp(){
        pos = this.transform.position;
        float elapsedTime = 0.0f;
        Vector3 temp = pos;
        temp.y = temp.y + 10.0f;
        playerPosy -= 1;
        while(this.transform.position != temp){
            currentInput = 1;
            animator.SetBool("Active", true);
            animator.SetBool("Up", true);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            this.transform.position = Vector3.Lerp(pos, temp, (elapsedTime / 0.25f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        upRoutine = null;
        yield return null;
    }
    IEnumerator moveDown(){
        pos = this.transform.position;
        float elapsedTime = 0.0f;
        Vector3 temp = pos;
        temp.y = temp.y - 10.0f;
        playerPosy += 1;
        while(this.transform.position != temp){
            currentInput = 2;
            animator.SetBool("Active", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
            this.transform.position = Vector3.Lerp(pos, temp, (elapsedTime / 0.25f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        downRoutine = null;
        yield return null;
    }
    IEnumerator moveLeft(){
        pos = this.transform.position;
        float elapsedTime = 0.0f;
        Vector3 temp = pos;
        temp.x = temp.x - 10.0f;
        playerPosx -= 1;
        while(this.transform.position != temp){
            currentInput = 3;
            animator.SetBool("Active", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            this.transform.position = Vector3.Lerp(pos, temp, (elapsedTime / 0.25f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        leftRoutine = null;
        yield return null;
    }
    IEnumerator moveRight(){
        pos = this.transform.position;
        float elapsedTime = 0.0f;
        Vector3 temp = pos;
        temp.x = temp.x + 10.0f;
        playerPosx += 1;
        while(this.transform.position != temp){
            currentInput = 4;
            animator.SetBool("Active", true);
            animator.SetBool("Up", false);
            animator.SetBool("Down", false);
            animator.SetBool("Left", false);
            animator.SetBool("Right", true);
            this.transform.position = Vector3.Lerp(pos, temp, (elapsedTime / 0.25f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        rightRoutine = null;
        yield return null;
    }
}