using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] float distance;
    [Range(1f, 3f)][SerializeField] float timeBetweenEnemies;
    public int numberOfEnemies;

    private float _timer;
    private EnemyPool enemyPool;

    private void Awake()
    {
        enemyPool = FindObjectOfType<EnemyPool>();
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= timeBetweenEnemies)
        {
            SpawnEnemy();
            _timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        enemyPool.SpawnEnemy();
    }

    public Vector3 PosToSpawn()
    {
        float randomAngle = Random.Range(0, 360);
        float xValue = Mathf.Sin(randomAngle) * distance;
        float zValue = Mathf.Cos(randomAngle) * distance;

        return new Vector3(xValue, 0.25f, zValue);
    }
}
