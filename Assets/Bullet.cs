using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Target") {
            Destroy(coll.gameObject);
            Destroy(gameObject);
            
        }
        if (coll.gameObject.tag == "Border")
        {
            
            Destroy(gameObject);
        }

    }
}
