using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : SpawnManager
{
    public List<GameObject> _enemies;

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _bossPrefab;

    private bool _isBossSpawned;

    private void Update()
    {
        _enemies.RemoveAll(s => s == null);

        if (_enemies.Count == 3 && !_isBossSpawned)
        {
            SpawnBoss();
        }

        if (_enemies.Count == 0)
        {
            GameManager.instance.IsVictorious = true;
            SceneManager.LoadScene(2);
        }
    }

    protected override void SpawnLoot()
    {
        Vector3 pos = new Vector3(Random.Range(-50, 51), Random.Range(-50, 51), 0);

        GameObject _enemy = Instantiate(_enemyPrefab, pos, Quaternion.identity);
        _enemy.transform.parent = this.transform;

        _enemies.Add(_enemy);
    }

    private void SpawnBoss()
    {
        Vector3 pos = new Vector3(0, 0, 0);

        GameObject _boss = Instantiate(_bossPrefab, pos, Quaternion.identity);
        _boss.transform.parent = this.transform;

        _enemies.Add(_boss);

        _isBossSpawned = true;
    }
}
