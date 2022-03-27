using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected GameObject target = null;
    [SerializeField]
    protected ParticleSystem hitParticleSystem;
    protected bool markedForDestruction = false;
    protected float attackDmg = 1000000;
    protected float movementSpeed = 100;
    protected float bulletHealth = 100;
    protected float bulletForce = 100;
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (StillAlive())
        {
            Move();
        }
        else
        {
            Debug.LogAssertion(StillAlive() == false);
            SplashAnim();
        }
    }
    public void Spawn(BulletBlueprint blueprint, Transform currentPos, GameObject target, int stackMultiplier = 1)
    {
        Bullet bullet = GetComponent<IBulletSpawner>().Spawn(blueprint.prefab, currentPos, target, bulletForce);
        bullet.SetBlueprintValues(blueprint, stackMultiplier);
    }
    protected virtual bool StillAlive()
    {
        return !markedForDestruction;
    }

    private void SplashAnim()
    {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider2D>());
        Destroy(GetComponent<TrailRenderer>());
        Destroy(GetComponent<Rigidbody2D>());
        var dur = hitParticleSystem.main.duration;
        DestroyBullet(dur);

    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Border")
        {
            markedForDestruction = true;
            var em = hitParticleSystem.emission;
            em.enabled = true;
            hitParticleSystem.Play();
        }
        else if (!markedForDestruction)
        {
            OnTargetHit(coll);
        }
    }
    protected virtual void OnTargetHit(Collider2D coll)
    {
        if (coll.gameObject.tag.StartsWith("Target"))
        {
            //Get Health component of Object and use GotHit();
            Enemy enemy = coll.gameObject.GetComponent<Enemy>();
            enemy.GotHit(attackDmg);
            TakeDamage(enemy.bulletDamage);
        }
    }
    public void SetBlueprintValues(BulletBlueprint blueprint, int stackMultiplier = 1)
    {
        attackDmg *= (blueprint.dmgMultiplier * stackMultiplier);
        movementSpeed *= (blueprint.movementSpeedMultiplier * stackMultiplier);
    }
    public void DestroyBullet(float duration = 0)
    {
        Debug.Log("Destroying with a delay of" + duration);
        GameObject.Destroy(this.gameObject, duration);
    }
    public virtual void Move()
    {
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= movementSpeed;
        GetComponent<Rigidbody2D>().velocity = v;
    }
    public virtual void AfterSpawn()
    {
        //Scale Bullet size with attack DMG (Bigger for more DMG)
        Vector3 scaling = new Vector3(transform.localScale.x * (attackDmg / 100), transform.localScale.y * (attackDmg / 100));
        transform.localScale = scaling;
    }

    protected virtual void TakeDamage(float bulletDamage)
    {
        bulletHealth -= bulletDamage;
        if (bulletHealth <= 0)
        {
            markedForDestruction = true;
        }
    }
}