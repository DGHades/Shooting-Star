﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    // Start is called before the first frame update
    public static float attackspeed;
    public static float attackDmg;
    GameObject PlayerChecker;
    Vector2 PlayerPos;
    void Start()
    {
        attackspeed = 1;
        attackDmg = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       


    }
}
