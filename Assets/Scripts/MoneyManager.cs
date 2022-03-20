using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public int MoneyPayment = 1000;
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
