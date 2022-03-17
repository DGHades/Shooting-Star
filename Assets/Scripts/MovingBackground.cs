using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 offset = new Vector3();
    void Start()
    {
        //Set starting Position for Background Objects
        //DO NOT CHANGE IF NOT NEEDED
        offset = new Vector3(0, 10, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Move Background Object down
        gameObject.transform.Translate(Vector3.down * 0.05f);
        //if hits specified position set back to starting Position
        if (gameObject.transform.position.y <= -20) 
        {
            gameObject.transform.position = offset;
        }
    }
}
