﻿using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject particleObject;
    public float health;

    // Start is called before the first frame update
    public void GotHit(float damage)
    {
        //Subtract DMG from Health of Object
        health -= damage;
        if (health <= 0)
        {
            //Do destroy Animation before Destroying Object
            DestroyAnim(gameObject);
            GlobalVariable.score += 2;
            GlobalVariable.fillbarValue += 2;
            destroyTarget();
        }

    }

    public void destroyTarget()
    {
        //Seperated for future uses
        Destroy(gameObject);
    }
    void DestroyAnim(GameObject g)
    {
        //Counter
        int i = 0;
        do
        {
            //Get Random X and Y Vector to get random directions for Particles
            float rangeX = Random.Range(-1f, 1f);
            float rangeY = Random.Range(-1f, 1f);
            //Create Vector for Direction of Particle
            Vector3 newPosition = new Vector3(g.transform.position.x + rangeX, g.transform.position.y + rangeY);
            //Create object at Declared position 
            GameObject t = (GameObject)(Instantiate(particleObject, newPosition, Quaternion.identity));
            //Add force away from Target Object
            t.GetComponent<Rigidbody2D>().AddForce((t.transform.position - g.transform.position) * 50);
            //Calculation for Rotation so it Faces away from Target Object
            Vector3 dir = g.transform.position - t.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            //Do Rotation
            t.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //Count
            i++;
            //Do 30 Particles
            //was a good Number Change if looks better
        } while (i < 30);


    }

}
