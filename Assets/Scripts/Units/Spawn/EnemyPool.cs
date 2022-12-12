using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesToSpawn;

    int enemyPoolSize = 10;
    GameObject[] enemies;
    int enemyNumber = -1;

    private static Transform enemyPoolPos;

    private EnemySpawn enemySpawn;

    private void Awake()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();

        enemyPoolPos = GameObject.Find("EnemyPool").transform;

    }

    private void Start()
    {
        //I think that in this particular case, this is good. But in a larger game I should think another way
        enemyPoolSize = enemySpawn.numberOfEnemies;

        enemies = new GameObject[enemyPoolSize];

        for (int i = 0; i < enemyPoolSize; i++)
        {
            //Random enemy
            int enemyToSpawn = Random.Range(0, enemiesToSpawn.Length);

            enemies[i] = Instantiate(enemiesToSpawn[enemyToSpawn], enemyPoolPos.position, Quaternion.identity, enemyPoolPos);
        }
    }

    public void SpawnEnemy()
    {
        enemyNumber++;

        if (enemyNumber > enemyPoolSize - 1)
            enemyNumber = 0;

        if (enemies[enemyNumber].activeSelf) return;

        enemies[enemyNumber].transform.position = enemySpawn.PosToSpawn();

        enemies[enemyNumber].GetComponent<EnemyStateManager>().Spawn();
    }

    public static void ReturnToPoolPos(Transform _enemy)
    {
        _enemy.position = enemyPoolPos.position;
        _enemy.gameObject.SetActive(false);
    }
}
