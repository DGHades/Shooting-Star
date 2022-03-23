using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int _MoneyPayment = 1000;
    public int MoneyPayment {
            get { return _MoneyPayment; }
            set { _MoneyPayment = value; }
        }
    public void PayMent()
    {
        StartCoroutine(TakeMoney());
    }

    IEnumerator TakeMoney()
    {
        if (MoneyPayment < PlayerPrefs.GetInt("Revenue"))
        {
        PlayerPrefs.SetInt("Revenue", PlayerPrefs.GetInt("Revenue") - MoneyPayment);
        yield return null;
        }
    }
}
