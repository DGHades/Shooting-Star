using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeOut : MonoBehaviour
{
    public GameObject CanvasMenue;
    public MoneyManager MoneyManager;
    public void StartGameWithUpgrade()
    {
        GlobalVariable.ItemSelected = true;
        StartCoroutine(DoFadeWithUpGrade());
    }
    public void StartWithoutUpgrade()
    {
        StartCoroutine(DoFadeWithOutupGrade());
    }
    IEnumerator DoFadeWithOutupGrade()
    {
        StartCoroutine(StartGame());
        yield return null;
    }

    IEnumerator DoFadeWithUpGrade()
    {
        if (PlayerPrefs.GetInt("Revenue") > MoneyManager.MoneyPayment)
        {
            StartCoroutine(StartGame());
            yield return null;
        }
    }
    IEnumerator StartGame()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime * 2;
            yield return null;
        }
        CanvasMenue.SetActive(false);
        canvasGroup.alpha = 1;
        GlobalVariable.startGame = true;
        yield return null;
       
    }
}
