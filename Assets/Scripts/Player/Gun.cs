using UnityEngine;
using System.Collections.Generic;
public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private BulletBlueprint blueprint;
    private Dictionary<string, int> upgradeStackCounts;
    [SerializeField]
    private LayerMask layerMask;
    private float cooldown;
    private enum gunState
    {
        ready,
        shot,
        cooldown
    }
    private GameObject shootNext = null;
    gunState state = new gunState();
    public float GetCooldown()
    {
        return cooldown;
    }
    public void shoot(GameObject gameObj)
    {
        if (gameObj.GetComponent<Enemy>().isSpawned)
        {
            blueprint.prefab.GetComponent<Bullet>().Spawn(blueprint, transform, gameObj);
            state = gunState.shot;
        }
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        upgradeStackCounts = new Dictionary<string, int> { };
        if (blueprint.isStackable)
            upgradeStackCounts.Add(blueprint.displayName, 1);
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        Collider2D coll = Physics2D.OverlapCircle(transform.position, 4f, layerMask);
        // Bit shift the index of the Enemy layer (8) to get a bit mask
        if (coll != null)
        {
            shoot(coll.gameObject);
        }
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
        if (_blueprint.isStackable && upgradeStackCounts.TryGetValue(_blueprint.displayName, out int stackCount))
        {
            if (stackCount < _blueprint.maxStacks)
            {
                upgradeStackCounts[_blueprint.displayName] = stackCount + 1;
            }
        }
        Destroy(_blueprint);
    }
}
