using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject particleObject;
    public float attackDmg;

    void Start()
    {
        //Scale Bullet size with attack DMG (Bigger for more DMG)
        Vector3 scaling = new Vector3(gameObject.transform.localScale.x * (attackDmg / 100), gameObject.transform.localScale.y * (attackDmg / 100));
        gameObject.transform.localScale = scaling;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Fix the Velocity of Object
        Vector2 v = GetComponent<Rigidbody2D>().velocity;
        v = v.normalized;
        v *= 25;
        GetComponent<Rigidbody2D>().velocity = v;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        //Check with what the Bullet Collided
        if (coll.gameObject.tag == "TargetSquare")
        {
            //Get Health component of Object and use GotHit();
            coll.gameObject.GetComponent<ManageMovingTargetSquareHealth>().GotHit(attackDmg);
            //Destroy Bullet
            Destroy(gameObject);

        }
        if (coll.gameObject.tag == "TargetStar")
        {
            //Get Health component of Object and use GotHit();
            coll.gameObject.GetComponent<ManageMovingTargetStarHealth>().GotHit(attackDmg);
            //Destroy Bullet
            Destroy(gameObject);

        }
        if (coll.gameObject.tag == "Border")
        {
            //Destroy Bullet if it hits Border
            Destroy(gameObject);
        }
    }
}
