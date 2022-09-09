using UnityEngine;

public interface IBulletSpawner
{
    Bullet Spawn(GameObject bulletObj, Transform currentPos, GameObject target, float bulletForce);
}