﻿using UnityEngine;
public class Player : MonoBehaviour
{
    [HideInInspector]
    public bool stopTop = false, stopBot = false, stopLeft = false, stopRight = false;
    public Canvas BeforeDieMenue;
    public Canvas BeforeStartMenue;
    public ParticleSystem spawnBurstParticleSystem;
    public AnalogGlitch analog;
    public ParticleSystem spawnExplosionParticleSystem;
    public ManageWaves WaveManager;

    public float attackDmg, attackspeed;
    Vector3 _origPos = new Vector3();
    private bool once = false;
    private bool onceTwo = false;

    [SerializeField]
    private Gun gun;
    [SerializeField]
    private PlayerOpticTurn playerOptic;

    private void Start()
    {
        BeforeStartMenue.gameObject.SetActive(true);
        BeforeDieMenue.gameObject.SetActive(false);
    }

    private void StartAnim()
    {
        analog.colorDrift = 1;
        analog.scanLineJitter = 0.8f;
        var em = spawnBurstParticleSystem.emission;

        em.enabled = true;
        spawnBurstParticleSystem.Play();


        em = spawnExplosionParticleSystem.emission;

        em.enabled = true;
        spawnExplosionParticleSystem.Play();

        Invoke(nameof(StopAnim), 0.2f);

    }
    private void StopAnim()
    {
        var em = spawnBurstParticleSystem.emission;
        em.enabled = false;
        em = spawnExplosionParticleSystem.emission;
        em.enabled = false;
        analog.colorDrift = 0;
        analog.scanLineJitter = 0;
    }

    // Update is called once per frame
    // Controls
    void FixedUpdate()
    {

        if (GlobalVariable.startGame && !once)
        {
            StartAnim();
            once = true;
        }
        if (FindPlayerInRange.waveCleared && !onceTwo)
        {
            StartAnim();
            onceTwo = true;
        }
        if (!FindPlayerInRange.waveCleared)
        {
            onceTwo = false;
        }

        //Movement
        //Block input on Border hit
        if (GlobalVariable.startGame)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && stopLeft == false)
            {
                gameObject.transform.Translate(Vector3.left * 0.1f);
            }
            if (Input.GetKey(KeyCode.UpArrow) && stopTop == false)
            {
                gameObject.transform.Translate(Vector3.up * 0.1f);
            }
            if (Input.GetKey(KeyCode.DownArrow) && stopBot == false)
            {
                gameObject.transform.Translate(Vector3.down * 0.1f);
            }
            if (Input.GetKey(KeyCode.RightArrow) && stopRight == false)
            {
                gameObject.transform.Translate(Vector3.right * 0.1f);
            }
        }
        //Change player looking direction in moving direction
        Vector3 moveDirection = playerOptic.gameObject.transform.position - _origPos;
        //only do if player is moving
        if (moveDirection != Vector3.zero)
        {
            //calculation for rotation
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg - 90;
            playerOptic.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        //position behind player looking direction because calculation actually 
        //calculates from != player moving direction
        _origPos = playerOptic.gameObject.transform.position;
    }

    public void Die()
    {
        attackDmg = 0;
        attackspeed = 999999999;
        stopTop = true;
        stopBot = true;
        stopLeft = true;
        stopRight = true;
        BeforeDieMenue.gameObject.SetActive(true);
        GlobalVariable.stopGame = true;
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector2(0, 0);
    }
}