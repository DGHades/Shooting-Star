using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject bullet;
    public GameObject particleObject;
    float attackDmg;
    void Start()
    {
        attackDmg = GlobalVariable.attackDmg;
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
        if (coll.gameObject.tag == "Target" ) {
            
            coll.gameObject.GetComponent<ManageMovingTargetSquareHealth>().GotHit(attackDmg);
            Destroy(gameObject);
            
        }
        if (coll.gameObject.tag == "Border")
        {
            
            Destroy(gameObject);
        }

    }

    
}
