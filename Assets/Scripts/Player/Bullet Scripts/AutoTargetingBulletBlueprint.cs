﻿using UnityEngine;

public class AutoTargetingBulletBlueprint : Bullet
{
    protected override bool StillAlive()
    {
        return base.StillAlive() && target != null;
    }
    // Move is called once per frame
    public override void Move()
    {
        GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position) * bulletForce);
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Set rotation
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    protected override void OnTargetHit(Collider2D coll)
    {
        //Check with what the Bullet Collided
        if (target != null)
        {
            if (coll.gameObject.tag == target.gameObject.tag)
            {
                //Get Health component of Object and use GotHit();
                Enemy enemy = coll.gameObject.GetComponent<Enemy>();
                enemy.GotHit(attackDmg);
                TakeDamage(enemy.bulletDamage);
            }

        }
        else
        {
            markedForDestruction = true;

        }
    }
}
