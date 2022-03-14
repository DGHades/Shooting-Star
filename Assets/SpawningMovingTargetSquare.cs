using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMovingTargetSquare : MonoBehaviour
{
    float timer = 0;
    public GameObject newObject;
    // Use this for initialization
    void Start() 
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        

       
        float rangeEnemyAmount = Random.Range(5, 10);
        if (timer >= 10)
        {
            for (int i = 0; i < rangeEnemyAmount; i++)
            {
                float rangeX = Random.Range(-11, 11);
                float rangeY = Random.Range(-4, 4);
                Vector3 newPosition = new Vector3(rangeX, rangeY);
                GameObject t = (GameObject)(Instantiate(newObject, newPosition, Quaternion.identity));
            }
            
            timer = 0;
        }
    }
}
