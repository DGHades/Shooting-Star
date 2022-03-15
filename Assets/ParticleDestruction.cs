using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestruction : MonoBehaviour
{
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
        v *= 15;
        GetComponent<Rigidbody2D>().velocity = v;
    }


}
