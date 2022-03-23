using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerForGame : MonoBehaviour
{
    public GameObject DieMenue;
    public GameObject BeforeStartMenue;
    public void StartGame()
    {
        
        //Start
        SceneManager.LoadScene(0);    
    }
    public void GoMenue()
    {
        //Menü
        SceneManager.LoadScene(1);
    }
    public void HideMenue()
    {
        SceneManager.LoadScene(0);
        BeforeStartMenue.SetActive(true);
        DieMenue.SetActive(false);
       
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
