using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject particleObject;
    public ParticleSystem destroyParticleSystem;
    public ParticleSystem spawnParticleSystem;
    public IMovementEnemy movementScript;
    public GameObject target;
    public SpriteRenderer sr;
    public GameObject Camera;

    public int spawnAmount;
    public int spawnEachWave;
    public float health;
    public float bulletDamage;
    public bool isSpawned = false;
    public bool isAnimated = true;
    bool destroyed = false;
    bool stopRotation = false;
    public void Awake()
    {
        //REWORK
        movementScript = (IMovementEnemy)System.Reflection.Assembly.GetAssembly(Type.GetType("Move" + gameObject.tag)).CreateInstance("Move" + gameObject.tag);
    }

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
    }
    // Is called when a bullet hits the enemy in BaseBullet.cs
    public void GotHit(float damage)
    {
        
        float duration = 0.1f;
        float magnitude = 0.2f;
        //Subtract DMG from Health of Object
        health -= damage;
        if (health <= 0)
        {
            //Do destroy Animation before Destroying Object
            StartCoroutine(shake(duration,magnitude));
            stopRotation = true;
            lockEnemy();
            Destroy(GetComponent<Collider2D>());
            HelperFunctionsSTATIC.DestroyAnim(this, destroyed);
            destroyed = true;
            GlobalVariable.score += 2;
            GlobalVariable.fillbarValue += 2;
            
            
        }
    }

    public IEnumerator shake(float duration, float magnitude)
    {
        Vector3 originalPos = new Vector3(0, 0, -10);
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            float xOffset = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;
            float yOffset = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;

            Camera.transform.position = originalPos + new Vector3(xOffset, yOffset, originalPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        Camera.transform.position = originalPos;
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (movementScript != null && isSpawned && !stopRotation)
            movementScript.Move(gameObject, target);
    }
    public void unlockEnemyWhenSpawned()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        isSpawned = true;
        movementScript.Direction(gameObject);
    }
    public void lockEnemy()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        isSpawned = false;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
    }
    public bool canSpawn()
    {
        return true;
    }
    public void destroyTarget()
    {
        //Seperated for future uses
        
        Destroy(gameObject);
    }
}
