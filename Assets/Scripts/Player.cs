using UnityEngine;

public class Player : MonoBehaviour
{
    private bool stopTop = false, stopBot = false, stopLeft = false, stopRight = false;
    public GameObject playerOptic;
    public float attackDmg, attackspeed;
    Vector3 _origPos = new Vector3();

    private void OnTriggerExit2D(Collider2D other)
    {
        //Re-Activate movement in direction that has been blocked
        if (other.gameObject.name == "BorderTop")
        {
            stopTop = false;
        }
        if (other.gameObject.name == "BorderBottom")
        {
            stopBot = false;
        }
        if (other.gameObject.name == "BorderLeft")
        {
            stopLeft = false;
        }
        if (other.gameObject.name == "BorderRight")
        {
            stopRight = false;
        }
        if (other.gameObject.tag == "Bullet")
        {
            //Get Direction
            Vector3 dir = other.transform.position - playerOptic.transform.position;
            //calculate rotation
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            //set rotation
            playerOptic.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //On Collision with Target, Player Object gest Destroyed aka dies
        //and Activate Respawn Button/Menu before
        // TODO

        if (collision.gameObject.name == "BorderTop")
        {
            stopTop = true;
        }
        if (collision.gameObject.name == "BorderBottom")
        {
            stopBot = true;
        }
        if (collision.gameObject.name == "BorderLeft")
        {
            stopLeft = true;
        }
        if (collision.gameObject.name == "BorderRight")
        {
            stopRight = true;
        }
    }

    // Update is called once per frame
    // Controls
    void FixedUpdate()
    {
        //Movement
        //Block input on Border hit
        if (Input.GetKey(KeyCode.LeftArrow) && stopLeft == false)
        {
            gameObject.transform.Translate(Vector3.left * 0.1f);
        }
        if (Input.GetKey(KeyCode.UpArrow) && stopTop == false)
        {
            gameObject.transform.Translate(Vector3.up * 0.1f);
        }
        if (Input.GetKey(KeyCode.DownArrow) && stopBot == false)
        {
            gameObject.transform.Translate(Vector3.down * 0.1f);
        }
        if (Input.GetKey(KeyCode.RightArrow) && stopRight == false)
        {
            gameObject.transform.Translate(Vector3.right * 0.1f);
        }

        //Change player looking direction in moving direction
        Vector3 moveDirection = playerOptic.gameObject.transform.position - _origPos;
        //only do if player is moving
        if (moveDirection != Vector3.zero)
        {
            //calculation for rotation
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            playerOptic.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //position behind player looking direction because calculation actually 
        //calculates from != player moving direction
        _origPos = playerOptic.gameObject.transform.position;
    }
}