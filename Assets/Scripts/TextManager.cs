using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI HighScore;

    public TextMeshProUGUI Revenue;
    public GameObject BeforeDieMenue;
    // Start is called before the first frame update

    void Start()
    {
        HighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        Revenue.text = "Revenue: " + PlayerPrefs.GetInt("Revenue", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariable.score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", GlobalVariable.score);
            HighScore.text = "HighScore: " + GlobalVariable.score.ToString();
        }
        if (GlobalVariable.stopGame == true) //Kinda Weird Solution
        {
            GlobalVariable.stopGame = false;
        }
    }

    private void Awake() //AWAKES ON TRUEFALSE SOLUTION
    {
        PlayerPrefs.SetInt("Revenue", GlobalVariable.money + PlayerPrefs.GetInt("Revenue"));
        Revenue.text = "Revenue: " + GlobalVariable.money.ToString();
    }
}
