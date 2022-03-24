using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerInRange : MonoBehaviour
{
    public float moveSpeed = 1f;
    float moveSpeedScale = 0.1f;
    private Rigidbody2D rb;
    public GameObject Gem;
    public static bool waveCleared = false;
    Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
        startScale = gameObject.GetComponent<Collider2D>().transform.localScale;
        Gem.GetComponent<Rigidbody2D>().AddForce(Random.onUnitSphere * 0.004f);
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
        if (waveCleared)
        {
            gameObject.GetComponent<Collider2D>().transform.localScale = new Vector3(100f, 100f);
            moveSpeedScale = 0.75f;
        }
        else
        {
            gameObject.GetComponent<Collider2D>().transform.localScale = startScale;
            moveSpeedScale = 0.1f;
        }
    }

    private void Move(GameObject target) 
    {
        rb = Gem.GetComponent<Rigidbody2D>();
        Vector3 direction = target.transform.position - Gem.transform.position;
        
        
        direction.Normalize();
        

        rb.MovePosition(Gem.transform.position + (direction * moveSpeed * Time.deltaTime));
        moveSpeed += moveSpeedScale;
    }
}
