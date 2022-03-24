using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddCurrencyOnPlayerHit : MonoBehaviour
{
    public GameObject Money;
    // Start is called before the first frame update
    void Start()
    {
        Money = GameObject.FindGameObjectWithTag("MoneyText");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            PlayerPrefs.SetInt("Revenue", PlayerPrefs.GetInt("Revenue") +1);
            Money.gameObject.GetComponent<TextMeshProUGUI>().text = "Revenue: " + PlayerPrefs.GetInt("Revenue").ToString();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, 0, 75 * Time.deltaTime);

    }
}
