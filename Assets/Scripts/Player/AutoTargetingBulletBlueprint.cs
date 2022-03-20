using UnityEngine;

[CreateAssetMenu]
public class AutoTargetingBulletBlueprint : BaseBulletBlueprint
{
    // Move is called once per frame
    public override void Move()
    {
        bullet.GetComponent<Rigidbody2D>().AddForce((bullet.GetComponent<Bullet>().target.transform.position - bullet.transform.position) * bulletForce);
        base.Move();

    }
}
