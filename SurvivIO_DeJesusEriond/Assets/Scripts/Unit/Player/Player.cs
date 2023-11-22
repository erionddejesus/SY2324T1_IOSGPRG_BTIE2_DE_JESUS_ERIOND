using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Unit
{
    public AmmoType CurrentAmmoType
    {
        get => _currentWeapon._ammoType;
    }

    public int CurrentClip
    {
        get => _currentWeapon._currentClip;
    }

    private PlayerInput _playerInput;

    private Inventory _inventory;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();

        _inventory = GetComponent<Inventory>();

        _isReloading = false;

        base.Initialize(_maxHealth, _movementSpeed, _rotationSpeed);
    }

    private void Update()
    {
        Move();
        Rotate();

        if (_fireRateTimer > 0)
            _fireRateTimer -= Time.deltaTime;

        if (CurrentAmmoType != AmmoType.None && _currentWeapon._currentClip <= 0 && !_isReloading)
        {
            _isReloading = true;
            StartCoroutine(CO_Reload());
        }
    }

    public void SetCurrentWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    public override void Shoot()
    {
        // Pistol mechanics
        if (CurrentAmmoType != AmmoType.None && _fireRateTimer <= 0)
        {
            base.Shoot();
        }
    }

    protected override IEnumerator CO_Reload()
    {
        yield return new WaitForSeconds(1f);

        if (_currentWeapon._clipCapacity <= _inventory.GetCurrentAmmo(CurrentAmmoType))
        {
            _currentWeapon._currentClip = _currentWeapon._clipCapacity;
        }
        else
        {
            _currentWeapon._currentClip = _inventory.GetCurrentAmmo(CurrentAmmoType);
        }

        _inventory.DecreaseAmmo(CurrentAmmoType, _currentWeapon._currentClip);

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
