using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI HighScore;
    // Start is called before the first frame update
    void Start()
    {
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariable.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", GlobalVariable.score);
            HighScore.text = "HighScore: " + GlobalVariable.score.ToString();
        }
    }
}
