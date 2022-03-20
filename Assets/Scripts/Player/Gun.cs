using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timeStamp;
    public BulletHolder bulletHolder;
    // Start is called before the first frame update
    public Player player;

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


}
