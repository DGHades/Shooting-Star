using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMovingTargetSquare : MonoBehaviour
{
    float timer = 0;
    bool isSpawned = false;
    public GameObject newObject;
    public GameObject targetObject;
    GameObject[] UnspawnObjects;
    // Use this for initialization
    void Start() 
    {
       
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
       



        float rangeEnemyAmount = Random.Range(5, 10);
        if (timer >= 10 && isSpawned == false)
        {
            for (int i = 0; i < rangeEnemyAmount; i++)
            {
                float rangeX = Random.Range(-11, 11);
                float rangeY = Random.Range(-4, 4);
                Vector3 newPosition = new Vector3(rangeX, rangeY);
                GameObject t = (GameObject)(Instantiate(newObject, newPosition, Quaternion.identity));
            }

            isSpawned = true;
        }



        if (timer >= 15)
        {
            UnspawnObjects = GameObject.FindGameObjectsWithTag("Unspawned");

            foreach (GameObject g in UnspawnObjects)
            {
                Vector3 newPosition = new Vector3(g.transform.position.x,g.transform.position.y);
                GameObject t = (GameObject)(Instantiate(targetObject, newPosition, Quaternion.identity));
                Destroy(g);
            }

            timer = 0;
            isSpawned = false;
        }

    }
}
