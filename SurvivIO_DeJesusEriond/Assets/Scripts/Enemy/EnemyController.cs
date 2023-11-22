using UnityEngine;

public class EnemyController : Enemy
{
    [SerializeField] private Transform _player;

    private void Update()
    {
        // Temporary code
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        Vector3 target = new Vector3(_player.position.x, _player.position.y, 0) - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, target), RotationSpeed * Time.deltaTime);
    }
}
