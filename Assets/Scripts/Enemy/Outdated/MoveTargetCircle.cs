using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetCircle : IMovementEnemy
{
    public void Move(GameObject gameObject, GameObject target) {
        //rotates 50 degrees per second around z axis
        gameObject.transform.Rotate(0, 0, 50 * Time.deltaTime);
        Vector2 v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= 2.5f;
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
    }
    public void Direction(GameObject gameObject)
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
        gameObject.GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * 2.5f;
    }
}
