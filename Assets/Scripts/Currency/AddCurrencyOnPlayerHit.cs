using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCurrencyOnPlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GlobalVariable.money += 1;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, 25 * Time.deltaTime);

    }
}
