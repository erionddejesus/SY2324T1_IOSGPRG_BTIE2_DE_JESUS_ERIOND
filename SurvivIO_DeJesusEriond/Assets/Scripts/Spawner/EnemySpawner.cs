using UnityEngine;

public class EnemySpawner : SpawnManager
{
    [SerializeField] private GameObject _enemyPrefab;

    private GameObject _enemy;

    protected override void SpawnLoot()
    {
        Vector3 pos = new Vector3(Random.Range(-50, 51), Random.Range(-50, 51), 0);

        _enemy = Instantiate(_enemyPrefab, pos, Quaternion.identity);
        _enemy.transform.parent = this.transform;
    }
}
