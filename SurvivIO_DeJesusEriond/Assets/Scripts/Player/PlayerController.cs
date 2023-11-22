using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Player
{
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
        Rotate();
        WorldBounds();
    }

    public void FireWeapon()
    {
        Debug.Log("PEW PEW");
    }

    private void Move()
    {
        Vector2 inputMove = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(inputMove.x, inputMove.y, 0);

        transform.Translate(MovementSpeed * Time.deltaTime * move, Space.World);
    }

    private void Rotate()
    {
        Vector2 inputRotate = playerInput.actions["Aim"].ReadValue<Vector2>();
        Vector3 rotate = new Vector3(inputRotate.x, inputRotate.y, 0);

        if (rotate.x != 0 || rotate.y != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, rotate), RotationSpeed * Time.deltaTime);
        }
    }

    private void WorldBounds()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -50, 50);
        pos.y = Mathf.Clamp(pos.y, -50, 50);

        transform.position = pos;
    }
}
