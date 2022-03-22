using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BaseBulletBlueprint blueprint;
    public float health;
    public bool hasTarget = false;
    public bool hasHealth = false;
    public GameObject target = null;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        blueprint.Move(this);
    }
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag.Contains("Border"))
        {
            Destroy(gameObject);
        }
        else
        {
            blueprint.OnTargetHit(coll, this);
        }

    }
    public void SetBlueprint(BaseBulletBlueprint blueprint)
    {
        this.blueprint = blueprint;
    }
}