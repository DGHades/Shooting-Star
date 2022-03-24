using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimPositionSetter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindPlayerInRange.waveCleared)
        {
            gameObject.transform.position = new Vector3(0, 0);
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y);
        }
        
    }
}
