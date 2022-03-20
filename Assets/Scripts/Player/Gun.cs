using UnityEngine;

public class Gun : MonoBehaviour
{
    public float timeStamp;
    public BaseBullet bulletObj;
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
        //only shoot when cooldown is over
        if (timeStamp <= Time.time)
        {
            //Set new time when shooting is available again
            timeStamp = Time.time + player.attackspeed;
            GameObject bullet = (GameObject)(Instantiate(bulletObj, player.transform.position, Quaternion.identity));
            ((BaseBullet)bullet.GetComponent("BaseBullet")).attackDmg = player.attackDmg;
            bullet.GetComponent<Rigidbody2D>().AddForce((coll.transform.position - player.transform.position) * 200);
            //Calculate Rotation to Target direction
            Vector3 dir = coll.transform.position - bullet.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //Set rotation
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


}
