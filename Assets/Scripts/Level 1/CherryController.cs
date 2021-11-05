using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject cherry;
    private float timer;
    private Coroutine spawnRoutine;
    private int count;
    private Vector3 normalizedResult;
    private int sideRand;
    private Vector3 startRand;
    private Vector3 middle;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        count = 1; 
        spawnRoutine = null;
        middle = new Vector3(135.0f, -140.0f, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if((int)timer == count*10 && spawnRoutine == null){
            count++;
            sideRand = Random.Range(0, 3);
            if(sideRand == 0){
                //Top
                startRand = new Vector3(Random.Range(-150.0f, 410.0f), 20.0f, -1.0f);
                normalizedResult = (middle - startRand).normalized;
            }
            if(sideRand == 1){
                //Bot
                startRand = new Vector3(Random.Range(-150.0f, 410.0f), -350.0f, -1.0f);
                normalizedResult = (middle - startRand).normalized;
            }
            if(sideRand == 2){
                //Left
                startRand = new Vector3(-150.0f, Random.Range(-305.0f, 20.0f), -1.0f);
                normalizedResult = (middle - startRand).normalized;
            }
            if(sideRand == 3){
                //Right
                startRand = new Vector3(410.0f, Random.Range(-305.0f, 20.0f), -1.0f);
                normalizedResult = (middle - startRand).normalized;
            }
            spawnRoutine = StartCoroutine(SpawnCherry());
        }
    }

    IEnumerator SpawnCherry(){
        float elapsedTime = 0.0f;
        GameObject liveCherry = Instantiate(cherry, startRand, Quaternion.identity);
        while(elapsedTime < 10.0f){
            liveCherry.transform.position += normalizedResult * 65.0f * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Destroy(liveCherry);
        spawnRoutine = null;
        yield return null;
    }
}
