using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestruction : MonoBehaviour
{
    float scale = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy Particle after 0.5 seconds
        Destroy(gameObject, 0.5f);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Set fixed Velocity
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= 2;
        GetComponent<Rigidbody2D>().velocity = v;

        //Make particle smaller by 0.004 every frame until 0
        if (scale > 0.004)
        {
            scale -= 0.004f;
            Vector3 scaling = new Vector3(scale, scale);
            gameObject.transform.localScale = scaling;
        }    
    }
}
