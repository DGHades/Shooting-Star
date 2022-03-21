using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject particleObject;
    public ParticleSystem sparticleSystem;
    public IMovementEnemy movementScript;
    public SpriteRenderer sr;
    public int spawnAmount;
    public int waveAmount;
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

    // Is called when a bullet hits the enemy in BaseBullet.cs
    public void GotHit(float damage)
    {
        //Subtract DMG from Health of Object
        health -= damage;
        if (health <= 0)
        {
            //Do destroy Animation before Destroying Object
            stopRotation = true;
            lockEnemy();
            HelperFunctionsSTATIC.DestroyAnim(this, destroyed);
            destroyed = true;
            GlobalVariable.score += 2;
            GlobalVariable.fillbarValue += 2;
            GlobalVariable.money += 1;
        }

    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (movementScript != null && isSpawned && !stopRotation)
            movementScript.Move(gameObject);
       
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
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0);
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
