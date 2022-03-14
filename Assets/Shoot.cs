using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float timeStamp;
  
    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time + 0.25f;
    }

    // Update is called once per frame

    void OnTriggerStay2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Target")
        {
            Shooting(coll);
        }
    }

    void Update()
    {
        /*

        if (timeStamp <= Time.time )
        {
            timeStamp = Time.time + 1;
            GameObject b = (GameObject)(Instantiate(bullet, transform.position + transform.up * 0.5f, Quaternion.identity));



            b.GetComponent<Rigidbody2D>().AddForce(GameObject.FindGameObjectWithTag("Target").transform.position * 200);
        }


    */


    }
   

    public void Shooting(Collider2D coll) 
    {
       
       
        if (timeStamp <= Time.time)
        {
            timeStamp = Time.time + 0.25f;
            GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
            b.GetComponent<Rigidbody2D>().AddForce((coll.transform.position - GameObject.FindGameObjectWithTag("PLayer").transform.position) * 200);

            Vector3 dir = coll.transform.position - b.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            b.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


}
