using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private int _amount;

    private void Start()
    {
        for (int i = 0; i < _amount; i++)
        {
            SpawnLoot();
        }
    }

    protected virtual void SpawnLoot()
    {
        Debug.Log("Loot Spawned");
    }
}
