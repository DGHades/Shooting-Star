using UnityEngine;

[CreateAssetMenu]
public class AutoTargetingBulletBlueprint : BaseBulletBlueprint
{
    public void Initialize(Bullet bullet, GameObject target)
    {
        attackDmg = 100;
        cooldown = 0.2f;
        movementSpeed = 0.3f;
        bulletHealth = 0;
        bulletForce = 100;
        bullet.target = target;
        base.Initialize(bullet);
    }
    public override void Spawn(GameObject bulletObj, Transform currentPos, GameObject target)
    {
        GameObject bullet = (GameObject)(Instantiate(bulletObj, currentPos.position, Quaternion.identity));
        bullet.GetComponent<Rigidbody2D>().AddForce((target.transform.position - currentPos.position) * bulletForce);
        //Calculate Rotation to Target direction
        Vector3 dir = target.transform.position - currentPos.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Set rotation
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        AfterSpawn(bullet.GetComponent<Bullet>());
        Initialize(bullet.GetComponent<Bullet>(), target);
    }
    // Move is called once per frame
    public override void Move(Bullet bullet)
    {

        bullet.GetComponent<Rigidbody2D>().AddForce((bullet.target.transform.position - bullet.transform.position) * bulletForce);
        Vector3 dir = bullet.target.transform.position - bullet.transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Set rotation
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        base.Move(bullet);
    }
    public override void OnTargetHit(Collider2D coll, Bullet bullet)
    {
        //Check with what the Bullet Collided
        if (coll.gameObject.tag == bullet.target.gameObject.tag)
        {
            //Get Health component of Object and use GotHit();
            Enemy enemy = coll.gameObject.GetComponent<Enemy>();
            enemy.GotHit(attackDmg);
            TakeDamage(enemy.bulletDamage, bullet);

        }
    }

}
