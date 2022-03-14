using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public float timeStamp;
    public float speed = GlobalVariable.attackspeed;

    // Start is called before the first frame update
    void Start()
    {
        timeStamp = Time.time + speed;
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
        speed = GlobalVariable.attackspeed;
       


    }
   

    public void Shooting(Collider2D coll) 
    {
       
       
        if (timeStamp <= Time.time)
        {
            timeStamp = Time.time + +speed;
            GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
            b.GetComponent<Rigidbody2D>().AddForce((coll.transform.position - GameObject.FindGameObjectWithTag("PLayer").transform.position) * 200);

            Vector3 dir = coll.transform.position - b.transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            b.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


}
