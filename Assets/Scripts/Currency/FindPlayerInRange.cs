using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerInRange : MonoBehaviour
{
    bool found = false;
    public float moveSpeed = 0.5f;
    private Rigidbody2D rb;
    public GameObject Gem;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Move(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Move(collision.gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void Move(GameObject target) 
    {
        rb = Gem.GetComponent<Rigidbody2D>();
        Vector3 direction = target.transform.position - Gem.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        direction.Normalize();
        

        rb.MovePosition(Gem.transform.position + (direction * moveSpeed * Time.deltaTime));
        moveSpeed += 0.01f;
    }
}
