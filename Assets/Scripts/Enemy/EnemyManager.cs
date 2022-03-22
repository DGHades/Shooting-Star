
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy[] entitiesToSpawn;
    public Spawner spawner;
    private int spawnedEntities;
    [SerializeField]
    private ManageWaves manageWaves;
    GameObject[] unspawnObjects;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Check can spawn and spawn them
    void FixedUpdate()
    {
        if (!GlobalVariable.startGame) return;
        //check if every particle from spawning is deleted
        foreach (Enemy enemy in entitiesToSpawn)
        {
            // Check Spawn conditions

            if (GlobalVariable.waveCount % enemy.spawnEachWave == 0 || (enemy.waveCount != 0 && enemy.waveCount == GlobalVariable.waveCount))
            {
                if (enemy.spawnAmount >= GameObject.FindGameObjectsWithTag(enemy.gameObject.tag).Length)
                {
                    StartCoroutine(spawner.Spawn(enemy.gameObject));
                }
            }
        }

    }
    // Destruction of the game scene
    void EndGame()
    {
        StopAllCoroutines();
        foreach (Enemy enemy in entitiesToSpawn)
            unspawnObjects = GameObject.FindGameObjectsWithTag(enemy.gameObject.tag);
        foreach (GameObject gameObject in unspawnObjects)
            Destroy(gameObject);

        Destroy(this);

    }
}
