using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    [SerializeField] private CameraMovement cameraMovement;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject playerPrefab;

    private GameObject player;

    private float currentSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
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

    private void SpawnPlayer()
    {
        Vector3 pos = new Vector3(1, -3, 0);
        player = Instantiate(playerPrefab, pos, Quaternion.identity);

        gameUI.player = player.GetComponent<Player>();
        cameraMovement.player = player.GetComponent<Player>();

        if (GameManager.Instance.characterSelected == 0) // Default
        {
            player.GetComponent<Player>().SetMaxLives(3);
            player.GetComponent<Player>().SetDashAmount(10);
        }
        else if (GameManager.Instance.characterSelected == 1) // Tank
        {
            player.GetComponent<Player>().SetMaxLives(5);
            player.GetComponent<Player>().SetDashAmount(10);
        }
        else if (GameManager.Instance.characterSelected == 2) // Speed
        {
            player.GetComponent<Player>().SetMaxLives(3);
            player.GetComponent<Player>().SetDashAmount(20);
        }
    }

    private void SpawnEnemy()
    {
        Vector3 pos = new Vector3(1, player.transform.position.y + 10, 0);
        Instantiate(enemyPrefab, pos, Quaternion.identity);

        currentSpawnTimer = Random.Range(3.0f, 5.0f);
    }
}
