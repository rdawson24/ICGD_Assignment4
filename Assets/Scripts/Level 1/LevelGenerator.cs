using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject manualMap;
    public GameObject piece0;
    public GameObject piece1;
    public GameObject piece2;
    public GameObject piece3;
    public GameObject piece4;
    public GameObject piece5;
    public GameObject piece6;
    public GameObject piece7;
    private int columnNum;
    private int rowNum;
    private float spacing = 10.0f;
    private int above;
    private int below;
    private int left;
    private int right;
    public GameObject parent;
    public GameObject trimmedParent;
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
    // Start is called before the first frame update
    void Start()
    {
        //Destroy's manually made level 01
        Destroy(manualMap);
        //Defines array limits
        rowNum = levelMap.GetLength(0);
        columnNum = levelMap.GetLength(1);
        //Loops over the ray column by column
        for(int i = 0; i < rowNum; i++){
            for(int j = 0; j < columnNum; j++){
                if(i != 0 && i!= rowNum-1 && j != 0 && j != columnNum-1){
                    //Debug.Log("Check all sides");
                    above = levelMap[i-1, j];
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = levelMap[i, j+1];
                }
                if(i == 0 && j == 0){
                    //Debug.Log("Dont check above or to the left");
                    above = -1;
                    below = levelMap[i+1, j];
                    left = -1;
                    right = levelMap[i, j+1];
                }
                if(i == rowNum-1 && j == columnNum-1){
                    //Debug.Log("Dont check below or to the right");
                    above = levelMap[i-1, j];
                    below = -1;
                    left = levelMap[i, j-1];
                    right = -1;
                }
                if(i == 0 && j == columnNum-1){
                    //Debug.Log("Dont check above or to the right");
                    above = -1;
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = -1;
                }
                if(i == rowNum-1 && j == 0){
                    //Debug.Log("Dont check below or to the left");
                    above = levelMap[i-1, j];
                    below = -1;
                    right = levelMap[i, j+1];
                    left = -1;
                }
                if(i == 0 && j != 0 && j != columnNum-1){
                    //Debug.Log("Dont check above");
                    above = -1;
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = levelMap[i, j+1];
                }
                if(i != 0 && i != rowNum-1 && j == 0){
                    //Debug.Log("Dont check left");
                    above = levelMap[i-1, j];
                    below = levelMap[i+1, j];
                    left = -1;
                    right = levelMap[i, j+1];
                }
                if(i == rowNum-1 && j != 0 && j != columnNum-1){
                    //Debug.Log("Dont check below");
                    above = levelMap[i-1, j];
                    below = -1;
                    left = levelMap[i, j-1];
                    right = levelMap[i, j+1];
                }
                if(i != 0 && i != rowNum-1 && j == columnNum-1){
                    //Debug.Log("Dont check right");
                    above = levelMap[i-1, j];
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = -1;
                }

                if(levelMap[i, j] == 0){
                    //Done
                    Instantiate(piece0, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                }
                if(levelMap[i, j] == 1){
                    //Debug.Log("i = " + i + " j = " + j);
                    //Debug.Log("Above: " + above + " Below " + below + " Right " + right + " Left " + left);
                    if((above == 1 || above == 2 || above == 7) && (right == 1 || right == 2 || right == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((below == 1 || below == 2 || below == 7) && (right == 1 || right == 2 || right == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);
                    }
                    else if((below == 1 || below == 2 || below == 7) && (left == 1 || left == 2 || left == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), parent.transform);
                    }
                    else if((above == 1 || above == 2 || above == 7 && left == 1 || left == 2 || left == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), parent.transform);
                    }
                }
                if(levelMap[i, j] == 2){
                    if((above == 1 || above == 2 || above == 7) && (below == 1 || below == 2 || below == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((right == 1 || right == 2 || right == 7) && (left == 1 || left == 2 || left == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                    }
                    else if((above == -1 || above == 1 || above == 2 || above == 7) && (below == -1 || below == 1 || below == 2 || below == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((right == -1 || right == 1 || right == 2 || right == 7) && (left == -1 || left == 1 || left == 2 || left == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                    }
                }
                if(levelMap[i, j] == 3){
                    //Check 3 4 7
                    if((above == 4 || above == 7) && (right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((below == 4 || below == 7) && (right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);
                    }
                    else if((below == 4 || below == 7) && (left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), parent.transform);
                    }
                    else if((above == 4 || above == 7) && (left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), parent.transform);
                    }
                    else if((above == 3 || above == 4 || above == 7) && (right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((below == 3 || below == 4 || below == 7) && (right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);
                    }
                    else if((below == 3 || below == 4 || below == 7) && (left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), parent.transform);
                    }
                    else if((above == 3 || above == 4 || above == 7) && (left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), parent.transform);
                    }
                    else if((above == -1 || above == 3 || above == 4 || above == 7) && (right == -1 || right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((below == -1 || below == 3 || below == 4 || below == 7) && (right == -1 || right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), parent.transform);
                    }
                    else if((below == -1 || below == 3 || below == 4 || below == 7) && (left == -1 || left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), parent.transform);
                    }
                    else if((above == -1 || above == 3 || above == 4 || above == 7) && (left == -1 ||left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), parent.transform);
                    }
                }
                if(levelMap[i, j] == 4){
                    //Check 3 4 7
                    if((above == 3 || above == 4 || above == 7) && (below == 3 || below == 4 || below == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((right == 3 || right == 4 || right == 7) && (left == 3 || left == 4 || left == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                    }
                    else if((above == -1 || above == 3 || above == 4 || above == 7) && (below == -1 || below == 3 || below == 4 || below == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), parent.transform);
                    }
                    else if((right == -1 || right == 3 || right == 4 || right == 7) && (left == -1 || left == 3 || left == 4 || left == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                    }
                }
                if(levelMap[i, j] == 5){
                    //Done
                    Instantiate(piece5, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                }
                if(levelMap[i, j] == 6){
                    //Done
                    Instantiate(piece6, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                }
                if(levelMap[i, j] == 7){
                    //Check 1 2 3 4 7
                    Instantiate(piece7, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, parent.transform);
                }
            }
        }
        GameObject genreated = GameObject.FindWithTag("GeneratedLevel");
        Instantiate(genreated, new Vector3(genreated.transform.position.x + 214.5f, genreated.transform.position.y, genreated.transform.position.z + 550.51f), Quaternion.Euler(0.0f, -180.0f, 0.0f));
        
        for(int i = 0; i < rowNum-1; i++){
            for(int j = 0; j < columnNum; j++){
                if(i != 0 && i!= rowNum-2 && j != 0 && j != columnNum-1){
                    //Debug.Log("Check all sides");
                    above = levelMap[i-1, j];
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = levelMap[i, j+1];
                }
                if(i == 0 && j == 0){
                    //Debug.Log("Dont check above or to the left");
                    above = -1;
                    below = levelMap[i+1, j];
                    left = -1;
                    right = levelMap[i, j+1];
                }
                if(i == rowNum-2 && j == columnNum-1){
                    //Debug.Log("Dont check below or to the right");
                    above = levelMap[i-1, j];
                    below = -1;
                    left = levelMap[i, j-1];
                    right = -1;
                }
                if(i == 0 && j == columnNum-1){
                    //Debug.Log("Dont check above or to the right");
                    above = -1;
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = -1;
                }
                if(i == rowNum-2 && j == 0){
                    //Debug.Log("Dont check below or to the left");
                    above = levelMap[i-1, j];
                    below = -1;
                    right = levelMap[i, j+1];
                    left = -1;
                }
                if(i == 0 && j != 0 && j != columnNum-1){
                    //Debug.Log("Dont check above");
                    above = -1;
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = levelMap[i, j+1];
                }
                if(i != 0 && i != rowNum-1 && j == 0){
                    //Debug.Log("Dont check left");
                    above = levelMap[i-1, j];
                    below = levelMap[i+1, j];
                    left = -1;
                    right = levelMap[i, j+1];
                }
                if(i == rowNum-2 && j != 0 && j != columnNum-1){
                    //Debug.Log("Dont check below");
                    above = levelMap[i-1, j];
                    below = -1;
                    left = levelMap[i, j-1];
                    right = levelMap[i, j+1];
                }
                if(i != 0 && i != rowNum-2 && j == columnNum-1){
                    //Debug.Log("Dont check right");
                    above = levelMap[i-1, j];
                    below = levelMap[i+1, j];
                    left = levelMap[i, j-1];
                    right = -1;
                }

                if(levelMap[i, j] == 0){
                    //Done
                    Instantiate(piece0, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                }
                if(levelMap[i, j] == 1){
                    if((above == 1 || above == 2 || above == 7) && (right == 1 || right == 2 || right == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((below == 1 || below == 2 || below == 7) && (right == 1 || right == 2 || right == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), trimmedParent.transform);
                    }
                    else if((below == 1 || below == 2 || below == 7) && (left == 1 || left == 2 || left == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), trimmedParent.transform);
                    }
                    else if((above == 1 || above == 2 || above == 7 && left == 1 || left == 2 || left == 7)){
                        Instantiate(piece1, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), trimmedParent.transform);
                    }
                }
                if(levelMap[i, j] == 2){
                    if((above == 1 || above == 2 || above == 7) && (below == 1 || below == 2 || below == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((right == 1 || right == 2 || right == 7) && (left == 1 || left == 2 || left == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                    }
                    else if((above == -1 || above == 1 || above == 2 || above == 7) && (below == -1 || below == 1 || below == 2 || below == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((right == -1 || right == 1 || right == 2 || right == 7) && (left == -1 || left == 1 || left == 2 || left == 7)){
                        Instantiate(piece2, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                    }
                }
                if(levelMap[i, j] == 3){
                    //Check 3 4 7
                    if((above == 4 || above == 7) && (right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((below == 4 || below == 7) && (right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), trimmedParent.transform);
                    }
                    else if((below == 4 || below == 7) && (left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), trimmedParent.transform);
                    }
                    else if((above == 4 || above == 7) && (left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), trimmedParent.transform);
                    }
                    else if((above == 3 || above == 4 || above == 7) && (right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((below == 3 || below == 4 || below == 7) && (right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), trimmedParent.transform);
                    }
                    else if((below == 3 || below == 4 || below == 7) && (left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), trimmedParent.transform);
                    }
                    else if((above == 3 || above == 4 || above == 7) && (left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), trimmedParent.transform);
                    }
                    else if((above == -1 || above == 3 || above == 4 || above == 7) && (right == -1 || right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((below == -1 || below == 3 || below == 4 || below == 7) && (right == -1 || right == 3 || right == 4 || right == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 0.0f), trimmedParent.transform);
                    }
                    else if((below == -1 || below == 3 || below == 4 || below == 7) && (left == -1 || left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 270.0f), trimmedParent.transform);
                    }
                    else if((above == -1 || above == 3 || above == 4 || above == 7) && (left == -1 ||left == 3 || left == 4 || left == 7)){
                        Instantiate(piece3, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 180.0f), trimmedParent.transform);
                    }
                }
                if(levelMap[i, j] == 4){
                    //Check 3 4 7
                    if((above == 3 || above == 4 || above == 7) && (below == 3 || below == 4 || below == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((right == 3 || right == 4 || right == 7) && (left == 3 || left == 4 || left == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                    }
                    else if((above == -1 || above == 3 || above == 4 || above == 7) && (below == -1 || below == 3 || below == 4 || below == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.Euler(0.0f, 0.0f, 90.0f), trimmedParent.transform);
                    }
                    else if((right == -1 || right == 3 || right == 4 || right == 7) && (left == -1 || left == 3 || left == 4 || left == 7)){
                        Instantiate(piece4, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                    }
                }
                if(levelMap[i, j] == 5){
                    //Done
                    Instantiate(piece5, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                }
                if(levelMap[i, j] == 6){
                    //Done
                    Instantiate(piece6, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                }
                if(levelMap[i, j] == 7){
                    //Check 1 2 3 4 7
                    Instantiate(piece7, new Vector3(0 + (spacing * j), 0 + (spacing * i * -1.0f), 0), Quaternion.identity, trimmedParent.transform);
                }
            }
        }
        GameObject trimmedGenerated = GameObject.FindWithTag("TrimmedGeneratedLevel");;
        Instantiate(trimmedGenerated, new Vector3(trimmedGenerated.transform.position.x, trimmedGenerated.transform.position.y -164.66f, trimmedGenerated.transform.position.z + 912.24f), Quaternion.Euler(0.0f, -180.0f, -180.0f));
        Instantiate(trimmedGenerated, new Vector3(trimmedGenerated.transform.position.x + 41.41f, trimmedGenerated.transform.position.y - 164.66f, trimmedGenerated.transform.position.z), Quaternion.Euler(0.0f, 0.0f, -180.0f));
        Destroy(trimmedGenerated);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
