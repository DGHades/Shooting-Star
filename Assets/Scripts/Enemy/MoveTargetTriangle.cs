using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTargetTriangle : MonoBehaviour
{
    public GameObject player;
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 v = player.GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= movementSpeed;
        player.GetComponent<Rigidbody2D>().velocity = v;
    }
}
