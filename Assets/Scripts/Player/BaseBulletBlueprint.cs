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
    protected GameObject bullet;

    // Move is called once per frame
    public virtual void Move()
    {
        //Fix the Velocity of Object
        if (bullet == null) return;
        Vector2 v = bullet.GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= movementSpeed;

        bullet.GetComponent<Rigidbody2D>().velocity = v;

    }

    public virtual void Spawn(GameObject bulletObj, Transform currentPos, GameObject target)
    {
        this.bullet = (GameObject)(Instantiate(bulletObj, currentPos.position, Quaternion.identity));
        bullet.GetComponent<Rigidbody2D>().AddForce((currentPos.position + target.transform.position) * bulletForce);
        //Calculate Rotation to Target direction
        Vector3 dir = target.transform.position - currentPos.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Set rotation
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        bullet.GetComponent<Bullet>().SetBlueprintAndTarget(this, target);
    }
    public virtual void AfterSpawn()
    {
        //Scale Bullet size with attack DMG (Bigger for more DMG)
        Vector3 scaling = new Vector3(bullet.transform.localScale.x * (attackDmg / 100), bullet.transform.localScale.y * (attackDmg / 100));
        bullet.transform.localScale = scaling;

    }

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        //Check with what the Bullet Collided
        if (coll.gameObject.tag.StartsWith("Target"))
        {
            //Get Health component of Object and use GotHit();
            Enemy enemy = coll.gameObject.GetComponent<Enemy>();
            enemy.GotHit(attackDmg);
            if (bullet != null)
                TakeDamage(enemy.bulletDamage);

        }
    }
    public virtual void TakeDamage(float bulletDamage)
    {
        bullet.GetComponent<Bullet>().health -= bulletDamage;
        if (bullet.GetComponent<Bullet>().health <= 0)
            Destroy(bullet);
    }
}
