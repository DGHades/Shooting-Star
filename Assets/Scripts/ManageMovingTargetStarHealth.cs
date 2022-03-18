using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageMovingTargetStarHealth : MonoBehaviour
{
    public float health, type;
    public static int TARGET_BOULDER;
    public GameObject particleObject;
    public ParticleSystem particleSystem;
    public SpriteRenderer sr;
    float dur;
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
            GlobalVariable.score += 2;
            GlobalVariable.fillbarValue += 2;
            destroyTarget();
        }

    }

    public void destroyTarget()
    {
        //Seperated for future uses
        Destroy(gameObject);
    }
    void DestroyAnim(GameObject g)
    {
        dur = particleSystem.main.duration;
        var em = particleSystem.emission;

        em.enabled = true;
        particleSystem.Play();

        Destroy(sr);
        Invoke(nameof(destroyTarget), dur);


    }
}
