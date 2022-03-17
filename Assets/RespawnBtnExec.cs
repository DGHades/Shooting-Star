using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnBtnExec : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    public void Start()
    {
        //set Button
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick() 
    {
        //Reload scene
        SceneManager.LoadScene(0);
    }
}
