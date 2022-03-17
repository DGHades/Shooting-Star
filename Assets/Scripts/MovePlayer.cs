using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool stopTop = false,stopBot=false,stopLeft =false,stopRight=false;
    GameObject[] RespawnObjects;
    // Start is called before the first frame update
    void Start()
    {
        RespawnObjects = GameObject.FindGameObjectsWithTag("RespawnMenu");
    }

    
    void OnTriggerStay2D(Collider2D other)
    {
        //Stop if Player Object hits any Border
        
    }
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
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //On Collision with Target, Player Object gest Destroyed aka dies
        //and Activate Respawn Button/Menu before
        if (collision.gameObject.tag == "TargetSquare" || collision.gameObject.tag == "TargetStar")
        {
            foreach (GameObject g in RespawnObjects)
            {
                g.SetActive(true);
            }
            Destroy(gameObject);
        }
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
        }
    }

