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
    public static bool spawnStars;
    public static int score;
    public static float waveScore;
    public static float fillbarMin;
    public static float fillbarValue;
    public static bool ItemSelected;
    public static bool startGame;
    public GameObject scoreTMP;
    
    //For future uses
    GameObject PlayerChecker;
    Vector2 PlayerPos;
    void Start()
    {
        //Set every Gloabl Variable back to standard because
        //Global Variable script is started on Respawn
        attackspeed = 0.1f;
        attackDmg = 100;
        spawnStars = true;
        score = 0;
        waveScore = 25;
        fillbarMin = 0;
        fillbarValue = 0;
        ItemSelected = false;
        startGame = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreTMP.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + GlobalVariable.score;
    }
}
