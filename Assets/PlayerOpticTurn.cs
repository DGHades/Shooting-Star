using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpticTurn : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 _origPos = new Vector3();
    
    void Start()
    {
       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Bullet")
        {
            Vector3 dir = other.transform.position - transform.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = gameObject.transform.position - _origPos;
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        _origPos = gameObject.transform.position;
    }
}
