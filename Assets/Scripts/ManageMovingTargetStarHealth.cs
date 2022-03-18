using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMovingTargetStarHealth : MonoBehaviour
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
            health = 150;
        }
        once = false;
    }

    // Update is called once per frame
    void Update()
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
            GlobalVariable.score += 2;
            GlobalVariable.fillbarValue += 2;

            var dur = sparticleSystem.main.duration;
            Debug.Log(dur);
            var em = sparticleSystem.emission;

            em.enabled = true;
            sparticleSystem.Play();

            Destroy(sr);
            Invoke(nameof(destroyTarget), dur);
            once = true;
        }
    }
}
