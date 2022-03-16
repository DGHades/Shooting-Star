using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMovingTargetStar : MonoBehaviour
{
    
    float timer = 0;
    bool isSpawned = false;
    bool isAnimated = false;
    public GameObject newObject;
    public GameObject targetObject;
    public GameObject particleObject;
    GameObject[] UnspawnObjects;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (GlobalVariable.spawnStars == true)
        {
            timer += Time.deltaTime;




            float rangeEnemyAmount = Random.Range(5, 10);
            if (timer >= 5 && isSpawned == false)
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

            if (timer >= 9 && isAnimated == false)
            {
                UnspawnObjects = GameObject.FindGameObjectsWithTag("UnspawnedStar");

                foreach (GameObject g in UnspawnObjects)
                {

                    SpawnAnim(g);
                }

                isAnimated = true;
            }
            
            UnspawnObjects = GameObject.FindGameObjectsWithTag("ParticleSpawn");
            if (UnspawnObjects.Length == 0 && isAnimated == true)
            {
                UnspawnObjects = GameObject.FindGameObjectsWithTag("UnspawnedStar");
                
                foreach (GameObject g in UnspawnObjects)
                {
                    Vector3 newPosition = new Vector3(g.transform.position.x, g.transform.position.y);
                    GameObject t = (GameObject)(Instantiate(targetObject, newPosition, Quaternion.identity));
                    t.GetComponent<ManageMovingTargetStarHealth>().type = ManageMovingTargetStarHealth.TARGET_BOULDER;
                    Destroy(g);
                    Debug.Log(g.name);

                }


                timer = 0;
                isSpawned = false;
                isAnimated = false;

            }
        }
        


    }

    void SpawnAnim(GameObject g)
    {
        int i = 0;
        do
        {
            float rangeX = Random.Range(-5, 5);
            float rangeY = Random.Range(-5, 5);

            Vector3 newPosition = new Vector3(g.transform.position.x + rangeX, g.transform.position.y + rangeY);
            GameObject t = (GameObject)(Instantiate(particleObject, newPosition, Quaternion.identity));

            t.GetComponent<Rigidbody2D>().AddForce((g.transform.position - t.transform.position) * 300);

            Vector3 dir = g.transform.position - t.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            t.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            i++;
        } while (i < 30);


    }

}
