using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    // Start is called before the first frame update
    public static float attackspeed;
    GameObject PlayerChecker;
    Vector2 PlayerPos;
    void Start()
    {
        attackspeed = 1;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPos = GameObject.FindGameObjectWithTag("PLayer").transform.position;


    }
}
