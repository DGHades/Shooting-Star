using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalVariable : MonoBehaviour
{
    // Start is called before the first frame update
    //Declare every needed Global Variable
    public static float attackspeed;
    public static float attackDmg;
    public static float waveScore;
    public static float fillbarMin;
    public static float fillbarValue;
    public static int score;
    
    public static int waveCount;
    public static bool ItemSelected;
    public static bool startGame;
    public static bool stopGame;
    public GameObject scoreTMP;
    public GameObject waveTMP;

    //For future uses
    GameObject PlayerChecker;
    Vector2 PlayerPos;
    void Start()
    {
        //Set every Gloabl Variable back to standard because
        //Global Variable script is started on Respawn
        attackspeed = 0.1f;
        attackDmg = 100;
        score = 0;
        waveScore = 25;
        fillbarMin = 0;
        fillbarValue = 0;
        ItemSelected = false;
        startGame = false;
        stopGame = false;
        waveCount = 1;
   
    }

    void Update()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        scoreTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + GlobalVariable.score;
        waveTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Level: " + GlobalVariable.waveCount;

    }
}
