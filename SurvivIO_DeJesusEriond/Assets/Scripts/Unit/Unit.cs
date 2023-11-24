using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Unit : MonoBehaviour
{
    public int CurrentClip
    {
        get => _currentWeapon._currentClip;
        protected set => _currentWeapon._currentClip = value;
    }

    [SerializeField] protected Weapon _currentWeapon;

    [SerializeField] protected GameObject[] _ammoPrefab;
    [SerializeField] protected Transform _bulletSpawnPoint;

    [SerializeField] private GameObject _weaponSprite;
    [SerializeField] private Sprite[] _sprites;

    [SerializeField] protected int _movementSpeed;
    [SerializeField] protected int _rotationSpeed;

    [SerializeField] protected int _maxHealth;

    protected float _fireRateTimer;

    protected bool _isReloading;

    private Health _health;

    public void SetCurrentWeapon(Weapon weapon, int index)
    {
        if (weapon._gunType == GunType.None)
        {
            return;
        }

        _currentWeapon = weapon;

        _weaponSprite.SetActive(true);
        _weaponSprite.GetComponent<SpriteRenderer>().sprite = _sprites[index];
    }

    public virtual void Shoot()
    {
        if (CurrentClip > 0 && _fireRateTimer <= 0)
        {
            for (int i = 0; i < _currentWeapon._bullets; i++)
            {
                GameObject bullet = Instantiate(_ammoPrefab[(int)_currentWeapon._ammoType], _bulletSpawnPoint.position, transform.rotation);

                bullet.transform.Rotate(0, 0, Random.Range(-_currentWeapon._spread / 2, _currentWeapon._spread / 2));
                bullet.GetComponent<Bullet>().Damage = _currentWeapon._damage;
            }

            CurrentClip--;
            _fireRateTimer = _currentWeapon._fireRate;
        }
    }

    protected void Initialize(int maxHealth, int movementSpeed, int rotationSpeed)
    {
        _movementSpeed = movementSpeed;
        _rotationSpeed = rotationSpeed;

        _health = GetComponent<Health>();
        _health.Initialize(maxHealth);
    }

    protected virtual IEnumerator CO_Reload(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
