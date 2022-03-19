
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

            if (enemy.waveAmount <= GlobalVariable.waveCount)
            {
                if (enemy.spawnAmount >= GameObject.FindGameObjectsWithTag(enemy.gameObject.tag).Length)
                {
                    StartCoroutine(spawner.Spawn(enemy.gameObject));
                }
            }
        }

    }
}
