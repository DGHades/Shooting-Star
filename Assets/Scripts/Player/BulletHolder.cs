using UnityEngine;

public class BulletHolder : MonoBehaviour
{
    [SerializeField]
    private BaseBulletBlueprint bulletBlueprint;
    [SerializeField]
    private Bullet bullet;
    float cooldown;

    private enum baseBulletState
    {
        ready,
        shot,
        cooldown
    }
    baseBulletState state = new baseBulletState();


    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        switch (state)
        {
            case baseBulletState.ready:
                break;
            case baseBulletState.shot:
                bulletBlueprint.Move();
                state = baseBulletState.cooldown;
                cooldown = bulletBlueprint.cooldown;
                break;
            case baseBulletState.cooldown:
                bulletBlueprint.Move();
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                }
                else
                {
                    state = baseBulletState.ready;
                }
                break;
        }
    }

    public void Spawn(GameObject gameObject)
    {
        if (state == baseBulletState.ready)
        {
            bulletBlueprint.Spawn(bullet.gameObject, transform, gameObject);
            bulletBlueprint.AfterSpawn();
            state = baseBulletState.shot;
        }
    }
}