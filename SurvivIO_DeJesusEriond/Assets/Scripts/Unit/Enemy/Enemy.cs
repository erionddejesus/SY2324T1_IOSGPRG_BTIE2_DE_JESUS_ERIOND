using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] private int _radius;
    [SerializeField] private List<GameObject> _target;

    private Animator _animator;

    private void Start()
    {
        _animator = this.GetComponent<Animator>();

        base.Initialize(_maxHealth, _movementSpeed, _rotationSpeed);
        RandomWeapon();
    }

    private void Update()
    {
        if (_target.Count == 0)
        {
            _animator.SetFloat("distance", 100);
            return;
        }

        _animator.SetFloat("distance", Vector3.Distance(transform.position, _target[0].transform.position));

        if (_fireRateTimer > 0)
        {
            _fireRateTimer -= Time.deltaTime;
        }

        if (_currentWeapon._currentClip <= 0 && !_isReloading)
        {
            _isReloading = true;
            StartCoroutine(CO_Reload(_currentWeapon._reloadSpeed));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>())
        {
            _target.Add(collider.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Health>())
        {
            _target.Remove(collider.gameObject);
        }
    }

    public GameObject GetTarget()
    {
        if (_target.Count != 0)
        {
            return _target[0];
        }
        else
        {
            return null;
        }
    }

    public Vector3 SetNewDestination()
    {
        Vector3 destination = new Vector3(transform.position.x + Random.Range(-_radius, _radius),
                                          transform.position.y + Random.Range(-_radius, _radius), 0);

        return destination;
    }

    public void LookAtTarget(Vector3 target)
    {
        Vector3 pos = target - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, pos), _rotationSpeed * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        transform.Translate(0, _movementSpeed * Time.deltaTime, 0);
    }

    public override void Shoot()
    {
        if (_fireRateTimer <= 0)
        {
            base.Shoot();
        }
    }

    protected override IEnumerator CO_Reload(float time)
    {
        yield return new WaitForSeconds(time);

        _currentWeapon._currentClip = _currentWeapon._clipCapacity;

        _isReloading = false;
    }

    private void RandomWeapon()
    {
        Weapon weapon = new Weapon();
        int random = Random.Range(0, 3);

        switch (random)
        {
            case 0:
                weapon.Initialize(AmmoType.Pistol, 2.16f, 4, 1.2f, 1, 10, 15); // Pistol
                break;
            case 1:
                weapon.Initialize(AmmoType.Automatic, 0.35f, 4.6f, 1.1f, 1, 15, 30); // Automatic
                break;
            case 2:
                weapon.Initialize(AmmoType.Shotgun, 0.6f, 5.4f, 10, 8, 10, 2); // Shotgun
                break;
        }

        SetCurrentWeapon(weapon, random);
    }
}
