using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BaseBulletBlueprint : ScriptableObject
{
    // Start is called before the first frame update
    public float attackDmg;
    public float cooldown;
    public float movementSpeed;
    public float bulletHealth;
    public float bulletForce;

    // Sets up the bullet Object and all its fields
    public virtual void SetUpWithOldBlueprint(BaseBulletBlueprint blueprint)
    {

    }
    protected virtual void Initialize(Bullet bullet)
    {
        bullet.hasTarget = false;
        bullet.hasHealth = false;
        bullet.health = 0;
        bullet.SetBlueprint(this);
    }
    // Move is called once per frame
    public virtual void Move(Bullet bullet)
    {
        //Fix the Velocity of Object

        Vector2 v = bullet.GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= movementSpeed;
        bullet.GetComponent<Rigidbody2D>().velocity = v;
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
        AfterSpawn(bullet.GetComponent<Bullet>());
        Initialize(bullet.GetComponent<Bullet>());
    }
    public virtual void AfterSpawn(Bullet bullet)
    {
        //Scale Bullet size with attack DMG (Bigger for more DMG)
        Vector3 scaling = new Vector3(bullet.transform.localScale.x * (attackDmg / 100), bullet.transform.localScale.y * (attackDmg / 100));
        bullet.transform.localScale = scaling;
    }

    public virtual void OnTargetHit(Collider2D coll, Bullet bullet)
    {
        //Check with what the Bullet Collided
        if (coll.gameObject.tag.StartsWith("Target"))
        {
            //Get Health component of Object and use GotHit();
            Enemy enemy = coll.gameObject.GetComponent<Enemy>();
            enemy.GotHit(attackDmg);
            if (bullet.hasHealth)
                TakeDamage(enemy.bulletDamage, bullet);
            else
            {
                bullet.markedForDestruction = true;
            }
        }
    }
    protected virtual void TakeDamage(float bulletDamage, Bullet bullet)
    {
        bullet.GetComponent<Bullet>().health -= bulletDamage;
        if (bullet.GetComponent<Bullet>().health <= 0)
            bullet.markedForDestruction = true;
    }
}
