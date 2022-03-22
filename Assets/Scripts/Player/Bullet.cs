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
        if (!markedForDestruction)
        {
            blueprint.Move(this);
        }
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (markedForDestruction)
        {
            Destroy(gameObject);
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        var em = hitParticleSystem.emission;
        var dur = hitParticleSystem.main.duration;
        em.enabled = true;
        hitParticleSystem.Play();
        if (coll.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
        else if (!markedForDestruction)
        {
            blueprint.OnTargetHit(coll, this);
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
}