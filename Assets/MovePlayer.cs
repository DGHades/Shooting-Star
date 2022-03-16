using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool stopTop = false,stopBot=false,stopLeft =false,stopRight=false;
    GameObject[] RespawnObjects;


    void Start()
    {
        RespawnObjects = GameObject.FindGameObjectsWithTag("RespawnMenu");
    }

    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "BorderTop")
        {
            stopTop = true;
        }
        if (other.gameObject.name == "BorderBottom")
        {
            stopBot = true;
        }
        if (other.gameObject.name == "BorderLeft")
        {
            stopLeft = true;
        }
        if (other.gameObject.name == "BorderRight")
        {
            stopRight = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {

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

        if (collision.gameObject.tag == "TargetSquare" || collision.gameObject.tag == "TargetStar")
        {
            

            foreach (GameObject g in RespawnObjects)
            {
                Debug.Log(g.name);
                g.SetActive(true);

            }
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
        {



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

