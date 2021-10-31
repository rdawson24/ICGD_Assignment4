using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Border : MonoBehaviour
{
    GameObject[] border;
    Image image1;
    Image image2;
    float timer;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        timer = 0.0f;
        border = GameObject.FindGameObjectsWithTag("Border");
        image1 = border[0].GetComponent<Image>();
        image2 = border[1].GetComponent<Image>();
        image1.enabled = true;
        image2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if((int)timer > counter){
            counter++;
            if(image1.enabled){
                image1.enabled = false;
                image2.enabled = true;
            }
            else{
                image2.enabled = false;
                image1.enabled = true;
            }
        }
    }
}
