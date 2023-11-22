using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _weaponLootPrefabs;
    [SerializeField] private GameObject[] _ammoLootPrefabs;

    private GameObject _loot;

    private void Start()
    {
        SpawnLoot();
    }

    private void SpawnLoot()
    {
        for (int i = 0; i < 20; i++)
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
}
