using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;

    private float currentSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // Decrement the player's reload timer
        if (currentSpawnTimer > 0)
            currentSpawnTimer -= Time.deltaTime;

        if (currentSpawnTimer <= 0)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 pos = new Vector3(1, player.position.y + 10, 0);
        Instantiate(enemyPrefab, pos, Quaternion.identity);

        currentSpawnTimer = Random.Range(3.0f, 5.0f);
    }
}
