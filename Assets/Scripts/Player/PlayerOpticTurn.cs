using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOpticTurn : MonoBehaviour
{
    Vector3 _origPos = new Vector3();
    [SerializeField]
    private Player player;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //On Collision with Target, Player Object gest Destroyed aka dies
        //and Activate Respawn Button/Menu before

        if (collision.gameObject.name == "BorderTop")
        {
            player.stopTop = true;
        }
        if (collision.gameObject.name == "BorderBottom")
        {
            player.stopBot = true;
        }
        if (collision.gameObject.name == "BorderLeft")
        {
            player.stopLeft = true;
        }
        if (collision.gameObject.name == "BorderRight")
        {
            player.stopRight = true;
        }
        if (collision.gameObject.tag == "Trigger")
        {
            player.analog.scanLineJitter = 0.3f;
        }
    }

    /// <summary>
    /// Sent when another object leaves a trigger collider attached to
    /// this object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerExit2D(Collider2D other)
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
        if (other.gameObject.tag.StartsWith("Target"))
        {
            player.Die();
        }
        if (other.gameObject.name == "BorderTop")
        {
            player.stopTop = false;
        }
        if (other.gameObject.name == "BorderBottom")
        {
            player.stopBot = false;
        }
        if (other.gameObject.name == "BorderLeft")
        {
            player.stopLeft = false;
        }
        if (other.gameObject.name == "BorderRight")
        {
            player.stopRight = false;
        }
        if (other.gameObject.tag == "Trigger")
        {
            player.analog.scanLineJitter = 0;
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
