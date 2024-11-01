using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : SingletonManager<MonsterPool>
{
    private Queue<GameObject> pooledEnemies = new Queue<GameObject>();
    private GameObject enemyPrefab;
    private int poolSize = 50;  // �ʱ� Ǯ ũ��

    protected override void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        base.Awake();
    }

    public void InitializePool(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogError("Enemy Prefab�� null�Դϴ�. MonsterPool�� �ʱ�ȭ�� �� �����ϴ�.");
            return;
        }

        if (enemyPrefab != null)
        {
            Debug.LogWarning("MonsterPool�� �̹� �ʱ�ȭ�Ǿ� �ֽ��ϴ�.");
            return;
        }

        enemyPrefab = prefab;
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewEnemy();
        }
    }

    private void CreateNewEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform);
        enemy.SetActive(false);
        pooledEnemies.Enqueue(enemy);
    }

    public GameObject SpawnMob(Vector3 position, Quaternion rotation)
    {
        if (pooledEnemies.Count == 0)
        {
            CreateNewEnemy();
        }

        GameObject enemy = pooledEnemies.Dequeue();
        enemy.transform.position = position;
        enemy.transform.rotation = rotation;
        enemy.SetActive(true);

        return enemy;
    }

    public void DespawnMob(GameObject enemy)
    {
        if (enemy != null)
        {
            enemy.SetActive(false);
            pooledEnemies.Enqueue(enemy);
        }
    }
}