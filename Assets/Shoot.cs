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
        //start timer
        timeStamp = Time.time + speed;
    }
    // Update is called once per frame
    void OnTriggerStay2D(Collider2D coll)
    {
        //When collider activates Target is in Circle range ->
        //execute shooting
        if (coll.gameObject.tag == "TargetSquare" || coll.gameObject.tag == "TargetStar")
        {
            Shooting(coll);
        }
    }
    void FixedUpdate()
    {
        //Update attackspeed in case it changes
        speed = GlobalVariable.attackspeed;
    }
    public void Shooting(Collider2D coll) 
    {
        //only shoot when cooldown is over
        if (timeStamp <= Time.time)
        {
            //Set new time when shooting is available again
            timeStamp = Time.time + speed;
            //Create bullet object
            GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
            //Add force in Target direction
            b.GetComponent<Rigidbody2D>().AddForce((coll.transform.position - GameObject.FindGameObjectWithTag("PLayer").transform.position) * 200);
            //Calculate Rotation to Target direction
            Vector3 dir = coll.transform.position - b.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //Set rotation
            b.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


}
