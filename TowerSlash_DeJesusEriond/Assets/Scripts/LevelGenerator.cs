using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies(3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemies(int count)
    {
        // Temporary code
        for (int i = 0; i < count; i++)
        {
            Vector3 pos = new Vector3(1, 0 + (i * 5), 0);

            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }
}
