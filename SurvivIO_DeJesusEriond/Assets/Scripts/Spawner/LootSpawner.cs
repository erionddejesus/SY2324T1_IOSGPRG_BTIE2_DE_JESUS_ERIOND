using UnityEngine;

public class LootSpawner : SpawnManager
{
    [SerializeField] private GameObject[] _weaponLootPrefabs;
    [SerializeField] private GameObject[] _ammoLootPrefabs;

    private GameObject _loot;

    protected override void SpawnLoot()
    {
        Vector3 pos = new Vector3(Random.Range(-50, 51), Random.Range(-50, 51), 0);

        if (Random.Range(0, 100) < 70)
        {
            _loot = Instantiate(_ammoLootPrefabs[Random.Range(0, 3)], pos, Quaternion.identity);
        }
        else
        {
            _loot = Instantiate(_weaponLootPrefabs[Random.Range(0, 3)], pos, Quaternion.identity);
        }

        _loot.transform.parent = this.transform;
    }
}
