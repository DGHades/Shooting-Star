using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneManagerShoot : MonoBehaviour
{
    public Button btn;
    public Canvas MainMenue;
    // Start is called before the first frame update
    public void Start()
    {
        //set Button
        btn = btn.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }
    public void OnClick()
    {
        //Reload scene Not Needed I guess
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
