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
    public Transform playerTransform;
    protected List<GameObject> bullets;
    


    public virtual void Initialize()
    {
        bullets = new List<GameObject> { };
    }
    // Move is called once per frame
    public virtual void Move()
    {
        //Fix the Velocity of Object
        foreach (GameObject bullet in bullets)
        {
            Vector2 v = bullet.GetComponent<Rigidbody2D>().velocity;
            v = v.normalized;
            v *= movementSpeed;
            bullet.GetComponent<Rigidbody2D>().velocity = v;
        }

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
        bullet.GetComponent<Bullet>().SetBlueprintAndTarget(this, target);
        bullets.Add(bullet);
    }
    public virtual void AfterSpawn()
    {
        //Scale Bullet size with attack DMG (Bigger for more DMG)
        foreach (GameObject bullet in bullets)
        {
            Vector3 scaling = new Vector3(bullet.transform.localScale.x * (attackDmg / 100), bullet.transform.localScale.y * (attackDmg / 100));
            bullet.transform.localScale = scaling;

        }
    }

    public virtual void OnTargetHit(Collider2D coll, GameObject bullet)
    {
        //Check with what the Bullet Collided
        if (coll.gameObject.tag.StartsWith("Target"))
        {
            //Get Health component of Object and use GotHit();
            Enemy enemy = coll.gameObject.GetComponent<Enemy>();
            enemy.GotHit(attackDmg);
            TakeDamage(enemy.bulletDamage, bullet);

        }
    }
    public virtual void TakeDamage(float bulletDamage, GameObject bullet)
    {
        bullet.GetComponent<Bullet>().health -= bulletDamage;
        if (bullet.GetComponent<Bullet>().health <= 0)
            RemoveBullet(bullet);
    }
    public virtual void RemoveBullet(GameObject gameObject)
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());

        
        bullets.Remove(gameObject);
        Destroy(gameObject);
    }
}
