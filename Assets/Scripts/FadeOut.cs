using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FadeOut : MonoBehaviour
{
    public GameObject CanvasMenue;
    public void FadeMe()
    {
        GlobalVariable.ItemSelected = true;
        StartCoroutine(DoFade());
    }

    IEnumerator DoFade()
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
