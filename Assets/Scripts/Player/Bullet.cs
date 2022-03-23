using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BaseBulletBlueprint blueprint;
    public float health;
    public bool hasTarget = false;
    public bool hasHealth = false;
    public GameObject target = null;
    public ParticleSystem hitParticleSystem;
    public bool markedForDestruction = false;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
       

    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        
        
        if (!markedForDestruction)
        {
            blueprint.Move(this);
        }
    }

    private void SplashAnim() 
    {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<TrailRenderer>());
        Destroy(GetComponent<Rigidbody2D>());
        var dur = hitParticleSystem.main.duration;
        Invoke(nameof(DestroyBullet), dur);

    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
       
        if (coll.gameObject.tag == "Border")
        {
            var em = hitParticleSystem.emission;
            em.enabled = true;
            hitParticleSystem.Play();
            markedForDestruction = true;
        }
        else if (!markedForDestruction)
        {
            blueprint.OnTargetHit(coll, this);
        }
        if (markedForDestruction)
        {
            var em = hitParticleSystem.emission;
            em.enabled = true;
            hitParticleSystem.Play();
            SplashAnim();
        }

    }
    public void SetBlueprint(BaseBulletBlueprint blueprint)
    {
        this.blueprint = blueprint;
    }
    public void SetTargetNull()
    {
        markedForDestruction = true;
        target = null;
    }
    public bool CheckTarget()
    {
        if (target == null)
        {
            markedForDestruction = true;
            return false;
        }
        else
        {
            return true;
        }
    }
    public void DestroyBullet() 
    {
        Destroy(gameObject);
    }
}