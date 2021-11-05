using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GameObject ghost1;
    public Animator ghost1Anim;
    public GameObject ghost2;
    public Animator ghost2Anim;
    public GameObject ghost3;
    public Animator ghost3Anim;
    public GameObject ghost4;
    public Animator ghost4Anim;
    private PacStudentController pacController;
    public Coroutine pacDeadRoutine;
    private Coroutine oneDyingRoutine;
    private Coroutine twoDyingRoutine;
    private Coroutine threeDyingRoutine;
    private Coroutine fourDyingRoutine;
    // Start is called before the first frame update
    void Start()
    {
        pacController = GameObject.FindWithTag("Player").GetComponent<PacStudentController>();
        ghost1Anim = ghost1.GetComponent<Animator>();
        ghost2Anim = ghost2.GetComponent<Animator>();
        ghost3Anim = ghost3.GetComponent<Animator>();
        ghost4Anim = ghost4.GetComponent<Animator>();
        NormalGhosts(true, true, true, true);

        oneDyingRoutine = null;
        twoDyingRoutine = null;
        threeDyingRoutine = null;
        fourDyingRoutine = null;

        ghost1Anim.SetBool("Scared", false);
        ghost1Anim.SetBool("Normal", true);
        ghost1Anim.SetBool("Dead", false);
        ghost1Anim.SetBool("Recovering", false);
        ghost2Anim.SetBool("Scared", false);
        ghost2Anim.SetBool("Normal", true);
        ghost2Anim.SetBool("Dead", false);
        ghost2Anim.SetBool("Recovering", false);
        ghost3Anim.SetBool("Scared", false);
        ghost3Anim.SetBool("Normal", true);
        ghost3Anim.SetBool("Dead", false);
        ghost3Anim.SetBool("Recovering", false);
        ghost4Anim.SetBool("Scared", false);
        ghost4Anim.SetBool("Normal", true);
        ghost4Anim.SetBool("Dead", false);
        ghost4Anim.SetBool("Recovering", false);

        pacDeadRoutine = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(ghost1Anim.GetBool("Dead")){
            ghost1Anim.speed = 0.5f;
        }
        if(ghost2Anim.GetBool("Dead")){
            ghost2Anim.speed = 0.5f;
        }
        if(ghost3Anim.GetBool("Dead")){
            ghost3Anim.speed = 0.5f;
        }
        if(ghost4Anim.GetBool("Dead")){
            ghost4Anim.speed = 0.5f;
        }
        if(!ghost1Anim.GetBool("Dead")){
            ghost1Anim.speed = 1.0f;
        }
        if(!ghost2Anim.GetBool("Dead")){
            ghost2Anim.speed = 1.0f;
        }
        if(!ghost3Anim.GetBool("Dead")){
            ghost3Anim.speed = 1.0f;
        }
        if(!ghost4Anim.GetBool("Dead")){
            ghost4Anim.speed = 1.0f;
        }
    }

    public void ScaredGhosts(bool first, bool second, bool third, bool fourth){
        if(first && !ghost1Anim.GetBool("Dead") && oneDyingRoutine == null){
            ghost1Anim.SetBool("Scared", true);
            ghost1Anim.SetBool("Normal", false);
            ghost1Anim.SetBool("Dead", false);
            ghost1Anim.SetBool("Recovering", false);
        }
        if(second && !ghost2Anim.GetBool("Dead") && twoDyingRoutine == null){
            ghost2Anim.SetBool("Scared", true);
            ghost2Anim.SetBool("Normal", false);
            ghost2Anim.SetBool("Dead", false);
            ghost2Anim.SetBool("Recovering", false);
        }
        if(third && !ghost3Anim.GetBool("Dead") && threeDyingRoutine == null){
            ghost3Anim.SetBool("Scared", true);
            ghost3Anim.SetBool("Normal", false);
            ghost3Anim.SetBool("Dead", false);
            ghost3Anim.SetBool("Recovering", false);
        }
        if(fourth && !ghost4Anim.GetBool("Dead") && fourDyingRoutine == null){
            ghost4Anim.SetBool("Scared", true);
            ghost4Anim.SetBool("Normal", false);
            ghost4Anim.SetBool("Dead", false);
            ghost4Anim.SetBool("Recovering", false);
        }
    }
    public void DeadGhosts(bool first, bool second, bool third, bool fourth){
        ghost1Anim.SetBool("Dead", first);
        ghost2Anim.SetBool("Dead", second);
        ghost3Anim.SetBool("Dead", third);
        ghost4Anim.SetBool("Dead", fourth);
    }
    public void RecoveringGhosts(bool first, bool second, bool third, bool fourth){
        if(first && !ghost1Anim.GetBool("Normal") && !ghost1Anim.GetBool("Dead")){
            ghost1Anim.SetBool("Scared", false);
            ghost1Anim.SetBool("Normal", false);
            ghost1Anim.SetBool("Dead", false);
            ghost1Anim.SetBool("Recovering", true);
        }
        if(second && !ghost2Anim.GetBool("Normal") && !ghost2Anim.GetBool("Dead")){
            ghost2Anim.SetBool("Scared", false);
            ghost2Anim.SetBool("Normal", false);
            ghost2Anim.SetBool("Dead", false);
            ghost2Anim.SetBool("Recovering", true);
        }
        if(third && !ghost3Anim.GetBool("Normal") && !ghost3Anim.GetBool("Dead")){
            ghost3Anim.SetBool("Scared", false);
            ghost3Anim.SetBool("Normal", false);
            ghost3Anim.SetBool("Dead", false);
            ghost3Anim.SetBool("Recovering", true);
        }
        if(fourth && !ghost4Anim.GetBool("Normal") && !ghost4Anim.GetBool("Dead")){
            ghost4Anim.SetBool("Scared", false);
            ghost4Anim.SetBool("Normal", false);
            ghost4Anim.SetBool("Dead", false);
            ghost4Anim.SetBool("Recovering", true);
        }
    }
    public void NormalGhosts(bool first, bool second, bool third, bool fourth){
        if(first && (ghost1Anim.GetBool("Recovering") || !ghost1Anim.GetBool("Dead"))){
            ghost1Anim.SetBool("Scared", false);
            ghost1Anim.SetBool("Normal", true);
            ghost1Anim.SetBool("Dead", false);
            ghost1Anim.SetBool("Recovering", false);
        }
        if(second && (ghost2Anim.GetBool("Recovering") || !ghost2Anim.GetBool("Dead"))){
            ghost2Anim.SetBool("Scared", false);
            ghost2Anim.SetBool("Normal", true);
            ghost2Anim.SetBool("Dead", false);
            ghost2Anim.SetBool("Recovering", false);
        }
        if(third && (ghost3Anim.GetBool("Recovering") || !ghost3Anim.GetBool("Dead"))){
            ghost3Anim.SetBool("Scared", false);
            ghost3Anim.SetBool("Normal", true);
            ghost3Anim.SetBool("Dead", false);
            ghost3Anim.SetBool("Recovering", false);
        }
        if(fourth && (ghost4Anim.GetBool("Recovering") || !ghost4Anim.GetBool("Dead"))){
            ghost4Anim.SetBool("Scared", false);
            ghost4Anim.SetBool("Normal", true);
            ghost4Anim.SetBool("Dead", false);
            ghost4Anim.SetBool("Recovering", false);
        }
    }
    public void CollisionDetected(int ghostNum){
        if(ghostNum == 1){
            ProcessCollision(ghost1, ghost1Anim);
        }
        if(ghostNum == 2){
            ProcessCollision(ghost2, ghost2Anim);
        }
        if(ghostNum == 3){
            ProcessCollision(ghost3, ghost3Anim);
        }
        if(ghostNum == 4){
            ProcessCollision(ghost4, ghost4Anim);
        }
    }

    private void ProcessCollision(GameObject ghost, Animator anim){
        if(anim.GetBool("Normal")){
            if(pacDeadRoutine == null){
                pacDeadRoutine = StartCoroutine(pacController.PacDead());
            }
        }
        if(anim.GetBool("Recovering")){
            Debug.Log("Recovering");
            if(ghost.tag == "GhostOne" && oneDyingRoutine == null){
                Debug.Log("In here");
                oneDyingRoutine = StartCoroutine(OneDying());
            }
            else if(ghost.tag == "GhostTwo" && twoDyingRoutine == null){
                twoDyingRoutine = StartCoroutine(TwoDying());
            }
            else if(ghost.tag == "GhostThree" && threeDyingRoutine == null){
                threeDyingRoutine = StartCoroutine(ThreeDying());
            }
            else if(ghost.tag == "GhostFour" && fourDyingRoutine == null){
                fourDyingRoutine = StartCoroutine(FourDying());
            }
        }
        if(anim.GetBool("Scared")){
            Debug.Log("Scared");
            if(ghost.tag == "GhostOne" && oneDyingRoutine == null){
                Debug.Log("In here");
                oneDyingRoutine = StartCoroutine(OneDying());
            }
            else if(ghost.tag == "GhostTwo" && twoDyingRoutine == null){
                twoDyingRoutine = StartCoroutine(TwoDying());
            }
            else if(ghost.tag == "GhostThree" && threeDyingRoutine == null){
                threeDyingRoutine = StartCoroutine(ThreeDying());
            }
            else if(ghost.tag == "GhostFour" && fourDyingRoutine == null){
                fourDyingRoutine = StartCoroutine(FourDying());
            }
        }
        if(anim.GetBool("Dead")){
            Debug.Log("Dead");
        }
    }

    public IEnumerator initateScaredState(){
        float elapsedTime = 11.0f;
        pacController.originalPpCount = pacController.ppCount;
        ScaredGhosts(true, true, true, true);
        while(elapsedTime > 1.0f){
            if(pacController.ppCount > pacController.originalPpCount){
                pacController.originalPpCount++;
                elapsedTime += 10;
            }
            elapsedTime -= Time.deltaTime;
            pacController.scaredTimer.text = ""+(int)elapsedTime;
            if(elapsedTime < 4.0f){
                RecoveringGhosts(true, true, true, true);
            }
            else{
                //Debug.Log("Scared: " + scaredGhosts);
                ScaredGhosts(true, true, true, true);
            }
            yield return null;
        }
        pacController.ppCount = 0;
        pacController.originalPpCount = 0;
        pacController.scaredTimer.text = "0";
        NormalGhosts(true, true, true, true);
        pacController.scaredRoutine = null;
        yield return null;
    }
    IEnumerator OneDying(){
        var timer = 0.0f;
        ghost1Anim.SetBool("Scared", false);
        ghost1Anim.SetBool("Dead", true);
        pacController.UpdateScore(300);
        while(timer < 5){
            timer += Time.deltaTime;
            yield return null;
        }
        ghost1Anim.SetBool("Dead", false);
        ghost1Anim.SetBool("Normal", true);
        var temp = pacController.ppCount;
        while(timer < 10 * pacController.ppCount){
            if(pacController.ppCount > temp){
                ghost1Anim.SetBool("Scared", true);
                ghost1Anim.SetBool("Normal", false);
                ghost1Anim.SetBool("Dead", false);
                oneDyingRoutine = null;
                StopCoroutine(OneDying());
            }
            yield return null;
        }
        ghost1Anim.SetBool("Normal", true);
        oneDyingRoutine = null;
        yield return null;
    }
    IEnumerator TwoDying(){
        var timer = 0.0f;
        ghost2Anim.SetBool("Scared", false);
        ghost2Anim.SetBool("Dead", true);
        pacController.UpdateScore(300);
        while(timer < 5){
            timer += Time.deltaTime;
            yield return null;
        }
        ghost2Anim.SetBool("Dead", false);
        ghost2Anim.SetBool("Normal", true);
        var temp = pacController.ppCount;
        while(timer < 10 * pacController.ppCount){
            if(pacController.ppCount > temp){
                ghost2Anim.SetBool("Scared", true);
                ghost2Anim.SetBool("Normal", false);
            }
            yield return null;
        }
        ghost2Anim.SetBool("Normal", true);
        twoDyingRoutine = null;
        yield return null;
    }
    IEnumerator ThreeDying(){
        var timer = 0.0f;
        ghost3Anim.SetBool("Scared", false);
        ghost3Anim.SetBool("Dead", true);
        pacController.UpdateScore(300);
        while(timer < 5){
            timer += Time.deltaTime;
            yield return null;
        }
        ghost3Anim.SetBool("Dead", false);
        ghost3Anim.SetBool("Normal", true);
        var temp = pacController.ppCount;
        while(timer < 10 * pacController.ppCount){
            if(pacController.ppCount > temp){
                ghost3Anim.SetBool("Scared", true);
                ghost3Anim.SetBool("Normal", false);
            }
            yield return null;
        }
        ghost3Anim.SetBool("Normal", true);
        threeDyingRoutine = null;
        yield return null;
    }
    IEnumerator FourDying(){
        var timer = 0.0f;
        ghost4Anim.SetBool("Scared", false);
        ghost4Anim.SetBool("Dead", true);
        pacController.UpdateScore(300);
        while(timer < 5){
            timer += Time.deltaTime;
            yield return null;
        }
        ghost4Anim.SetBool("Dead", false);
        ghost4Anim.SetBool("Normal", true);
        var temp = pacController.ppCount;
        while(timer < 10 * pacController.ppCount){
            if(pacController.ppCount > temp){
                ghost4Anim.SetBool("Scared", true);
                ghost4Anim.SetBool("Normal", false);
            }
            yield return null;
        }
        ghost4Anim.SetBool("Normal", true);
        fourDyingRoutine = null;
        yield return null;
    }
}
