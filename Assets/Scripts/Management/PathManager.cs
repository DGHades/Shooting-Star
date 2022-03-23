using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class PathManager : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed = 5f;
    float distancerTravelled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancerTravelled += speed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distancerTravelled);
    }
}
