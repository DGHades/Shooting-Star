using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject target = null;
    public ParticleSystem hitParticleSystem;
    public bool markedForDestruction = false;
    protected float attackDmg;
    protected float movementSpeed;
    protected float bulletHealth;
    protected float bulletForce;
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
            SplashAnim();
        }
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
            OnTargetHit(coll);
        }
        if (markedForDestruction)
        {
            var em = hitParticleSystem.emission;
            em.enabled = true;
            hitParticleSystem.Play();
            SplashAnim();
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

    void CheckBorder(Collider2D coll)
    {
        if (coll.gameObject.tag == "Border")
        {
            var em = hitParticleSystem.emission;
            em.enabled = true;
            hitParticleSystem.Play();
            markedForDestruction = true;
        }
    }
    public void SetBlueprintValues(BulletBlueprint blueprint, int stackMultiplier = 1)
    {
        attackDmg *= (blueprint.dmgMultiplier * stackMultiplier);
        movementSpeed *= (blueprint.movementSpeedMultiplier * stackMultiplier);
    }
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
    public virtual void Move()
    {
        //Fix the Velocity of Object

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
    public virtual void Spawn(GameObject bulletObj, Transform currentPos, GameObject target)
    {
        GameObject bullet = (GameObject)(Instantiate(bulletObj, currentPos.position, Quaternion.identity));
        bullet.GetComponent<Rigidbody2D>().AddForce((target.transform.position - currentPos.position) * bulletForce);
        //Calculate Rotation to Target direction
        Vector3 dir = target.transform.position - currentPos.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Set rotation
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        AfterSpawn();
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