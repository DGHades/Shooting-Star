using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyGetter : MonoBehaviour
{
    public TextMeshProUGUI Money;
    // Start is called before the first frame update
    void Start()
    {
        Money.text = PlayerPrefs.GetInt("Revenue").ToString();
    }
}
