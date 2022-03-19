using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update

    public IEnumerator<WaitForSeconds> Spawn(GameObject gameObj)
    {
        float rangeX = Random.Range(-11, 11);
        float rangeY = Random.Range(-4, 4);
        //set random positions around Object
        Vector3 newPosition = new Vector3(transform.position.x + rangeX, transform.position.y + rangeY);
        GameObject newEntity = Instantiate(gameObj, newPosition, Quaternion.identity);
        Enemy enemy = newEntity.GetComponent<Enemy>();
        enemy.sr.color = new Color(0.67f, 0.24f, 0.47f, 0.66f);
        yield return new WaitForSeconds(2);
        //yield on a new YieldInstruction that waits for 5 seconds.
        HelperFunctionsSTATIC.SpawnAnim(enemy);
        yield return new WaitForSeconds(0.5f);
        enemy.sr.color = new Color(0.67f, 0.24f, 0.47f, 1f);
        enemy.unlockEnemyWhenSpawned();
    }
}
