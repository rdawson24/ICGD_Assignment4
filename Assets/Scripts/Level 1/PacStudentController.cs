using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PacStudentController : MonoBehaviour
{
    public Animator animator {get; private set;}

    private Vector3 pos;
    private float movementSqrMagnitude;
    private Coroutine rightRoutine;
    private Coroutine leftRoutine;
    private Coroutine upRoutine;
    private Coroutine downRoutine;
    private float timer;
    private int currentInput;
    private int lastInput;
    private bool enteredWall;
    public int[,] levelMap {get; private set;} =
        {
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,4,4,4,4,3,0,4,4,5,2,0,0,0,0,0},
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
            {0,0,0,0,0,0,5,0,0,0,4,0,0,0,0,0,0,4,0,0,0,5,0,0,0,0,0,0},
            {2,2,2,2,2,1,5,3,3,0,4,0,0,0,0,0,0,4,0,3,3,5,1,2,2,2,2,2},
            {0,0,0,0,0,2,5,4,4,0,3,4,4,4,4,4,4,3,0,4,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,4,0,0,0,0,0,0,0,0,0,0,4,4,5,2,0,0,0,0,0},
            {0,0,0,0,0,2,5,4,3,4,4,3,0,3,3,0,3,4,4,3,4,5,2,0,0,0,0,0},
            {1,2,2,2,2,1,5,4,3,4,4,3,0,4,4,0,3,4,4,3,4,5,1,2,2,2,2,1},
            {2,5,5,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,4,4,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,4,4,5,3,4,4,3,3,4,4,3,5,4,4,5,3,4,4,3,5,2},
            {2,5,3,4,4,3,5,3,3,5,3,4,4,4,4,4,4,3,5,3,3,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,3,3,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,6,4,0,0,4,5,4,0,0,0,4,5,4,4,5,4,0,0,0,4,5,4,0,0,4,6,2},
            {2,5,3,4,4,3,5,3,4,4,4,3,5,4,4,5,3,4,4,4,3,5,3,4,4,3,5,2},
            {2,5,5,5,5,5,5,5,5,5,5,5,5,4,4,5,5,5,5,5,5,5,5,5,5,5,5,2},
            {1,2,2,2,2,2,2,2,2,2,2,2,2,7,7,2,2,2,2,2,2,2,2,2,2,2,2,1},
        };
    public int playerPosx {get; private set;}
    public int playerPosy {get; private set;}
    private ParticleSystem trail;
    private ParticleSystem deathPs;
    private ParticleSystem wallPs;
    private BoxCollider pacCollider;
    private bool moving;
    private AudioController gameAudio;
    private Coroutine waitForInputRoutine;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scaredTimer;
    public bool scaredGhosts {get; private set;}
    public bool recoveringGhosts {get; private set;}
    public bool normalGhosts {get; private set;}
    public bool deadGhosts {get; private set;}
    public int ppCount;
    public int originalPpCount;
    public Coroutine scaredRoutine;
    public GhostController ghostController;
    private GameObject lifeThree;
    private GameObject lifeTwo;
    private GameObject lifeOne;
    private int lives;
    private bool pacDead;
    // Start is called before the first frame update
    void Start()
    {
        pacDead = false;
        lives = 3;
        scaredRoutine = null;
        originalPpCount = 0;
        ppCount = 0;
        score = 0;
        gameAudio = GameObject.FindWithTag("Audio").GetComponent<AudioController>();
        pacCollider = this.GetComponent<BoxCollider>();
        enteredWall = false;
        timer = 0.0f;
        pos = this.transform.position;
        animator = GetComponent<Animator>();
        currentInput = 0;
        lastInput = 0;
        playerPosx = 1;
        playerPosy = 1;
        //levelMap[1,1] = 0;
        trail = GameObject.FindWithTag("Trail").GetComponent<ParticleSystem>();
        trail.Stop();
        wallPs = GameObject.FindWithTag("CollisionParticle").GetComponent<ParticleSystem>();
        wallPs.Stop();
        deathPs = GameObject.FindWithTag("DeathParticles").GetComponent<ParticleSystem>();
        deathPs.Stop();
        waitForInputRoutine = StartCoroutine(waitForFirstInput());
        lifeThree = GameObject.FindWithTag("LifeThree");
        lifeTwo = GameObject.FindWithTag("LifeTwo");
        lifeOne = GameObject.FindWithTag("LifeOne");


        normalGhosts = true;
        recoveringGhosts = false;
        deadGhosts = false;
        scaredGhosts = false;

        rightRoutine = null;
        leftRoutine = null;
        upRoutine = null;
        downRoutine = null;
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(levelMap[playerPosy, playerPosx]);
        // Debug.Log("Last: "+lastInput);
        // Debug.Log("Current: "+currentInput);
        timer+= Time.deltaTime;
        if(Time.timeScale == 1){
            CheckInput();
            if(!moving){
                pacCollider.center = new Vector3(0.0f, 2.0f, 0.0f);
                pacCollider.size = new Vector3(10.0f, 15.0f, 50.0f);
            }
            else{
                pacCollider.center = new Vector3(0.0f, 0.0f, 0.0f);
                pacCollider.size = new Vector3(10.0f, 8.0f, 50.0f);
            }
        }
        
        //Debug.Log("X: " + playerPosx + " Y: " + playerPosy);
    }
    public void CheckInput(){
        if(Input.GetKey(KeyCode.W)){
            lastInput = 1; 
        }
        if(Input.GetKey(KeyCode.S)){
            lastInput = 2;
        }
        if(Input.GetKey(KeyCode.A)){
            lastInput = 3;
        }
        if(Input.GetKey(KeyCode.D)){
            lastInput = 4;
        }
        if(upRoutine == null && downRoutine == null && leftRoutine == null && rightRoutine == null && waitForInputRoutine == null){
            if(CheckValidLastInput(lastInput)){
                moving = true;
                animator.SetBool("Active", moving);
                currentInput = lastInput;
                MovePac();
            }
            else if(CheckValidCurrentInput(currentInput)){
                moving = true;
                animator.SetBool("Active", moving);
                MovePac();
            }
            else{
                currentInput = 0;
                moving = false;
                animator.SetBool("Active", moving);
                trail.Stop();
            }
        }
    }

    public void MovePac(){
        if(currentInput == 1){
            trail.Play();
            upRoutine = StartCoroutine(moveUp());
        }
        else if(currentInput == 2){
            trail.Play();
            downRoutine = StartCoroutine(moveDown());
        }
        else if(currentInput == 3){
            trail.Play();
            leftRoutine = StartCoroutine(moveLeft());
        }
        else if(currentInput == 4){
            trail.Play();
            rightRoutine = StartCoroutine(moveRight());
        }
    }
    public bool CheckValidLastInput(int input){
        int tempX = playerPosx;
        int tempY = playerPosy;
        if(tempY == 0 && input != 2){
            return false;
        }
        else if(tempY == 28 && input != 1){
            return false;
        }
        else if(tempX == 0 && input != 4){
            return false;
        }
        else if(tempX == 27 && input != 3){
            return false;
        }
        else if(lastInput == 1){
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
        if(levelMap[tempY, tempX] == 0 || levelMap[tempY, tempX] == 5 || levelMap[tempY, tempX] == 6){
            return true;
        }
        return false;
    }
    public bool CheckValidCurrentInput(int input){
        int tempX = playerPosx;
        int tempY = playerPosy;
        if(tempY == 0 && input != 2){
            return false;
        }
        else if(tempY == 28 && input != 1){
            return false;
        }
        else if(tempX == 0 && input != 4){
            return false;
        }
        else if(tempX == 27 && input != 3){
            return false;
        }
        else if(currentInput == 0){
            return false;
        }
        else if(currentInput == 1){
            tempY -= 1;
        }
        else if(currentInput == 2){
            tempY += 1;
        }
        else if(currentInput == 3){
            tempX -= 1;
        }
        else if(currentInput == 4){
            tempX += 1;
        }
        if(levelMap[tempY, tempX] == 0 || levelMap[tempY, tempX] == 5 || levelMap[tempY, tempX] == 6){
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Wall" && !enteredWall){
            enteredWall = true;
            gameAudio.playCollision();
            wallPs.Play();
        }
        if(other.gameObject.tag == "LeftTeleporter" && this.transform.position == new Vector3(0.0f, -140.0f, -1.0f)){
            this.transform.position = new Vector3(270.0f, -140.0f, -1.0f);
            playerPosx = 27;
        }
        if(other.gameObject.tag == "RightTeleporter" && this.transform.position == new Vector3(270.0f, -140.0f, -1.0f)){
            this.transform.position = new Vector3(0.0f, -140.0f, -1.0f);
            playerPosx = 0;
        }
        if(other.gameObject.tag == "Cherry"){
            other.GetComponent<SpriteRenderer>().enabled = false;
        }
        if(other.gameObject.tag == "GhostOne"){
            ghostController.CollisionDetected(1);
        }
        if(other.gameObject.tag == "GhostTwo"){
            ghostController.CollisionDetected(2);
        }
        if(other.gameObject.tag == "GhostThree"){
            ghostController.CollisionDetected(3);
        }
        if(other.gameObject.tag == "GhostFour"){
            ghostController.CollisionDetected(4);
        }
    }

    // private void OnTriggerStay(Collider other){
    //     if(other.gameObject.tag == "LeftTeleporter" && ){

    //     }
    // }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.tag == "Wall" && enteredWall){
            enteredWall = false;
            wallPs.Stop();
        }
        if(other.gameObject.tag == "PelletRenderer"){
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Pellet"){
            UpdateScore(10);
            Destroy(other);
            
            if(currentInput == 1){
                levelMap[playerPosy+1, playerPosx] = 0;
            }
            else if(currentInput == 2){
                levelMap[playerPosy-1, playerPosx] = 0;
            }
            else if(currentInput == 3){
                levelMap[playerPosy, playerPosx+1] = 0;
            }
            else if(currentInput == 4){
                levelMap[playerPosy, playerPosx-1] = 0;
            }
        }
        if(other.gameObject.tag == "PowerPill"){
            ppCount++;
            Destroy(other.gameObject);
            if(scaredRoutine == null){
                scaredRoutine = ghostController.StartCoroutine(ghostController.initateScaredState());
            }
            if(currentInput == 1){
                levelMap[playerPosy+1, playerPosx] = 0;
            }
            else if(currentInput == 2){
                levelMap[playerPosy-1, playerPosx] = 0;
            }
            else if(currentInput == 3){
                levelMap[playerPosy, playerPosx+1] = 0;
            }
            else if(currentInput == 4){
                levelMap[playerPosy, playerPosx-1] = 0;
            }
        }
    }

    public void UpdateScore(int i){
        score+=i;
        scoreText.text = ""+score;
    }

    public IEnumerator PacDead(){
        lastInput = 0;
        currentInput = 0;
        pacDead = true;
        deathPs.Play();
        animator.SetBool("Active", false);
        animator.SetBool("Up", false);
        animator.SetBool("Down", false);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetTrigger("Dead");
        trail.Stop();
        if(lives == 3){
            Destroy(lifeOne);
            lives--;
        }
        else if(lives == 2){
            Destroy(lifeTwo);
            lives--;
        }
        else if(lives == 1){
            Destroy(lifeThree);
            lives--;
        }
        yield return null;
        var waitTime = timer - 0.875;
        while(this.animator.GetCurrentAnimatorStateInfo(0).IsName("Player (Monkey) Animation DEATH")){
            yield return null;
        }
        deathPs.Stop();
        this.transform.position = new Vector3(10.0f, -10.0f, -1.0f);
        pos = new Vector3(10.0f, -10.0f, -1.0f);
        Time.timeScale = 0;
        pacDead = false;
        playerPosx = 1;
        playerPosy = 1;
        Time.timeScale = 1;
        //waitForInputRoutine= StartCoroutine(waitForFirstInput());
        ghostController.pacDeadRoutine = null;
        yield return null;
    }
    // IEnumerator initateScaredState(){
    //     float elapsedTime = 11.0f;
    //     originalPpCount = ppCount;
    //     ghostController.ScaredGhosts(true, true, true, true);
    //     ghostController.NormalGhosts(false, false, false, false);
    //     while(elapsedTime > 1.0f){
    //         if(ppCount > originalPpCount){
    //             originalPpCount++;
    //             elapsedTime += 10;
    //         }
    //         elapsedTime -= Time.deltaTime;
    //         scaredTimer.text = ""+(int)elapsedTime;
    //         if(elapsedTime < 4.0f){
    //             ghostController.RecoveringGhosts(true, true, true, true);
    //             ghostController.ScaredGhosts(false, false, false, false);
    //         }
    //         else{
    //             //Debug.Log("Scared: " + scaredGhosts);
    //             ghostController.RecoveringGhosts(false, false, false, false);
    //             ghostController.ScaredGhosts(true, true, true, true);
    //         }
    //         yield return null;
    //     }
    //     ppCount = 0;
    //     originalPpCount = 0;
    //     scaredTimer.text = "0";
    //     ghostController.RecoveringGhosts(false, false, false, false);
    //     ghostController.NormalGhosts(true, true, true, true);
    //     scaredRoutine = null;
    //     yield return null;
    // }
    IEnumerator moveUp(){
        pos = this.transform.position;
        float elapsedTime = 0.0f;
        Vector3 temp = pos;
        temp.y = temp.y + 10.0f;
        playerPosy -= 1;
        while(this.transform.position != temp && !pacDead){
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
        while(this.transform.position != temp && !pacDead){
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
        while(this.transform.position != temp && !pacDead){
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
        while(this.transform.position != temp && !pacDead){
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

    IEnumerator waitForFirstInput(){
        while(lastInput == 0 || lastInput == 1 || lastInput == 3){
            animator.SetBool("Active", false);
            yield return null;
        }
        waitForInputRoutine = null;
        yield return null;
    }
}
