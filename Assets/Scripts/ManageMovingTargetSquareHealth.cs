using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMovingTargetSquareHealth : MonoBehaviour
{
    public float health, type;
    public static int TARGET_BOULDER;
    public GameObject particleObject;
    public ParticleSystem sparticleSystem;
    public SpriteRenderer sr;
    bool once;
    
    // Start is called before the first frame update
    void Start()
    {
        //Actually dont know why, used from Tutorial
        //works so its still here
        //Delete if not needed
        if (type == TARGET_BOULDER)
        {
            health = 100;
        }

        once = false;
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void GotHit(float damage) 
    {
        //Subtract DMG from Health of Object
        health -= damage;
        if (health <= 0)
        {
            //Do destroy Animation before Destroying Object
            
            DestroyAnim(gameObject);
        }

    }

    public void destroyTarget() 
    {
        //Seperated for future uses
        Destroy(gameObject);
    }
    void DestroyAnim(GameObject g)
    {
        if (once == false)
        {
            GlobalVariable.score++;
            GlobalVariable.fillbarValue++;

            var dur = sparticleSystem.main.duration;
            var em = sparticleSystem.emission;

            em.enabled = true;
            sparticleSystem.Play();

            Destroy(sr);
            Invoke(nameof(destroyTarget), dur);

            once = true;
        }
    }
}
