using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    // Start is called before the first frame update
     public float timeStamp;
    GameObject[] RespawnObjects;
   
    void Start()
    {
        timeStamp = Time.time + 2;
        RespawnObjects = GameObject.FindGameObjectsWithTag("RespawnMenu");
        
    }

    // Update is called once per frame
    void Update()
    {

        if (timeStamp >= Time.time)
        {
            HideRespawnMenu();
        }
    }

    void HideRespawnMenu() 
    {
        foreach (GameObject g in RespawnObjects)
        {
            
            g.SetActive(false);

        }
    }

    public void ShowRespawnMenu()
    {
        foreach (GameObject g in RespawnObjects)
        {
            
            g.SetActive(true);

        }
    }
}
