using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bullet;
    public GameObject particleObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= 25;
        GetComponent<Rigidbody2D>().velocity = v;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Target") {
            SpawnAnim(coll.gameObject);
            Destroy(coll.gameObject);

            Destroy(gameObject);
            
        }
        if (coll.gameObject.tag == "Border")
        {
            
            Destroy(gameObject);
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

            t.GetComponent<Rigidbody2D>().AddForce((t.transform.position- g.transform.position) * 50);

            Vector3 dir = g.transform.position - t.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            t.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


            i++;
        } while (i < 30);


    }
}
