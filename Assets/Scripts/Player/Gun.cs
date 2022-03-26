using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private BulletBlueprint blueprint;
    private float cooldown;
    private enum gunState
    {
        ready,
        shot,
        cooldown
    }
    gunState state = new gunState();
    public float GetCooldown()
    {
        return cooldown;
    }
    public void shoot(GameObject gameObj)
    {
        if (state == gunState.ready && gameObj.GetComponent<Enemy>().isSpawned)
        {
            GameObject bullet = Bullet.Spawn(blueprint.prefab, transform, gameObj, 100);
            bullet.GetComponent<Bullet>().SetBlueprintValues(blueprint);
            state = gunState.shot;
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
                //TBD
                break;
            case gunState.shot:
                state = gunState.cooldown;
                cooldown = blueprint.cooldown;
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


    public void findUpgradeAndUprade(string name)
    {
        try
        {
            Upgrade((BulletBlueprint)ScriptableObject.CreateInstance(name + "Blueprint"));
        }
        catch (System.Exception)
        {

            throw;
        }
    }
    public void Upgrade(BulletBlueprint _blueprint)
    {
        blueprint.displayName = _blueprint.displayName;
        blueprint.displayImgSprite = _blueprint.displayImgSprite;
        blueprint.prefab = _blueprint.prefab;
        blueprint.isStackable = _blueprint.isStackable;
        blueprint.maxStacks = _blueprint.maxStacks;
        blueprint.dmgMultiplier = _blueprint.dmgMultiplier;
        blueprint.movementSpeedMultiplier = _blueprint.movementSpeedMultiplier;
        blueprint.cooldown = _blueprint.cooldown;
        Destroy(_blueprint);
    }
}
