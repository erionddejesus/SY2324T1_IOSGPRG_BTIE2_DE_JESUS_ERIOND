using UnityEngine;

public class Boss : Enemy
{
    [SerializeField] private GameObject _grenadeLauncherPrefab;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();

        base.Initialize(_maxHealth, _movementSpeed, _rotationSpeed);
        SetWeapon();
    }

    private void SetWeapon()
    {
        Weapon weapon = new Weapon();
        weapon.Initialize(GunType.GrenadeLauncher, AmmoType.Grenade, 5, 4.6f, 0, 1, 100, 1);

        SetCurrentWeapon(weapon, 3);
    }

    public void DropLoot()
    {
        Instantiate(_grenadeLauncherPrefab, transform.position, Quaternion.identity);
    }
}
