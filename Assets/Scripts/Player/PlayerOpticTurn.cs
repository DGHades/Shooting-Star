using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpticTurn : MonoBehaviour
{
    Vector3 _origPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //Change player looking direction in Bullet shooting direction
        if (other.gameObject.tag == "Bullet")
        {
            //Get Direction
            Vector3 dir = other.transform.position - transform.position;
            //calculate rotation
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            //set rotation
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Change player looking direction in moving direction
        Vector3 moveDirection = gameObject.transform.position - _origPos;
        //only do if player is moving
        if (moveDirection != Vector3.zero)
        {
            //calculation for rotation
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //position behind player looking direction because calculation actually 
        //calculates from != player moving direction
        _origPos = gameObject.transform.position;
    }
}
