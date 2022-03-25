using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timeStamp;
    public BulletHolder bulletHolder;
    // Start is called before the first frame update
    public Player player;
   
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //findUpgradeAndUprade("AutoTargetingBullet");
    }
    void OnTriggerStay2D(Collider2D target)
    {
        //On Collision with Target, Player Object gest Destroyed aka dies
        //and Activate Respawn Button/Menu before
        // TODO
        if (target.gameObject.tag.StartsWith("Target"))
        {
            shoot(target);
        }
    }
    public void shoot(Collider2D coll)
    {

        bulletHolder.Spawn(coll.gameObject);
    }

    public void findUpgradeAndUprade(string name)
    {
        try
        {
            bulletHolder.Upgrade((BaseBulletBlueprint)ScriptableObject.CreateInstance(name + "Blueprint"));
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}
