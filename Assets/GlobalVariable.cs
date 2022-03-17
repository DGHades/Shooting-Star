using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    // Start is called before the first frame update
    //Declare every needed Global Variable
    public static float attackspeed;
    public static float attackDmg;
    public static bool spawnStars;

    //For future uses
    GameObject PlayerChecker;
    Vector2 PlayerPos;
    void Start()
    {
        //Set every Gloabl Variable back to standard because
        //Global Variable script is started on Respawn
        attackspeed = 1;
        attackDmg = 100;
        spawnStars = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       


    }
}
