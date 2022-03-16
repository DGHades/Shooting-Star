using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestruction : MonoBehaviour
{
    float scale = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= 2;
        GetComponent<Rigidbody2D>().velocity = v;

        if (scale > 0.004)
        {
            scale -= 0.004f;
            Vector3 scaling = new Vector3(scale, scale);

            gameObject.transform.localScale = scaling;
        }
        
       
    }


}
