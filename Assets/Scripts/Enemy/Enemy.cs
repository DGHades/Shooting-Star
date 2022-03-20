using System;
using System.Reflection;
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
            HelperFunctionsSTATIC.DestroyAnim(this);
            GlobalVariable.score += 2;
            GlobalVariable.fillbarValue += 2;
        }

    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (movementScript != null && isSpawned)
            movementScript.Move(gameObject);
    }
    public void unlockEnemyWhenSpawned()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = true;
        isSpawned = true;
        movementScript.Direction(gameObject);
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
