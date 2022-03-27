using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ManageWaves : MonoBehaviour
{
    public AnalogGlitch Glitch;
    public MoneyManager MoneyManager;
    public GameObject Menue;
    public GameObject Player;
    public Spawner Spawner;
    public GameObject[] MyGameObjectList;
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

            float duration = 0.1f;
            StartCoroutine(Shake(duration));
            MoneyManager.MoneyPayment = 0;
            Menue.SetActive(true);
            

            GlobalVariable.startGame = false;
            GlobalVariable.stopGame = true;
            FindPlayerInRange.waveCleared = true;
            Player.transform.position = new Vector2(0, 0);

            //KILL ALL ENEMYS
            FillArray("Square");
            FillArray("Triangle");
            FillArray("Circle");
            FillArray("Star");
        }
        
    }
    void FillArray(string name)
    {
        MyGameObjectList = GameObject.FindGameObjectsWithTag("Target" + name);
        for (int i = 0; i < MyGameObjectList.Length; i++)
        {
            Destroy(MyGameObjectList[i]);
        }
    }

    //Need better Solution. For TestCases it works fine 
    public IEnumerator Shake(float duration)
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            Glitch.colorDrift = 0.854f;
            Glitch.scanLineJitter = 1f;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Glitch.colorDrift = 0f;
        Glitch.scanLineJitter = 0f;
    }
}
