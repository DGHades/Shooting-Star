using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BaseBulletBlueprint blueprint;
    public GameObject target;
    public float health;
    public ParticleSystem hitParticleSystem;

    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        var em = hitParticleSystem.emission;
        var dur = hitParticleSystem.duration;
        em.enabled = true;
        hitParticleSystem.Play();
        
        if (coll.gameObject.tag == "Border")
        {
            
            //Destroy Bullet if it hits Border
            blueprint.RemoveBullet(gameObject);
            //Destroy(this);
        }
        else if (coll.gameObject.tag == target.tag)
        {
            
            blueprint.OnTargetHit(coll, gameObject);
            
        }
        em.enabled = false;
        
    }
    public void SetBlueprintAndTarget(BaseBulletBlueprint blueprint, GameObject target)
    {
        this.blueprint = blueprint;
        this.target = target;
        health = blueprint.bulletHealth;
        Debug.Log(this.target);
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        blueprint.RemoveBullet(gameObject);
    }
}