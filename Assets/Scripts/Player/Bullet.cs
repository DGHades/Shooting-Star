using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BaseBulletBlueprint blueprint;
    public GameObject target;
    public float health;
    public virtual void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Border")
        {
            //Destroy Bullet if it hits Border
            Destroy(gameObject);
        }
        else
        {

            blueprint.OnTriggerEnter2D(coll);
        }
    }
    public void SetBlueprintAndTarget(BaseBulletBlueprint blueprint, GameObject target)
    {
        this.blueprint = blueprint;
        this.target = target;
        health = blueprint.bulletHealth;
    }
}