using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI Revenue;
    // Start is called before the first frame update

    void Start()
    {
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        Revenue.text = PlayerPrefs.GetInt("Revenue", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariable.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", GlobalVariable.score);
            HighScore.text = "HighScore: " + GlobalVariable.score.ToString();
        }
        if (GlobalVariable.stopGame == true)
        {
            
            Revenue.text = PlayerPrefs.GetInt("Revenue").ToString();
            GlobalVariable.stopGame = false;
        }
    }
}
