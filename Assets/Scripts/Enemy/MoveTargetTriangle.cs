using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetTriangle : IMovementEnemy
{
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Move is called once per frame
    public void Move(GameObject gameObject,GameObject target)
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Vector3 direction = target.transform.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
       
        rb.MovePosition(gameObject.transform.position + (direction * moveSpeed * Time.deltaTime));
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
