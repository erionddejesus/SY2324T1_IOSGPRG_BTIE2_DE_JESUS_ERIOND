using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Unit
{
    public AmmoType CurrentAmmoType
    {
        get => _currentWeapon._ammoType;
    }

    private PlayerInput _playerInput;

    private Inventory _inventory;

    private bool _isShooting;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        _inventory = GetComponent<Inventory>();

        base.Initialize(_maxHealth, _movementSpeed, _rotationSpeed);
    }

    private void Update()
    {
        Move();
        Rotate();

        if (_fireRateTimer > 0)
        {
            _fireRateTimer -= Time.deltaTime;
        }

        if (_isShooting)
        {
            Shoot();
        }

        if (CurrentAmmoType != AmmoType.None && _currentWeapon._currentClip <= 0 && !_isReloading)
        {
            _isReloading = true;
            StartCoroutine(CO_Reload(_currentWeapon._reloadSpeed));
        }
    }

    public void SetShooting(bool isShooting)
    {
        _isShooting = isShooting;
    }

    public override void Shoot()
    {
        if (CurrentAmmoType != AmmoType.None)
        {
            base.Shoot();

            if (CurrentAmmoType != AmmoType.Automatic)
            {
                _isShooting = false;
            }
        }
    }

    protected override IEnumerator CO_Reload(float time)
    {
        yield return new WaitForSeconds(time);

        if (_currentWeapon._clipCapacity <= _inventory.GetCurrentAmmo(CurrentAmmoType))
        {
            CurrentClip = _currentWeapon._clipCapacity;
        }
        else
        {
            CurrentClip = _inventory.GetCurrentAmmo(CurrentAmmoType);
        }

        _inventory.DecreaseAmmo(CurrentAmmoType, CurrentClip);

        _isReloading = false;
    }

    private void Move()
    {
        Vector2 inputMove = _playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(inputMove.x, inputMove.y, 0);

        transform.Translate(_movementSpeed * Time.deltaTime * move, Space.World);
    }

    private void Rotate()
    {
        Vector2 inputRotate = _playerInput.actions["Aim"].ReadValue<Vector2>();
        Vector3 rotate = new Vector3(inputRotate.x, inputRotate.y, 0);

        if (rotate.x != 0 || rotate.y != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, rotate), _rotationSpeed * Time.deltaTime);
        }
    }
}
