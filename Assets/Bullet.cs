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
        Vector3 scaling = new Vector3(gameObject.transform.localScale.x * (attackDmg / 100), gameObject.transform.localScale.y * (attackDmg / 100));
        gameObject.transform.localScale = scaling;
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
       


            if (coll.gameObject.tag == "TargetSquare")
            {

                coll.gameObject.GetComponent<ManageMovingTargetSquareHealth>().GotHit(attackDmg);
                Destroy(gameObject);

            }
        
       
            if (coll.gameObject.tag == "TargetStar")
            {

                coll.gameObject.GetComponent<ManageMovingTargetStarHealth>().GotHit(attackDmg);
                Destroy(gameObject);

            }


        
        if (coll.gameObject.tag == "Border")
        {

            Destroy(gameObject);
        }


    }

    
}
