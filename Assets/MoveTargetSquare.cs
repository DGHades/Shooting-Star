using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveTargetSquare : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Direction();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
       transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= 2.5f;
        GetComponent<Rigidbody2D>().velocity = v;



    }
    void Direction() 
    {
        //Create random Direction on Spawning
        var number = Random.Range(1, -1);
        var numberTwo = Random.Range(1, -1);
        do
        {
            //Get Random number that is NOT 0
            number = Random.Range(1, -1);
            numberTwo = Random.Range(1, -1);
        } while (number != 0 && numberTwo != 0);
        //Add speed
        GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * 2.5f;
    }
}
