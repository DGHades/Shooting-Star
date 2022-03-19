using UnityEngine;

public static class HelperFunctionsSTATIC
{
    // Start is called before the first frame update
    public static void SpawnAnim(Enemy enemy)
    {
        int i = 0;
        do
        {
            //get Random positions
            float rangeX = Random.Range(-5, 5);
            float rangeY = Random.Range(-5, 5);
            //set random positions around Object
            Vector3 newPosition = new Vector3(enemy.transform.position.x + rangeX, enemy.transform.position.y + rangeY);
            GameObject t = (GameObject)(Object.Instantiate(enemy.particleObject, newPosition, Quaternion.identity));
            //add force in target direction
            t.GetComponent<Rigidbody2D>().AddForce((enemy.transform.position - t.transform.position) * 300);
            //rotate in target direction
            Vector3 dir = enemy.transform.position - t.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
            //set rotation
            t.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //counter
            i++;
            //do 30 particles, change if looks better
        } while (i < 30);
    }
    public static void DestroyAnim(Enemy enemy)
    {

        GlobalVariable.score += 2;
        GlobalVariable.fillbarValue += 2;

        var dur = enemy.sparticleSystem.main.duration;
        var em = enemy.sparticleSystem.emission;

        em.enabled = true;
        enemy.sparticleSystem.Play();

        Object.Destroy(enemy.sr);
        enemy.Invoke(nameof(enemy.destroyTarget), dur);
    }
}

