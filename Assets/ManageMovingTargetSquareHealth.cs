using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMovingTargetSquareHealth : MonoBehaviour
{
    public float health, type;
    public static int TARGET_BOULDER;
    public GameObject particleObject;
    // Start is called before the first frame update
    void Start()
    {
        if (type == TARGET_BOULDER)
        {
            health = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GotHit(float damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyAnim(gameObject);
            destroyTarget();
        }

    }

    public void destroyTarget() 
    {
        Destroy(gameObject);
    }
    void DestroyAnim(GameObject g)
    {
        int i = 0;
        do
        {
            float rangeX = Random.Range(-1f, 1f);
            float rangeY = Random.Range(-1f, 1f);

            Vector3 newPosition = new Vector3(g.transform.position.x + rangeX, g.transform.position.y + rangeY);
            GameObject t = (GameObject)(Instantiate(particleObject, newPosition, Quaternion.identity));

            t.GetComponent<Rigidbody2D>().AddForce((t.transform.position - g.transform.position) * 50);

            Vector3 dir = g.transform.position - t.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            t.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            i++;
        } while (i < 30);


    }
}
