using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private void LateUpdate()
    {
        Move();
        WorldBounds();
    }

    private void Move()
    {
        if (_player)
        {
            transform.position = new Vector3(_player.position.x, _player.position.y, -1);
        }
    }

    private void WorldBounds()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -42, 42);
        pos.y = Mathf.Clamp(pos.y, -46, 46);

        transform.position = pos;
    }
}
