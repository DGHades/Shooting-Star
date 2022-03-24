using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddCurrencyOnPlayerHit : MonoBehaviour
{
    Color color;
    public GameObject Money;
    // Start is called before the first frame update
    void Start()
    {
        Money = GameObject.FindGameObjectWithTag("MoneyText");
        color = gameObject.GetComponent<SpriteRenderer>().material.color;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            PlayerPrefs.SetInt("Revenue", PlayerPrefs.GetInt("Revenue") +1);
            Money.gameObject.GetComponent<TextMeshProUGUI>().text = "Revenue: " + PlayerPrefs.GetInt("Revenue").ToString();
            Destroy(gameObject);
        }
        if (collision.gameObject.name.Contains("Border"))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, 75 * Time.deltaTime);
        
        color.a -= Time.deltaTime * 0.15f;
        gameObject.GetComponent<SpriteRenderer>().material.color = color;
        if (color.a <= 0)
        {
            Destroy(gameObject);
        }
        

    }
}
