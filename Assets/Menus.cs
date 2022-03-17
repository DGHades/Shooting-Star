using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    
    public float timeStamp;
    GameObject[] RespawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        //Start timer with 2 Sec offset due to "FindGameObjectsWithTag" in other scripst not working
        //when gameobject disabled too early
        timeStamp = Time.time + 2;
        RespawnObjects = GameObject.FindGameObjectsWithTag("RespawnMenu");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hide menu after time Offset
        if (timeStamp >= Time.time)
        {
            HideRespawnMenu();
        }
    }
    //Explains itself
    void HideRespawnMenu() 
    {
        foreach (GameObject g in RespawnObjects)
        {
            g.SetActive(false);
        }
    }
    //Explains itself
    public void ShowRespawnMenu()
    {
        foreach (GameObject g in RespawnObjects)
        {
            g.SetActive(true);
        }
    }
}
