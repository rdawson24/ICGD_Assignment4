using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelOne(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        //DontDestroyOnLoad(this);
    }

    public void LevelTwo(){
        Debug.Log("Clicked");
    }

    public void Exit(){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
    }
}

