using UnityEngine;

public class ManageWaves : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariable.fillbarValue >= GlobalVariable.waveScore)
        {

            GlobalVariable.fillbarMin = 0;
            GlobalVariable.waveScore *= 1.5f;
            GlobalVariable.fillbarValue = 0;
            GlobalVariable.waveCount++;
        }
    }
}
