using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 offset = new Vector3();
    void Start()
    {
        offset = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector3.down * 0.05f);

        if (gameObject.transform.position.y <= -20) 
        {
            gameObject.transform.position = offset;
        }



    }
}
