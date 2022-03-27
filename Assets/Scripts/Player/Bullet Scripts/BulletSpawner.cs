using UnityEngine;
// FOR DEFAULT BULLET
using System;
[Serializable]
public class BulletSpawner : MonoBehaviour, IBulletSpawner
{
    public Bullet Spawn(GameObject bulletObj, Transform currentPos, GameObject target, float bulletForce)
    {
        GameObject bullet = (GameObject)(GameObject.Instantiate(bulletObj, currentPos.position, Quaternion.identity));
        bullet.GetComponent<Rigidbody2D>().AddForce((target.transform.position - currentPos.position) * bulletForce);
        //Calculate Rotation to Target direction
        Vector3 dir = target.transform.position - currentPos.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Set rotation
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        return bullet.GetComponent<Bullet>();
    }
}