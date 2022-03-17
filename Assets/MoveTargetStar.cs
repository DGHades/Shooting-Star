using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetStar : MonoBehaviour
{

    // Start is called before the first frame update

    void Start()
    {
        Direction();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Rotate(0, 0, 200 * Time.deltaTime); //rotates 50 degrees per second around z axis

        ChangeDirection();

        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= 2.5f;
        GetComponent<Rigidbody2D>().velocity = v;



    }
    void OnCollisionEnter2D(Collision2D coll)
    {

       

    }

    void Direction()
    {
        var number = Random.Range(1, -1);
        var numberTwo = Random.Range(1, -1);
        do
        {
            number = Random.Range(1, -1);
            numberTwo = Random.Range(1, -1);
        } while (number != 0 && numberTwo != 0);

        GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * 2.5f;




    }


    void ChangeDirection() 
    {
        float checker = Random.Range(1, 180);
        if (checker == 100)
        {
            Direction();
        }
    
    }


}
