using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Delete if hits Unspawned Object
        if (collision.gameObject.tag.StartsWith("Target"))
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
      
    }
}
