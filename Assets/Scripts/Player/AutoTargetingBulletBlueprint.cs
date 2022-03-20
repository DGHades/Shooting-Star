using UnityEngine;

[CreateAssetMenu]
public class AutoTargetingBulletBlueprint : BaseBulletBlueprint
{
    public override void Initialize()
    {
        attackDmg = 100;
        cooldown = 2.2f;
        movementSpeed = 0.3f;
        bulletHealth = 0;
        bulletForce = 100;
        base.Initialize();
    }
    // Move is called once per frame
    public override void Move()
    {
        foreach (GameObject bullet in bullets)
        {
            if (bullet.GetComponent<Bullet>().target == null)
            {
                RemoveBullet(bullet);
            }
            else
            {
                bullet.GetComponent<Rigidbody2D>().AddForce((bullet.GetComponent<Bullet>().target.transform.position - bullet.transform.position) * bulletForce);
                Vector3 dir = bullet.GetComponent<Bullet>().target.transform.position - bullet.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                //Set rotation
                bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                base.Move();
            }
        }
    }
}
