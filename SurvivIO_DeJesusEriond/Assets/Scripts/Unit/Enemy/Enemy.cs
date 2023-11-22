using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private Transform _player;

    private void Start()
    {
        base.Initialize(_maxHealth, _movementSpeed, _rotationSpeed);
    }

    private void Update()
    {
        LookAtPlayer(_player);
    }

    private void LookAtPlayer(Transform player)
    {
        Vector3 target = player.position - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, target), _rotationSpeed * Time.deltaTime);
    }
}
