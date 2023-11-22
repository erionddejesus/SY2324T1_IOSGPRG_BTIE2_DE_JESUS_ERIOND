using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    [SerializeField] protected Weapon _currentWeapon;

    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _bulletSpawnPoint;

    [SerializeField] protected int _movementSpeed;
    [SerializeField] protected int _rotationSpeed;

    [SerializeField] protected int _maxHealth;

    protected float _fireRateTimer;

    protected bool _isReloading;

    private Health _health;

    protected void Initialize(int maxHealth, int movementSpeed, int rotationSpeed)
    {
        _movementSpeed = movementSpeed;
        _rotationSpeed = rotationSpeed;

        _health = GetComponent<Health>();
        _health.Initialize(maxHealth);
    }

    public virtual void Shoot()
    {
        if (_currentWeapon._currentClip > 0)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, transform.rotation);
            bullet.GetComponent<Bullet>().Damage = _currentWeapon._damage;

            _currentWeapon._currentClip--;

            _fireRateTimer = _currentWeapon._fireRate;
        }
    }

    protected virtual IEnumerator CO_Reload()
    {
        yield return new WaitForSeconds(0f);
    }
}
