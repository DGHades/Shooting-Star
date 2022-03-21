using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetTriangle : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    Collider2D test;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("PLayer");
        rb = this.GetComponent<Rigidbody2D>(); 
        test = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (test.enabled) { 
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        }
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
