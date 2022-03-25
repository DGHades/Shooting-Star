using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timeStamp;
    // Start is called before the first frame update
    public Player player;
    [SerializeField]
    private BaseBulletBlueprint bulletBlueprint;
    [SerializeField]
    private Bullet bullet;
    float cooldown;

    private enum gunState
    {
        ready,
        shot,
        cooldown
    }
    gunState state = new gunState();
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //findUpgradeAndUprade("AutoTargetingBullet");
    }
    public void shoot(GameObject gameObj)
    {

        if (state == gunState.ready)
        {
            bulletBlueprint.Spawn(bullet.gameObject, transform, gameObj);
            state = gunState.shot;
        }
    }

    public void findUpgradeAndUprade(string name)
    {
        try
        {
            Upgrade((BaseBulletBlueprint)ScriptableObject.CreateInstance(name + "Blueprint"));
        }
        catch (System.Exception)
        {

            throw;
        }
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        switch (state)
        {
            case gunState.ready:
                break;
            case gunState.shot:
                state = gunState.cooldown;
                cooldown = bulletBlueprint.cooldown;
                break;
            case gunState.cooldown:
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                }
                else
                {
                    state = gunState.ready;
                }
                break;
        }
    }

    public void Upgrade(BaseBulletBlueprint blueprint)
    {
        bulletBlueprint = blueprint;
    }
}
