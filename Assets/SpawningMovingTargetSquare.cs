using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningMovingTargetSquare : MonoBehaviour
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
        //update timer
        timer += Time.deltaTime;
        //Set random enemy amount
        float rangeEnemyAmount = Random.Range(5, 10);
        if (timer >= 5 && isSpawned == false)
        {
            //Spawn unspawned Targets
            for (int i = 0; i < rangeEnemyAmount; i++)
            {
                float rangeX = Random.Range(-11, 11);
                float rangeY = Random.Range(-4, 4);
                Vector3 newPosition = new Vector3(rangeX, rangeY);
                GameObject t = (GameObject)(Instantiate(newObject, newPosition, Quaternion.identity));
            }
            //is needed if not made = infinite spawning
            isSpawned = true;
        }
        //Spawn particles for Spawning
        if (timer >= 9 && isAnimated == false)
        {
            //find every unspawned target location
            UnspawnObjects = GameObject.FindGameObjectsWithTag("Unspawned");
            foreach (GameObject g in UnspawnObjects)
            {
                SpawnAnim(g);
            }
            //is needed if not made = infinite spawning
            isAnimated = true;
        }
        //check if every particle from spawning is deleted
        UnspawnObjects = GameObject.FindGameObjectsWithTag("ParticleSpawn");
        if (UnspawnObjects.Length == 0 && isAnimated == true)
        {
            //find every unspawned target location
            UnspawnObjects = GameObject.FindGameObjectsWithTag("Unspawned");
            foreach (GameObject g in UnspawnObjects)
            {
                //spawn Targets
                Vector3 newPosition = new Vector3(g.transform.position.x,g.transform.position.y);
                GameObject t = (GameObject)(Instantiate(targetObject, newPosition, Quaternion.identity));
                t.GetComponent<ManageMovingTargetSquareHealth>().type = ManageMovingTargetSquareHealth.TARGET_BOULDER;
                //destroy unspawned targets
                Destroy(g);
            }
            //Reset
            timer = 0;
            isSpawned = false;
            isAnimated = false;
        }
    }

    void SpawnAnim(GameObject g) 
    {
        //counter
        int i = 0;
        do
        {
            //get Random positions
            float rangeX = Random.Range(-5, 5);
            float rangeY = Random.Range(-5, 5);
            //set random positions around Object
            Vector3 newPosition = new Vector3(g.transform.position.x + rangeX, g.transform.position.y + rangeY);
            GameObject t = (GameObject)(Instantiate(particleObject, newPosition, Quaternion.identity));
            //add force in target direction
            t.GetComponent<Rigidbody2D>().AddForce((g.transform.position - t.transform.position) * 300);
            //rotate in target direction
            Vector3 dir = g.transform.position - t.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            //set rotation
            t.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //counter
            i++;
            //do 30 particles, change if looks better
        } while (i < 30);
    }
}
