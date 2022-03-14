using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RespawnBtnExec : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Player;
    GameObject[] RespawnObjects;

    public Button btn;

    public void Start()
    {
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }


    public void OnClick() 
    {


        Debug.Log("Hallo");
        RespawnObjects = GameObject.FindGameObjectsWithTag("RespawnMenu");

        SceneManager.LoadScene(0);
        
       
    }


}
